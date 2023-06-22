using System;
using System.Collections.Generic;

namespace Ex_Dicionarios
{
    public class Exercício_1
    {
        public static void Ex_1()
        {
            bool alunoExists;
            bool flag = true;
            Dictionary <string, int> turma = new Dictionary <string, int>();
            
            Console.Write("\n");
            Console.WriteLine("----MENU----");
            Console.WriteLine("1 - Introduzir Nomes e Notas de Alunos.");
            Console.WriteLine("2 - Exibir Notas e Alunos");
            Console.WriteLine("3 - Sair.");
            Console.Write("Opcao: ");
            string? m = Console.ReadLine() ?? string.Empty;
            int menu = Int32.Parse(m);
            Console.Write("\n");

            while(menu != 3)  
            {
                if(menu == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Introduza o Nome do Aluno a inserir: ");
                    string? aluno = Console.ReadLine() ?? string.Empty;
                    alunoExists = turma.ContainsKey(aluno);
                    do
                    {
                        if (turma.ContainsKey(aluno))
                        {
                            Console.Clear();
                            Console.WriteLine("Aluno ja existe na base de dados!");
                            Console.WriteLine($"Deseja alterar a nota do aluno {aluno}? (s/n)");
                            string? conf = Console.ReadLine() ?? string.Empty;
                            if(conf == "s")
                            {
                                Console.WriteLine($"Introduza a Nota do {aluno}");
                                string? Nova_n  = Console.ReadLine() ?? string.Empty;
                                int novaNota = Int32.Parse(Nova_n);
                                turma[aluno] = novaNota;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Introduza a Nota do {aluno}");
                            string? n = Console.ReadLine() ?? string.Empty;
                            int nota = Int32.Parse(n);
                            turma.Add(aluno, nota);
                        }
                        alunoExists = false;
                    }while(alunoExists);
                    
                }
                else if(menu == 2)
                {
                    Console.Clear();
                    Console.WriteLine("---Lista de Alunos e respectivas notas!---");
                    Console.Write("\n");
                    foreach(var T in turma)Console.WriteLine(T.Key + " " + T.Value);
                    Console.Write("\n");
                    Console.Write("-------------------------------");
                    Console.Write("\n\n");
                    flag = false;
                }

                if(flag)
                    Console.Clear();
                Console.WriteLine("----MENU----");
                Console.WriteLine("1 - Introduzir Nomes e Notas de Alunos.");
                Console.WriteLine("2 - Exibir Notas e Alunos");
                Console.WriteLine("3 - Sair.");
                Console.Write("Opcao: ");
                m = Console.ReadLine() ?? string.Empty;
                menu = Int32.Parse(m);
                flag = true;

            }
        }
    }

    public class Exercício_2
    {
        public static void Ex_2()
        {
            Dictionary<string, Dictionary<string, int>> Cadeiras = new Dictionary<string, Dictionary<string, int>>();

            string? aluno_nome;
            string? opcao_cadeira;
            int nota_aluno = 0;
            bool flag = true;

            Console.Write("\n");
            Console.WriteLine("----MENU----");
            Console.WriteLine("1 - Introduzir Nomes e Notas de Alunos.");
            Console.WriteLine("2 - Exibir Notas e Alunos");
            Console.WriteLine("3 - Procurar Aluno e Verificar Disciplinas");
            Console.WriteLine("4 - Sair.");
            Console.Write("Opcao: ");

            string? opcao = Console.ReadLine() ?? string.Empty;
            int menu = Int32.Parse(opcao);

            while (menu != 4)
            {
                if (menu == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Introduza o Nome do Aluno a inserir: ");
                    aluno_nome = Console.ReadLine() ?? string.Empty;
                    Console.Write("\n\n");

                    Console.WriteLine("Escolha a disciplina: ");
                    Console.WriteLine("1 - Matematica");
                    Console.WriteLine("2 - Portugues");
                    Console.WriteLine("3 - Quimica");
                    opcao_cadeira = Console.ReadLine() ?? string.Empty;
                    string disciplina = string.Empty;
                    switch (opcao_cadeira)
                    {
                        case "1":
                            disciplina = "Matematica";
                            break;
                        case "2":
                            disciplina = "Portugues";
                            break;
                        case "3":
                            disciplina = "Quimica";
                            break;
                    }

                    Console.Clear();
                    Console.WriteLine($"Indique a nota do/a {aluno_nome} para {disciplina}: ");
                    string? notaStr = Console.ReadLine() ?? string.Empty;
                    nota_aluno = Int32.Parse(notaStr);

                    if (!Cadeiras.ContainsKey(aluno_nome))
                    {
                        Cadeiras[aluno_nome] = new Dictionary<string, int>();
                    }

                    Cadeiras[aluno_nome][disciplina] = nota_aluno;
                }
                else if (menu == 2)
                {
                    Console.Clear();
                    foreach (var aluno in Cadeiras)
                    {
                        Console.WriteLine("NOME: " + aluno.Key);
                        foreach (var disciplina in aluno.Value)
                        {
                            Console.WriteLine("Disciplina: " + disciplina.Key + " - Nota: " + disciplina.Value);
                        }
                        Console.WriteLine("---------------------------");
                    }
                    flag = false;
                }
                else if (menu == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Introduza o nome do aluno a procurar: ");
                    string? nomeProcurado = Console.ReadLine() ?? string.Empty;

                    if (Cadeiras.ContainsKey(nomeProcurado))
                    {
                        Console.WriteLine($"O aluno {nomeProcurado} está inscrito nas seguintes disciplinas:");
                        foreach (var disciplina in Cadeiras[nomeProcurado])
                        {
                            Console.WriteLine("Disciplina: " + disciplina.Key + " - Nota: " + disciplina.Value);
                        }

                        double media = Cadeiras[nomeProcurado].Values.Average();
                        Console.WriteLine($"Média do aluno {nomeProcurado}: {media}");
                    }
                    else
                    {
                        Console.WriteLine($"O aluno {nomeProcurado} não está inscrito em nenhuma disciplina.");
                    }
                    flag = false;
                }

                if (flag)
                    Console.Clear();

                Console.WriteLine("----MENU----");
                Console.WriteLine("1 - Introduzir Nomes e Notas de Alunos.");
                Console.WriteLine("2 - Exibir Notas e Alunos");
                Console.WriteLine("3 - Procurar Aluno e Verificar Disciplinas");
                Console.WriteLine("4 - Sair.");
                Console.Write("Opcao: ");
                string? menu_2 = Console.ReadLine() ?? string.Empty;
                menu = Int32.Parse(menu_2);
                flag = true;
            }
        }
    }
    public class Escolha_menu
    {
        static int Main()
        {
            Console.WriteLine("1 - Ex_1 ou 2 - Ex_2?");
            string? escolha = Console.ReadLine() ?? string.Empty;
            if(escolha == "1")
                Exercício_1.Ex_1();
            else if(escolha == "2")
                Exercício_2.Ex_2();
            else
                return 1;
            return 0;
        }
    }
}

