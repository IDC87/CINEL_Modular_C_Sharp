using System;
using System.Collections.Generic;

namespace Ex_Classes
{
    public class Rectangulo
    {
        public static void IntroduzirMedidas()
        {
            Console.WriteLine("Indique a altura do Rectangulo: ");
            string s_altura = Console.ReadLine() ?? string.Empty;
            double altura = Int32.Parse(s_altura);
            Console.Clear();

            Console.WriteLine("Indique a largura do Rectagulo: ");
            string s_largura = Console.ReadLine() ?? string.Empty;
            double largura = Int32.Parse(s_largura);
            Console.Clear();

            double Area = CalcularArea(altura, largura);
            Console.WriteLine($"Area do rectangulo {Area}");
        }

        public static double CalcularArea(double Aaltura, double Alargura)
        {
            return Aaltura * Alargura;
        }        
    }

    class ContaBancaria
    {
        private string nome;
        private double saldo;
        

        public ContaBancaria(string nome, double saldoInicial)
        {
            this.nome = nome;
            saldo = saldoInicial;
        }

        public void Depositar(double valor)
        {
            saldo = saldo + valor;
            Console.WriteLine($"Depositado {valor} euros na conta de {nome}");
        }

        public void Levantamento(double valor)
        {
            if (valor > saldo)
            {
                Console.WriteLine($"saldo na conta de {nome} insuficiente!");
            }
            else
            {
                saldo = saldo - valor;
                Console.WriteLine($"Levantamento {valor} euros efetuado!");
            }
        }

        public void Consulta()
        {
            Console.WriteLine($"Conta {nome}. Saldo: {saldo} euros");
        }
    }

    class Produto
    {
        private string? nome;
        private double preco;
        private int quantidade;

        public Produto(string nome, double preco, int quantidade)
        {
            this.nome = nome;
            this.preco = preco;
            this.quantidade = quantidade;
        }

        public void Alterar_quantidade(int quantidade_alterada)
        {
            quantidade = quantidade + quantidade_alterada;
            Console.WriteLine($"No item {nome} foram adicionadas mais {quantidade} unidades");

        }

        public void Remover_Quantidade(int quantidade_Removida)
        {
            if (quantidade_Removida > quantidade)
            {
                Console.WriteLine($"Não é possível remover {quantidade_Removida} unidades do produto {nome}. A quantidade disponível é de {quantidade} unidades.");
            }
            else
            {
                quantidade = quantidade - quantidade_Removida;
                Console.WriteLine($"Foram removidas {quantidade_Removida} unidades do produto {nome}.");
            }
        }

        public void AlterarPreco(double novoPreco)
        {
            preco = novoPreco;
            Console.WriteLine($"O preço do produto {nome} foi alterado para {preco}.");
        }

        public double CalcularValorTotal()
        {
            return preco * quantidade;
        }

    }

    public class Menu
    {
        static int Main()
        {
            Console.Clear();  
            Console.WriteLine("Calcular a Area de um Rectangulo!");   
            Console.Write("\n");       
            Rectangulo.IntroduzirMedidas();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Qual o nome da Conta?");
            string User = Console.ReadLine() ?? string.Empty;
            
            Console.WriteLine("Pretende:  1-Depositar,  2-Levantar, 3-Consultar saldo ou 4-Sair?");
            string s_SaldoMenu = Console.ReadLine() ?? string.Empty;
            int SaldoMenu = Int32.Parse(s_SaldoMenu);

            ContaBancaria conta = new ContaBancaria(User, 0);
            Produto produto = new Produto("Produto XPTO", 0, 0);


            while (SaldoMenu != 4)
            {          

                if(SaldoMenu == 1)
                {
                    Console.WriteLine("Quanto valor pretende depositar: ");
                    string s_depositar = Console.ReadLine() ?? string.Empty;
                    double depositar = Int32.Parse(s_depositar);                   
                    conta.Depositar(depositar);                   

                }
                else if (SaldoMenu == 2)
                {
                    Console.WriteLine("Quanto valor pretende levantar: ");
                    string s_levantar = Console.ReadLine() ?? string.Empty;
                    double levantar = double.Parse(s_levantar);
                    conta.Levantamento(levantar);  
                }
                else if (SaldoMenu == 3)
                {
                    conta.Consulta();
                }

                Console.Write("\n");

                Console.WriteLine("Pretende:  1-Depositar,  2-Levantar, 3-Consultar saldo ou 4-Sair?");
                s_SaldoMenu = Console.ReadLine() ?? string.Empty;
                SaldoMenu = Int32.Parse(s_SaldoMenu);
            }

            Console.Clear();

            while (true)
            {
                Console.WriteLine("Menu Produto");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar quantidade");
                Console.WriteLine("2 - Remover quantidade");
                Console.WriteLine("3 - Alterar preço");
                Console.WriteLine("4 - Calcular valor total");
                Console.WriteLine("5 - Sair");

                string input = Console.ReadLine() ?? string.Empty;
                int opcao = int.Parse(input);

                if (opcao == 1)
                {
                    Console.WriteLine("Quantidade a adicionar: ");
                    string sQuantidade = Console.ReadLine() ?? string.Empty;
                    int quantidade = int.Parse(sQuantidade);
                    produto.Alterar_quantidade(quantidade);
                }
                else if (opcao == 2)
                {
                    Console.WriteLine("Quantidade a remover: ");
                    string sQuantidade = Console.ReadLine() ?? string.Empty;
                    int quantidade = int.Parse(sQuantidade);
                    produto.Remover_Quantidade(quantidade);
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("Novo preço: ");
                    string sPreco = Console.ReadLine() ?? string.Empty;
                    double preco = double.Parse(sPreco);
                    produto.AlterarPreco(preco);
                }
                else if (opcao == 4)
                {
                    double valorTotal = produto.CalcularValorTotal();
                    Console.WriteLine($"Valor total do produto: {valorTotal}");
                }
                else if (opcao == 5)
                {
                    break; // Exit the loop and end the program
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }

                Console.WriteLine();
            }

            
            

            return 0;
        }

    }
}