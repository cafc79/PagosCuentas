using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PAT.Common.Extensions;

namespace PAT.Common.Functions;

public static class FunctionsExtensions
{
    public static async Task<IActionResult> ProcessRequest<TRequest, TResponse>(
        this HttpRequest req,
        ILogger logger,
        Func<TRequest, Task<TResponse>> processor)
        where TRequest : struct
    {
        logger.LogInformation("Petición recibida de tipo {RequestType}", typeof(TRequest).Name);
        var request = new TRequest();
        try
        {
            request = await new StreamReader(req.Body)
                .ReadToEndAsync()
                .Map(JsonConvert.DeserializeObject<TRequest>);
        }
        catch (Exception)
        {
            logger.LogError("Petición inválida de tipo {TRequest}", typeof(TRequest).Name);
            return new BadRequestObjectResult(
                $"Petición inválida {typeof(TRequest).Name}");
        }

        try
        {
            return new OkObjectResult(await processor(request));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al procesar la petición {RequestType}", typeof(TRequest).Name);
            throw;
        }
    }
}