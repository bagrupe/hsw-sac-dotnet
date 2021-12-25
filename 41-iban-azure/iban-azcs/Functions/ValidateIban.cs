using System.Net;
using System.Web;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HSW;

public static class ValidateIban
{
    [Function("ValidateIban")]
    public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("ValidateIban");

        var query = HttpUtility.ParseQueryString(req.Url.Query);
        var iban = query["iban"];

        if (iban is null)
        {
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        logger.LogInformation("Validating IBAN: " + iban);

        var valid = IbanUtil.Validate(iban);
        if (valid)
        {
            var success = req.CreateResponse(HttpStatusCode.OK);
            await success.WriteAsJsonAsync<IbanResponse>(IbanResponse.OfSuccess(iban));
            return success;
        }

        var failure = req.CreateResponse();
        await failure.WriteAsJsonAsync<IbanResponse>(IbanResponse.OfFailure(iban, "IBAN konnte nicht geparst werden"));
        failure.StatusCode = HttpStatusCode.BadRequest;

        return failure;
    }
}