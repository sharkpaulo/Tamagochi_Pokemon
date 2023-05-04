using RestSharp;
using System.Text.Json;
using Tamagotchi_Pokemon.Controller;
using Tamagotchi_Pokemon.Model;

namespace Tamagotchi_Pokemon.View
{
    public static class Adocao
    {
        public static Mascote Adotar(string usuario)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("------------------------------ADOTAR UM MASCOTE------------------------------");
                Console.WriteLine($"{usuario} Escolha uma especie");
                Lista_Pokemons.ListarPokemons();
                Console.WriteLine("\nUMA LISTA DE POKEMONS IRA APARECER QUANDO TERMINAR APERTE ENTER PARA ESCOLHER");
                Console.ReadKey();
                var opcao = "0";
                string mascote = "";
                var adotou = false;
                while (opcao != "3" && opcao != "2")
                {
                    Console.WriteLine("\n------------------------MENU ADOÇÃO-------------------------");
                    Console.WriteLine("Digite a especie escolhida: ");
                    mascote = Console.ReadLine();
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine($"{usuario} você deseja:");
                    Console.WriteLine("1 - Saber mais sobre o " + mascote);
                    Console.WriteLine("2 - Adotar " + mascote);
                    Console.WriteLine("3 - Voltar");
                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            ExibirPokemon.GetPokemon(mascote);
                            Console.ReadKey();
                            break;
                        case "2":
                            var options = new RestClientOptions("https://pokeapi.co")
                            {
                                MaxTimeout = -1,
                            };
                            var client = new RestClient(options);
                            var request = new RestRequest($"/api/v2/pokemon/{mascote.ToLower()}/", Method.Get) { RequestFormat = DataFormat.Json };
                            RestResponse response = client.Execute(request);
                            Mascote mascoteEscolhido = JsonSerializer.Deserialize<Mascote>(response.Content);
                            Console.WriteLine($"\n{usuario} MASCOTE ADOTADO COM SUCESSO O OVO ESTA CHOCANDO");
                            Console.WriteLine("----------------------------------------------------------");
                            Console.WriteLine("░▄▀░░░█\r\n░░▀▄░░░▀░░░░░▀░░░▄▀\r\n░░░░▌░▄▄░░░▄▄░▐▀▀\r\n░░░▐░░█▄░░░▄█░░▌▄▄▀▀▀▀█\r\n░░░▌▄▄▀▀░▄░▀▀▄▄▐░░░░░░█\r\n▄▀▀▐▀▀░▄▄▄▄▄░▀▀▌▄▄▄░░░█\r\n█░░░▀▄░█░░░█░▄▀░░░░█▀▀▀\r\n░▀▄░░▀░░▀▀▀░░▀░░░▄█▀\r\n░░░█░░░░░░░░░░░▄▀▄░▀▄\r\n░░░█░░░░░░░░░▄▀█░░█░░█\r\n░░░█░░░░░░░░░░░█\r\n");
                            Console.ReadKey();                           
                            return mascoteEscolhido;
                        case "3":
                            break;
                        default:
                            Console.WriteLine("Opção desconhecida tente novamente");
                            Console.ReadKey();
                            break;
                    }
                }
                    return null;               
            }
            catch (Exception)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("POKEMON INEXISTENTE TENTE OUTRA ESPECIE");
                Console.ReadKey();
                return null;
            }           
        }
    }
}
