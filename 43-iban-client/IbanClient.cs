using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HSW {
    public static class IbanClient {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<IbanResponse?> ProcessValidation(string iban)
        {
            var streamTask = client.GetStreamAsync("http://localhost:7071/api/ValidateIban?iban="+iban);
            var response = await JsonSerializer.DeserializeAsync<IbanResponse>(await streamTask);
            return response;
        }

        public static async Task<IbanResponse?> ProcessCreation(IbanRequest request)
        {
            var streamTask = client.GetStreamAsync($"http://localhost:7071/api/CreateIban?countryCode={request.CountryCode}&bankIdentification={request.BankIdentification}&accountNumber={request.AccountNumber}");
            
            // HTTP POST: client.PostAsync()
            
            var response = await JsonSerializer.DeserializeAsync<IbanResponse>(await streamTask);
            return response;
        }
    }
}