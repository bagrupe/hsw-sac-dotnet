using System;

namespace HSW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CountryCode:");
            string cc = Console.ReadLine();
            Console.WriteLine("Account:");
            string acc = Console.ReadLine();
            Console.WriteLine("Bank:");
            string bank = Console.ReadLine();
            Console.WriteLine(IbanUtil.Create(cc, acc, bank));
        }
    }
}
