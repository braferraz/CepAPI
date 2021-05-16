using Refit;
using System;
using System.Threading.Tasks;

namespace CepAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var clientCep = RestService.For<ICepService>("https://viacep.com.br/");
                Console.WriteLine("Informe seu CEP: ");
                string cep = Console.ReadLine().ToString();
                Console.WriteLine("Consultando CEP ...");

                var endereco = await clientCep.GetAddressAsync(cep);

                Console.WriteLine("\nCEP: " + endereco.Cep);
                Console.WriteLine("Endereço: " + endereco.Logradouro);
                Console.WriteLine("Bairro: " + endereco.Bairro);
                Console.WriteLine("Localidade: " + endereco.Localidade);

                Console.WriteLine("\nPresione ENTER para sair...");
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao consultar CEP! Tente novamente!");
            }
        }
    }
}
