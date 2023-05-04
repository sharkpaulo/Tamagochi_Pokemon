using RestSharp;
using System.Text.Json;
using Tamagotchi_Pokemon.Model;
using Tamagotchi_Pokemon.View;

namespace Tamagotchi_Pokemon.Controller
{
    public static class Lista_Pokemons
    {
        public static async void ListarPokemons()
        {
            var options = new RestClientOptions("https://pokeapi.co")
            {
                MaxTimeout = -1,
            };
            for (int i = 1; i < 20; i++)
            {
                var client = new RestClient(options);
                var request = new RestRequest($"/api/v2/pokemon/{i}/", Method.Get) { RequestFormat = DataFormat.Json };
                RestResponse response = await client.ExecuteAsync(request);
                Mascote mascote = JsonSerializer.Deserialize<Mascote>(response.Content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Nome do Pokemon: {mascote.name.ToUpper()}");
                    Console.WriteLine("---------------------------------");
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
            }

        }
    }
}
