using System.Text.Json.Serialization;

namespace HSW {
    public class CustomerRequest {

        public CustomerRequest(string name, string address) {
            this.Name = name;
            this.Address = address;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("iban")]
        public string? Iban { get; set; }

        [JsonPropertyName("ibanRequest")]
        public IbanRequest? IbanRequest { get; set; }
    }
}