using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi_Pokemon.Model;

namespace Tamagotchi_Pokemon.View
{
    public static class Menu
    {
        public static void GetMenu()
        {
            Console.WriteLine("╔════╗╔═══╗╔═╗╔═╗╔═══╗╔═══╗╔═══╗╔═══╗╔╗─╔╗╔══╗\r\n║╔╗╔╗║║╔═╗║║║╚╝║║║╔═╗║║╔═╗║║╔═╗║║╔═╗║║║─║║╚╣─╝\r\n╚╝║║╚╝║║─║║║╔╗╔╗║║║─║║║║─╚╝║║─║║║║─╚╝║╚═╝║─║║─\r\n──║║──║╚═╝║║║║║║║║╚═╝║║║╔═╗║║─║║║║─╔╗║╔═╗║─║║─\r\n──║║──║╔═╗║║║║║║║║╔═╗║║╚╩═║║╚═╝║║╚═╝║║║─║║╔╣─╗\r\n──╚╝──╚╝─╚╝╚╝╚╝╚╝╚╝─╚╝╚═══╝╚═══╝╚═══╝╚╝─╚╝╚══╝");
            Console.WriteLine();
            Console.WriteLine("Qual o seu nome? ");
            var usuario = Console.ReadLine();
            MascotesAdotados mascoteAdotados = new MascotesAdotados();

            var opção = "0";
            while (opção != "3")
            {
                Console.Clear();
                Console.WriteLine("------------------------------------MENU---------------------------------------");
                Console.WriteLine($"{usuario} Você deseja: ");
                Console.WriteLine("1 - Adotar um mascote virtual");
                Console.WriteLine("2 - Ver seus mascotes");
                Console.WriteLine("3 - Sair");
                opção = Console.ReadLine();

                switch (opção)
                {
                    case "1":
                        var mascote = Adocao.Adotar(usuario);
                        if (mascote != null)
                        {
                            mascoteAdotados.AdicionarMascote(mascote);
                            Console.WriteLine("\nMASCOTE " + mascote.name.ToUpper() + " ADOTADO");
                            Console.WriteLine("--------------------------------------------------");
                            Console.ReadKey();
                        }                       
                        break;
                    case "2":
                        Acoes.MenuAcoes(mascoteAdotados);
                        Console.ReadKey();
                        break; 
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Encerrando...");
                        break;
                    default:
                        Console.WriteLine("Opção desconhecida tente novamente");
                        Console.ReadKey();
                        break;
                }
            }           
        }
    }
}
