using System.Text.Json.Serialization;

namespace HSW {
    public class IbanResponse {

        public IbanResponse(string iban, bool valid) {
            this.Iban = iban;
            this.Valid = valid;
        }

        [JsonPropertyName("iban")]
        public string Iban { get; set;}

        [JsonPropertyName("valid")]
        public bool Valid { get; set; }
    }
}