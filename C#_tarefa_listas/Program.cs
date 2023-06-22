using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Exercício 1
        List<int> numeros1 = GerarListaAleatoria(100, 0, 2000);
        int maiorValor1 = EncontrarMaiorValor(numeros1);
        Console.WriteLine($"Exercício 1 - Maior valor na lista: {maiorValor1}");

        // Exercício 2
        List<string> frutas = new List<string>() { "Maçã", "Banana", "Laranja", "Pera", "Abacaxi" };
        Console.WriteLine("\nExercício 2 - Lista de frutas:");
        ExibirLista(frutas);

        Console.Write("Digite a fruta a ser substituída: ");
        string? frutaASubstituir = Console.ReadLine();
        string frutaASubstituirNotNULL = frutaASubstituir ?? string.Empty;        

        Console.Write("Digite a fruta a ser inserida: ");
        string? frutaAInserir = Console.ReadLine();
        string frutaAInserirNotNULL = frutaAInserir ?? string.Empty;        

        SubstituirFruta(frutas, frutaASubstituirNotNULL, frutaAInserirNotNULL);
        Console.WriteLine("Lista atualizada:");
        ExibirLista(frutas);

        // Exercício 3
        List<int> numeros2 = GerarListaAleatoria(400, 100, 200);
        Console.WriteLine("\nExercício 3 - Lista de números gerada:");
        ExibirLista(numeros2);
        int numeroEscolhido;
        do
        {
            Console.Write("Digite um número inteiro entre 100 e 200: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out numeroEscolhido) || numeroEscolhido < 100 || numeroEscolhido > 200)
                Console.WriteLine("Entrada inválida. Tente novamente.");            
            else
                break;
        

        } while (true);
        RemoverNumero(numeros2, numeroEscolhido);
        Console.WriteLine("Lista atualizada:");
        ExibirLista(numeros2);

        // Exercício 4
        List<string> nomes = new List<string>();
        do
        {
            Console.WriteLine("\nExercício 4 - MENU");
            Console.WriteLine("1. Inserir nome");
            Console.WriteLine("2. Remover nome");
            Console.WriteLine("3. Procurar nome");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            string? input = Console.ReadLine();
            if (input == "1")
            {
                Console.Write("Digite o nome a ser inserido: ");
                string? nome = Console.ReadLine();
                string nomeNotNULL = nome ?? string.Empty;
                nomes.Add(nomeNotNULL);
                Console.WriteLine("Nome inserido com sucesso!");
            }
            else if (input == "2")
            {
                Console.Write("Digite o nome a ser removido: ");
                string? nome = Console.ReadLine();
                string nomeNotNULL = nome ?? string.Empty;
                bool removido = nomes.Remove(nomeNotNULL);
                if (removido)
                    Console.WriteLine("Nome removido com sucesso!");
                else
                    Console.WriteLine("O nome não existe na lista.");
            }
            else if (input == "3")
            {
                Console.Write("Digite o nome a ser procurado: ");
                string? nome = Console.ReadLine();
                string nomeNotNULL = nome ?? string.Empty;
                bool encontrado = nomes.Contains(nomeNotNULL);
                if (encontrado)
                    Console.WriteLine("O nome existe na lista.");
                else
                    Console.WriteLine("O nome não existe na lista.");
            }
            else if (input == "4")
                break;
            else
                Console.WriteLine("Opção inválida. Tente novamente.");
        } while (true);
    }

    static List<int> GerarListaAleatoria(int tamanho, int valorMinimo, int valorMaximo)
    {
        Random random = new Random();
        List<int> lista = new List<int>();
        for (int i = 0; i < tamanho; i++)
        {
            int numero = random.Next(valorMinimo, valorMaximo + 1);
            lista.Add(numero);
        }
        return lista;
    }

    static void ExibirLista(List<int> lista)
    {
        foreach (int numero in lista)
            Console.Write($"{numero} ");
        Console.WriteLine();
    }

    static void ExibirLista(List<string> lista)
    {
        foreach (string? item in lista)
            Console.Write($"{item} ");
        Console.WriteLine();
    }

    static int EncontrarMaiorValor(List<int> lista)
    {
        int maiorValor = int.MinValue;
        foreach (int numero in lista)
        {
            if (numero > maiorValor)
                maiorValor = numero;
        }
        return maiorValor;
    }

    static void SubstituirFruta(List<string> lista, string frutaASubstituir, string frutaAInserir)
    {
        int indice = lista.IndexOf(frutaASubstituir);
        if (indice != -1)
            lista[indice] = frutaAInserir;        
        else
            Console.WriteLine("A fruta a ser substituída não existe na lista.");
    }

    static void RemoverNumero(List<int> lista, int numero)
    {
        lista.RemoveAll(n => n == numero);

    }
}
