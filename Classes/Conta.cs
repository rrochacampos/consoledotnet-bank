using System.Runtime.CompilerServices;
using System.Globalization;
using System;

namespace consoledotnet_bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;  
        }

        public bool Sacar(double valor)
        {
            if(this.Saldo - valor < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente para saque");
                return false;
            }

            this.Saldo -= valor;
            Console.WriteLine("Saque realizado com sucesso!");
            Console.WriteLine($"Saldo atual da conta {this.Nome} é de R${this.Saldo}");
            return true;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;

            Console.WriteLine("Deposito realizado com sucesso!");
            Console.WriteLine($"Saldo atual da conta {this.Nome} é de R${this.Saldo}");
        }

        public void Transferir(double valor, Conta contaDestino)
        {
            if(this.Sacar(valor))
            {
                contaDestino.Depositar(valor);
            }
        }

        public override string ToString()
        {
            string retorno = "\n";
            retorno += "Nome: " + this.Nome + "\n";
            retorno += "Tipo da conta: " + this.TipoConta + "\n";
            retorno += "Saldo: " + this.Saldo + "\n";
            retorno += "Crédito: " + this.Credito + "\n";
            return retorno;
        }
    }
}