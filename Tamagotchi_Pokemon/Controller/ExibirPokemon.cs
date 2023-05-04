using RestSharp;
using System.Text.Json;
using Tamagotchi_Pokemon.Model;

namespace Tamagotchi_Pokemon.Controller
{
    public static class ExibirPokemon
    {
        public static async void GetPokemon(string pokemon)
        {
            try
            {
                    var options = new RestClientOptions("https://pokeapi.co")
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest($"/api/v2/pokemon/{pokemon.ToLower()}/", Method.Get) { RequestFormat = DataFormat.Json };
                    RestResponse response = await client.ExecuteAsync(request);
                    Mascote mascote = JsonSerializer.Deserialize<Mascote>(response.Content);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine($"Nome do Pokemon: {mascote.name}");
                        Console.WriteLine($"Altura: {mascote.height}");
                        Console.WriteLine($"Peso: {mascote.weight}");
                        Console.WriteLine("HABILIDADES:");
                        foreach (var item in mascote.abilities)
                        {
                            Console.WriteLine(item.ability.name.ToUpper());
                        }
                        Console.WriteLine("---------------------------------");
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                   
            }
            catch (Exception)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Pokemon não existe digite uma especie valida");
            }           
        }
    }
}
