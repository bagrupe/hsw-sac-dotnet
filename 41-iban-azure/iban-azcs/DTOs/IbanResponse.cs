using System.Text.Json.Serialization;

namespace HSW
{
    public class IbanResponse
    {

        public static IbanResponse OfSuccess(string iban)
        {
            return new IbanResponse(iban, true, "IBAN is valid");
        }

        public static IbanResponse OfFailure(string iban, string message)
        {
            return new IbanResponse(iban, false, message);
        }

        public IbanResponse(string iban, bool valid, string message)
        {
            this.Iban = iban;
            this.Valid = valid;
            this.Message = message;
        }

        [JsonPropertyName("iban")]
        public string Iban { get; set; }

        [JsonPropertyName("valid")]
        public bool Valid { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public override string ToString()
        {
            return $"IBAN: {Iban} Valid: {Valid} Message: {Message}";
        }
    }
}