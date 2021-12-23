using System;
using System.Threading.Tasks;

namespace HSW
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var response = await IbanClient.ProcessCreation(new IbanRequest("DE", "44448888", "123987"));
            Console.WriteLine(response?.ToString());

            var validation = await IbanClient.ProcessValidation("DE90444488880000123987");
            Console.WriteLine(validation?.ToString());

        }
    }
}
