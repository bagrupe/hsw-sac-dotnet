namespace rot13;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("String eingeben:");
        string? eingabe = Console.ReadLine();
        string ausgabe = string.Empty;

        for (int i = 0; i < eingabe?.Length; i++)
        {
            char x = eingabe[i];
            int pos = x + 13;
            if (pos > 122)
            {
                pos -= 26;
            }
            x = (char)pos;
            ausgabe += x;
        }

        Console.WriteLine(ausgabe);
    }
}