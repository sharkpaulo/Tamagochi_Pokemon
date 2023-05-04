using Tamagotchi_Pokemon.Controller;

namespace Tamagotchi_Pokemon.Model
{
    public class MascotesAdotados: Mascote
    {
        public List<Mascote> ListaMascotes { get; private set ; }

        public void AdicionarMascote(Mascote mascote)
        {
            ListaMascotes.Add(mascote);
        }

        public void MostrarMascotes()
        {
            Console.WriteLine("Seus Mascostes são: \n");
            foreach (var pokemon in ListaMascotes)
            {
                ExibirPokemon.GetPokemon(pokemon.name);
            }
        }

        public void StatusMascotes()
        {
            var tamanhoLista = ListaMascotes.Count();
            if (tamanhoLista == 0)
            {
                Console.WriteLine("NENHUM MASCOTE ADOTADO !!!!!!!");
                return;
            }
            Console.WriteLine("------------------------------STATUS MASCOTES------------------------------");
            foreach (var mascote in ListaMascotes)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("\nNOME DO POKEMON: " + mascote.name.ToUpper());
                Console.WriteLine("ALTURA: " + mascote.height);
                Console.WriteLine("PESO: " + mascote.weight);
                Console.WriteLine("HABILIDADES:");
                foreach (var item in mascote.abilities)
                {
                    Console.WriteLine(item.ability.name.ToUpper());
                }
                if (mascote.sono >= 8)
                {
                    Console.WriteLine(mascote.name.ToUpper() + " ESTA COM SONO!");
                }
                else
                {
                    Console.WriteLine(mascote.name.ToUpper() + " ESTA SEM SONO!");
                }               
                if (mascote.alimentacao <= 5)
                {
                    Console.WriteLine(mascote.name.ToUpper() + " ESTA COM FOME!");
                }
                else
                {
                    Console.WriteLine(mascote.name.ToUpper() + " ESTA ALIMENTADO!");
                }

                if (mascote.humor <= 4)
                {
                    Console.WriteLine(mascote.name.ToUpper() + " ESTA RABUGENTO!");
                }
                else
                {
                    Console.WriteLine(mascote.name.ToUpper() + " ESTA FELIZ!");
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
        }

        public void Acoes(string opcao)
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\nDigite o mascote que voce vai utilizar");
            var nome = Console.ReadLine();
            if (ExisteMascote(nome) != true)
            {
                Console.WriteLine($"\nMascote {nome} não foi adotado ou não existe");
                return;
            }
            
            switch (opcao)
            {
                case "2":
                    foreach (var pokemon in ListaMascotes)
                    {
                        if (pokemon.name == nome)
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            pokemon.BrincarMascote();
                            Console.WriteLine("-----------------------------------------------------------------------------");
                        }
                    }
                    break;
                case "3":
                    foreach (var pokemon in ListaMascotes)
                    {
                        if (pokemon.name == nome)
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            pokemon.Comer();
                            Console.WriteLine("-----------------------------------------------------------------------------");
                        }
                    }
                    break;
                case "4":
                    foreach (var pokemon in ListaMascotes)
                    {
                        if (pokemon.name == nome)
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            pokemon.Dormir();
                            Console.WriteLine("-----------------------------------------------------------------------------");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Opção desconhecida tente Novamente");
                    Console.ReadKey();
                    break;
            }
        }

        public bool ExisteMascote(string nome)
        {
            foreach (var pokemon in ListaMascotes)
            {
                if(pokemon.name == nome)
                {
                    return true;
                }
            }
            return false;
        }
        public MascotesAdotados()
        {
            ListaMascotes = new List<Mascote>();
        }

    }
}
