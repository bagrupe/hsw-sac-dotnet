using System.Text.Json.Serialization;

namespace HSW {
    public class IbanRequest {
        public IbanRequest(string countryCode, string bankIdentification, string accountNumber) {
            this.CountryCode = countryCode;
            this.BankIdentification = bankIdentification;
            this.AccountNumber = accountNumber;
        }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("bankIdentification")]
        public string BankIdentification { get; set; }

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }
    }
}