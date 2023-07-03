using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> golos = new Dictionary<int, string>();

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Registrar um golo");
            Console.WriteLine("2 - Mostrar todos os golos");
            Console.WriteLine("3 - Exportar para ficheiro");
            Console.WriteLine("4 - Sair");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.\n");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    RegistrarGolo(golos);
                    break;
                case 2:
                    MostrarGolos(golos);
                    break;
                case 3:
                    Exportar_ficheiro(golos);
                    break;
                case 4:
                    Console.WriteLine("Encerrando o programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.\n");
                    break;
            }
        }
    }

    static void RegistrarGolo(Dictionary<int, string> golos)
    {
        Console.WriteLine("Digite o minuto em que o gol foi marcado:");
        int minuto;
        if (!int.TryParse(Console.ReadLine(), out minuto))
        {
            Console.WriteLine("Minuto inválido. Gol não registrado.\n");
            return;
        }

        Console.WriteLine("Digite o nome do jogador que marcou o gol:");
        string jogador = Console.ReadLine();

        Console.WriteLine("Digite o nome da equipe que marcou o golo:");
        string equipe = Console.ReadLine();

        string informacoesGol = $"{jogador} ({equipe}) - {minuto} minuto";
        golos[minuto] = informacoesGol;

        Console.WriteLine("Golo registrado com sucesso!\n");
    }

    static void MostrarGolos(Dictionary<int, string> golos)
    {
        if (golos.Count == 0)
        {
            Console.WriteLine("Nenhum golo foi registrado.\n");
            return;
        }

        Console.WriteLine("Lista de golos registrados:");
        foreach (var gol in golos)
        {
            Console.WriteLine(gol.Value);
        }

        Console.WriteLine();
    }

    static void Exportar_ficheiro(Dictionary <int, string> golos)
    {
        if (golos.Count == 0)
        {
            Console.WriteLine("Nao existem registos de golos");
            return;
        }

        Console.WriteLine("Indicar o caminho para o ficheiro:");
            string ficheiro = Console.ReadLine();

        using (StreamWriter gravar = new StreamWriter(ficheiro));
        {
            foreach (var golo in golos)
                write.WriteLine(golos.Value);
        }
    }
}

//foreach(var N in jogo)escritor.WriteLine("o golo numero: " + N.Key + "pela equipa " + N.Value.equipa + )
