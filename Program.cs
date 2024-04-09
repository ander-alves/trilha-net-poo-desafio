using System;
using System.Collections.Generic;
using DesafioPOO.Models;

namespace DasafioPoo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Nokia> listaNokia = new List<Nokia>();
            List<Iphone> listaIphone = new List<Iphone>();
            
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1 - Listar Smartphones");
                Console.WriteLine("2 - Criar Novo Smartphone");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");
                
                int opcao = LerInteiroEntre(1, 3);

                switch (opcao)
                {
                    case 1:
                        ListarSmartphones(listaNokia, listaIphone);
                        break;
                    case 2:
                        CriarNovoSmartphone(listaNokia, listaIphone);
                        break;
                    case 3:
                        continuar = false;
                        break;
                }
            }

            Console.WriteLine("Programa encerrado. Obrigado!");
        }

        static void ListarSmartphones(List<Nokia> listaNokia, List<Iphone> listaIphone)
        {
            Console.WriteLine("\nSmartphones Nokia:");
            foreach (var nokia in listaNokia)
            {
                Console.WriteLine($"Modelo: {nokia.Modelo} - Número: {nokia.Numero}");
            }

            Console.WriteLine("\nSmartphones iPhone:");
            foreach (var iphone in listaIphone)
            {
                Console.WriteLine($"Modelo: {iphone.Modelo} - Número: {iphone.Numero}");
            }
        }

        static void CriarNovoSmartphone(List<Nokia> listaNokia, List<Iphone> listaIphone)
        {
            Console.WriteLine("\nEscolha o tipo de smartphone que deseja criar:");
            Console.WriteLine("1 - Nokia");
            Console.WriteLine("2 - iPhone");

            int escolha = LerInteiroEntre(1, 2);
            string tipoSmartphone = "";

            switch (escolha)
            {
                case 1:
                    tipoSmartphone = "Nokia";
                    Nokia novoNokia = CriarNovoNokia();
                    listaNokia.Add(novoNokia);
                    break;
                case 2:
                    tipoSmartphone = "iPhone";
                    Iphone novoIphone = CriarNovoIphone();
                    listaIphone.Add(novoIphone);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }

            Console.WriteLine($"Smartphone {tipoSmartphone} criado com sucesso!");
        }

        static Nokia CriarNovoNokia()
        {
            Console.WriteLine("Informe o modelo do Nokia:");
            string modelo = Console.ReadLine();

            Console.WriteLine("Informe o IMEI do Nokia:");
            string imei = Console.ReadLine();

            Console.WriteLine("Informe a memória do Nokia:");
            int memoria = LerInteiroPositivo();

            return new Nokia("", modelo, imei, memoria);
        }

        static Iphone CriarNovoIphone()
        {
            Console.WriteLine("Informe o modelo do iPhone:");
            string modelo = Console.ReadLine();

            Console.WriteLine("Informe o IMEI do iPhone:");
            string imei = Console.ReadLine();

            Console.WriteLine("Informe a memória do iPhone:");
            int memoria = LerInteiroPositivo();

            return new Iphone("", modelo, imei, memoria);
        }

        static int LerInteiroEntre(int min, int max)
        {
            int valor;
            bool valorValido = false;

            do
            {
                if (valorValido)
                {
                    Console.WriteLine($"Por favor, insira um número entre {min} e {max}.");
                }

                string entrada = Console.ReadLine();
                valorValido = int.TryParse(entrada, out valor);
            } while (!valorValido || valor < min || valor > max);

            return valor;
        }

        static int LerInteiroPositivo()
        {
            int valor;
            bool valorValido = false;

            do
            {
                if (valorValido)
                {
                    Console.WriteLine("Por favor, insira um número inteiro positivo.");
                }

                string entrada = Console.ReadLine();
                valorValido = int.TryParse(entrada, out valor);
            } while (!valorValido || valor <= 0);

            return valor;
        }
    }
}
