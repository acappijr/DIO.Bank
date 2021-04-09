using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DIO.Bank.Classes;
using DIO.Bank.Enum;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            var opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            var indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            var indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            var valorTransferencia = decimal.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir
            (
                valorTransferencia, listaContas[indiceContaDestino]
            );
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            var indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser depositado: ");
            var valorDeposito = decimal.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            var indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            var valorSaque = decimal.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            listaContas.ForEach(x => Console.WriteLine($"#{listaContas.IndexOf(x)} - {x.ToString()}"));
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            var entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            var entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            var entradaSaldo = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            var entradaCredito = decimal.Parse(Console.ReadLine());

            var novaConta = new Conta
            (
                (TipoConta)entradaTipoConta,
                entradaSaldo,
                entradaCredito,
                entradaNome
            );

            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            var opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
