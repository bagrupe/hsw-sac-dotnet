using System.Text.Json;

namespace HSW;
public static class IbanClient
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<IbanResponse?> ProcessValidation(string iban)
    {
        var streamTask = client.GetStreamAsync("http://localhost:7071/api/iban/ValidateIban?iban=" + iban);
        var response = await JsonSerializer.DeserializeAsync<IbanResponse>(await streamTask);
        return response;
    }

    public static async Task<IbanResponse?> ProcessCreation(IbanRequest request)
    {
        var streamTask = client.GetStreamAsync($"http://localhost:7071/api/iban/CreateIban?countryCode={request.CountryCode}&bankIdentification={request.BankIdentification}&accountNumber={request.AccountNumber}");

        // HTTP POST: client.PostAsync()

        var response = await JsonSerializer.DeserializeAsync<IbanResponse>(await streamTask);
        return response;
    }
}