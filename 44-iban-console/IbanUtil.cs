using System.Numerics;

namespace HSW;
public class IbanUtil
{
    public static string Create(string countryCode, string accountNumber, string bankIdentification)
    {
        Console.WriteLine($"Creating (CountryCode {countryCode}, BankIdentification {bankIdentification}, AccountNumber {accountNumber})");

        if (countryCode != "DE")
        {
            throw new ArgumentException("Derzeit nur für DE implementiert");
        }

        if (bankIdentification.StartsWith("0") || bankIdentification.StartsWith("9"))
        {
            throw new ArgumentException("Bankleitzahl darf nicht mit 0 der 9 beginnen");
        }

        if (bankIdentification.Length != 8)
        {
            throw new ArgumentException("Bankleitzahl muss 8 Ziffern lang sein");
        }

        if (accountNumber.Length > 10)
        {
            throw new ArgumentException("Kontonummer darf maximal 10-stellig sein");
        }

        if (accountNumber.Replace("0", "") == string.Empty)
        {
            throw new ArgumentException("Kontonummer muss gefüllt sein");
        }

        string checkIban = $"{bankIdentification}{accountNumber,10}131400".Replace(" ", "0");

        long checkDigit = (long)BigInteger.Remainder(BigInteger.Parse(checkIban), new BigInteger(97));

        string iban = $"{countryCode}{checkDigit:00}{bankIdentification}{accountNumber,10}".Replace(" ", "0");

        return iban;
    }

    public static bool Validate(string iban)
    {
        try
        {
            string countryCode = iban.Substring(0, 2);
            string bankIdentification = iban.Substring(4, 8);
            string accountNumber = iban.Substring(12, 10);
            Console.WriteLine($"Validating {iban} (CountryCode {countryCode}, BankIdentification {bankIdentification}, AccountNumber {accountNumber})");

            string created = Create(countryCode, accountNumber, bankIdentification);
            Console.WriteLine($"Validating {iban} == {created}");
            return iban == created;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception Validating {iban} with message {e.Message}");
            return false;
        }
    }
}