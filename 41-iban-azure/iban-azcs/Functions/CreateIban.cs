using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HSW
{
    public static class CreateIban
    {
        [Function("CreateIban")]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CreateIban");
            IbanRequest request;

            try
            {
                if (req.Method == "GET")
                {
                    logger.LogInformation("C# HTTP trigger function processed a GET request.");
                    var query = HttpUtility.ParseQueryString(req.Url.Query);
                    var countryCode = query["countryCode"];
                    var bankIdentification = query["bankIdentification"];
                    var accountNumber = query["accountNumber"];
                    if(countryCode is null || bankIdentification is null || accountNumber is null) {
                        return req.CreateResponse(HttpStatusCode.BadRequest);
                    }
                    request = new IbanRequest(countryCode, bankIdentification, accountNumber);
                }
                else
                {
                    logger.LogInformation("C# HTTP trigger function processed a POST request.");
                    var result = await req.ReadFromJsonAsync<IbanRequest>();
                    if (result is null)
                    {
                        return req.CreateResponse(HttpStatusCode.BadRequest);
                    }
                    request = result;
                }
            
                logger.LogInformation($"CreateIban: {request.CountryCode}, {request.AccountNumber}, {request.BankIdentification}");
                string iban = IbanUtil.Create(request.CountryCode, request.AccountNumber, request.BankIdentification);
                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync<IbanResponse>(IbanResponse.OfSuccess(iban));

                return response;
            }
            catch (Exception e)
            {
                var response = req.CreateResponse();
                await response.WriteAsJsonAsync<IbanResponse>(IbanResponse.OfFailure("<invalid>", e.Message));
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }


        }
    }
}
