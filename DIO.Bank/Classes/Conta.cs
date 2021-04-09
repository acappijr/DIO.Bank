using System;
using System.Threading.Channels;
using DIO.Bank.Enum;

namespace DIO.Bank.Classes
{
    class Conta
    {
        public Conta(TipoConta tipoConta, decimal saldo, decimal credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public TipoConta TipoConta { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal Credito { get; private set; }
        public string Nome { get; private set; }

        public bool Sacar(decimal valorSaque)
        {
            if (Saldo - valorSaque < Credito * - 1)
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");

            return true;
        }

        public void Depositar(decimal valorDeposito)
        {
            Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");
        }

        public void Transferir(decimal valorTransferencia, Conta contaDestino)
        {
            var saqueEfetuado = Sacar(valorTransferencia);
            if (saqueEfetuado)
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            var retorno = "";
            retorno += $"TipoConta {TipoConta} | ";
            retorno += $"Nome {Nome} | ";
            retorno += $"Saldo {Saldo:C} | ";
            retorno += $"Credito {Credito:C} | ";
            retorno += $"TipoConta {TipoConta}";
            return retorno;
        }
    }
}
