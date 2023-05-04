using Tamagotchi_Pokemon.Model;

namespace Tamagotchi_Pokemon.View
{
    public static class Acoes
    {
        public static void MenuAcoes(MascotesAdotados lista_Pokemons)
        {
            Console.Clear();
            Console.WriteLine("------------------------------MENU AÇÔES------------------------------");
            var opcoes = "0";
            while (opcoes != "5") 
            {
                Console.WriteLine("\n1- Status dos mascotes");
                Console.WriteLine("2- Brincar com mascote");
                Console.WriteLine("3- Alimentar o mascote");
                Console.WriteLine("4- Colocar mascote para dormir");
                Console.WriteLine("5- Voltar");
                Console.WriteLine("\nDigite a opção desejada: ");
                opcoes = Console.ReadLine();
                switch (opcoes)
                {
                    case "1":
                        Console.WriteLine("---------------------------------------------------------------------------");
                        lista_Pokemons.StatusMascotes();
                        Console.ReadKey();
                        break;
                    case "2":
                        lista_Pokemons.MostrarMascotes();
                        Console.ReadKey();
                        lista_Pokemons.Acoes("2");
                        Console.ReadKey();
                        break;
                    case "3":
                        lista_Pokemons.MostrarMascotes();
                        Console.ReadKey();
                        lista_Pokemons.Acoes("3");
                        Console.ReadKey();
                        break;
                    case "4":
                        lista_Pokemons.MostrarMascotes();
                        Console.ReadKey();
                        lista_Pokemons.Acoes("4");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("retornando ao menu");
                        break;
                    default:
                        Console.WriteLine("Opção desconhecida tente novamente");
                        break;
                }
            }
            
        } 
    }
}
