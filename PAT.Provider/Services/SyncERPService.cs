using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PAT.Common.Interfaces;
using PAT.Models.Configuration;
using PAT.Models.Database.Tablas;
using PAT.Provider.Interafaces;
using PAT.Provider.Models;
using System.Net.Http.Headers;
using System.Text;

namespace PAT.Provider.Services
{
    public class SyncERPService : ISyncERPService
    {

        private readonly ERPSettings _eRPSettings;
        private readonly HttpClient _httpClient = new();
        private readonly ISqlRepository<DbContext> _sqlRepository;
        public SyncERPService(ISqlRepository<DbContext> sqlRepository, IOptions<ERPSettings> eRPSettings)
        {
            _sqlRepository = sqlRepository;
            _eRPSettings = eRPSettings.Value;
        }
        public async Task<SyncERPResponse> SyncDataCompanies(DateTime dateTime)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _eRPSettings.ApiERPEmpresasUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(JsonConvert.SerializeObject(new { }), Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var companies = JArray.Parse(content);

            foreach (var company in companies)
            {
                if (company["NOMBRE"] != null && company["RFC"] != null)
                {
                    var comp = await _sqlRepository.QueryAsync<ABCEmpresa>(f => f.CodigoEmpresa == company["ID"].ToString());
                    if (comp.Count==0)
                        _ = await _sqlRepository.CreateAsync<ABCEmpresa>(new ABCEmpresa
                        {

                            Empresa = company["NOMBRE"] != null ? company["NOMBRE"].ToString() : String.Empty,
                            CodigoEmpresa = company["ID"] != null ? company["ID"].ToString() : String.Empty,
                            Eliminado = false,
                            Estatus = true,
                            FechaActualizacion = System.DateTime.Now,
                            FechaCreacion = System.DateTime.Now,
                            RFC = company["RFC"] != null ? company["RFC"].ToString() : String.Empty
                        });
                    else
                    {
                        var data = comp.FirstOrDefault();
                        data.Empresa = company["NOMBRE"] != null ? company["NOMBRE"].ToString() : String.Empty;
                        data.RFC = company["RFC"] != null ? company["RFC"].ToString() : String.Empty;
                        _ = await _sqlRepository.UpdateAsync<ABCEmpresa>(data);
                    }

                }
            }
            return new SyncERPResponse { IsSync = true, Errors = new List<string> { } };
        }
    }
}
