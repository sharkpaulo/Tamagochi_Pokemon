using System.Runtime.CompilerServices;

namespace Tamagotchi_Pokemon.Model
{
    public class Mascote
    {
        public string name { get; set; }
        public List<Habilidade> abilities { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        Random rand = new Random();
        public int alimentacao { get; set; }
        public int humor { get; set; }
        public int sono { get; set; }
        public Mascote()
        {
            sono = rand.Next(0, 11);
            humor = rand.Next(0, 11);
            alimentacao = rand.Next(0, 11);
        }
        

        public void BrincarMascote()
        {          
            Console.WriteLine($"{name} está brincando \n");
            Console.WriteLine(name + " Cansou!");
            humor++;
            alimentacao--;
            sono += 2;
        }

        public void Comer()
        {
            Console.WriteLine($"{name} está comendo \n");
            Console.WriteLine(name + " Alimentado");
            alimentacao++;
            sono += 3;
            humor++;
        }

        public void Dormir()
        {
            Console.WriteLine($"{name} está dormindo ZZZZZZZZZZ \n");
            Console.WriteLine(name + " Acordou");
            sono -= 6;
            humor -= 3;
            alimentacao -= 3;
        }

        public static void PokemonExiste()
        {

        }
    }

    public class Habilidade
    {
        public Habilidade ability { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}
