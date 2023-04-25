using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PAT.Common.Interfaces;
using PAT.Models.Configuration;
using PAT.Provider.Interafaces;
using PAT.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.Services
{
    public class SyncFinerioService : ISyncFinerioService
    {
        private readonly FinerioSettings _finerioSettings;
        private readonly HttpClient _httpClient = new();
        private readonly ISqlRepository<DbContext> _sqlRepository;
        public SyncFinerioService(ISqlRepository<DbContext> sqlRepository, IOptions<FinerioSettings> finerioSettings)
        {
            _sqlRepository = sqlRepository;
            _finerioSettings = finerioSettings.Value;

        }
        public async Task<SyncFinerioResponse> GetToken()
        {
            try
            {

                var authenticationBytes = Encoding.ASCII.GetBytes("1FF47a9AjzeteGLHQ9RWS0nQkixs2s5Ed13dFlXBVN8JSsMxj8:HsL6VWSFKjnWabxLj34w5J6RFJTDpLwyrEYkavXx8avrPVkkN3");

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                      Convert.ToBase64String(authenticationBytes));
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var handler = new HttpClientHandler() { CookieContainer = new CookieContainer() })
                {
                    using (var client = new HttpClient(handler) { BaseAddress = new Uri(_finerioSettings.ApiFinerioTokenUrl) })
                    {
                        //add parameters on request
                        var body = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("test", "test"),
            new KeyValuePair<string, string>("test1", "test1")
        };

                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _finerioSettings.ApiFinerioTokenUrl);

                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded; charset=UTF-8"));
                        client.DefaultRequestHeaders.Add("username", "ftirado@ari.group");
                        client.DefaultRequestHeaders.Add("password", "4uzeA_6KL.H55dY_27091988");
                        client.DefaultRequestHeaders.Add("grant_type", "password");
                        //client.DefaultRequestHeaders.Add("Accept", "*/*");

                        client.Timeout = TimeSpan.FromMilliseconds(10000);

                        var res = await client.PostAsync("", new FormUrlEncodedContent(body));

                        if (res.IsSuccessStatusCode)
                        {
                            var exec = await res.Content.ReadAsStringAsync();
                            Console.WriteLine(exec);
                        }
                    }
                }
            }catch (Exception ex)
            {  }
            return new SyncFinerioResponse { IsSync = true, Errors = new List<string> { } };
        }
    }
}
