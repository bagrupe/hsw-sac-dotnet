using System.Text.Json.Serialization;

namespace HSW;
public class CustomerResponse
{
    public CustomerResponse(long id, string name, string address, string iban)
    {
        this.Id = id;
        this.Name = name;
        this.Address = address;
        this.Iban = iban;
    }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("iban")]
    public string Iban { get; set; }
}