using System;

namespace Ex_Inhe_Poly
{
    public class Pessoa
    {
        protected string nome;
        protected int idade;

        public Pessoa(string nome, int idade)
        {
            this.nome = nome;
            this.idade = idade;
        }

        public virtual void imprimir()
        {
            Console.WriteLine($"Aluno: {nome}, Idade: {idade}");
        }
    }

    public class Aluno : Pessoa
    {
        private string curso;

        public Aluno(string nome, int idade, string curso) : base(nome, idade)
        {
            this.curso = curso;
        }

        public override void imprimir()
        {
            Console.WriteLine($"Aluno: {nome}, Idade: {idade}, Curso: {curso}");
        }
    }

    public class ContaBancaria
    {
        protected int num_conta;
        protected string nome;
        protected int saldo;

        public ContaBancaria(int num_conta, string nome, int saldo)
        {
            this.num_conta = num_conta;
            this.nome = nome;
            this.saldo = saldo;
        }

        public void deposito()
        {
            Console.WriteLine("Indique o valor a depositar:");
            string s_deposito = Console.ReadLine() ?? string.Empty;
            int deposito;
            if (int.TryParse(s_deposito, out deposito))
            {
                saldo += deposito;
            }
            else
            {
                Console.WriteLine("Valor inválido. O depósito não foi efetuado.");
            }
        }

        public void levantamento()
        {
            Console.WriteLine("Quanto pretende levantar:");
            string s_levantar = Console.ReadLine() ?? string.Empty;
            int levantar;
            if (int.TryParse(s_levantar, out levantar))
            {
                if (saldo < levantar)
                    Console.WriteLine("Saldo Insuficiente para levantamento!");
                else
                    saldo -= levantar;
            }
            else
            {
                Console.WriteLine("Valor inválido. O levantamento não foi efetuado.");
            }
        }

        public void consulta()
        {
            Console.WriteLine($"O seu saldo atual: {saldo}");
        }
    }

    public class ContaPrazo : ContaBancaria
    {
        public ContaPrazo(int num_conta, string nome, int saldo) : base(num_conta, nome, saldo)
        {
        }

        public void LevantamentoComPenalizacao(decimal valor)
        {
            decimal penalizacao = valor * 0.02m; // 2% de penalizacao
            decimal valorTotal = valor + penalizacao;
            if (valorTotal <= saldo)
            {
                saldo -= (int)valorTotal;
                Console.WriteLine("Levantamento com penalização realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para o levantamento com penalização.");
            }
        }
    }

    public class ContaOrdenado : ContaBancaria
    {
        public decimal Ordenado { get; set; }

        public ContaOrdenado(int num_conta, string nome, int saldo) : base(num_conta, nome, saldo)
        {
        }

        public new void Levantamento(int valor)
        {
            if (valor <= saldo || valor <= (int)Ordenado)
            {
                saldo -= valor;
                Console.WriteLine("Levantamento realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Limite de ordenado excedido.");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa("Ivo", 36);
            pessoa.imprimir();
            Aluno aluno = new Aluno("Ivo", 36, "Formacao C#");
            aluno.imprimir();
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Indique o nome da Conta:");
            string s_nome = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            Console.WriteLine($"Indique o Numero da Conta do usuario {s_nome}:");
            string s_IDconta = Console.ReadLine() ?? string.Empty;
            int IDconta;
            if (int.TryParse(s_IDconta, out IDconta))
            {
                Console.Clear();
                Console.WriteLine($"Indique o saldo atual para a conta {IDconta} pertencente a {s_nome}:");
                string s_saldo = Console.ReadLine() ?? string.Empty;
                int saldo;
                if (int.TryParse(s_saldo, out saldo))
                {
                    ContaBancaria conta = new ContaBancaria(IDconta, s_nome, saldo);

                    int escolha_opcao = 5;

                    do
                    {
                        Console.WriteLine("Prentende:");
                        Console.WriteLine("1 - Depositar");
                        Console.WriteLine("2 - Levantar");
                        Console.WriteLine("3 - Consultar");
                        Console.WriteLine("4 - Sair");
                        string s_escolha_opcao = Console.ReadLine() ?? string.Empty;
                        escolha_opcao = int.TryParse(s_escolha_opcao, out int result) ? result : 0;

                        if (escolha_opcao == 1)
                            conta.deposito();
                        else if (escolha_opcao == 2)
                            conta.levantamento();
                        else if (escolha_opcao == 3)
                            conta.consulta();

                    } while (escolha_opcao != 4);
                }
                else
                {
                    Console.WriteLine("Valor inválido para o saldo.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido para o número da conta.");
            }
        }
    }
}
