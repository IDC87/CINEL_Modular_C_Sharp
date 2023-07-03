using System.IO;
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        string? historial = "3porcos.txt";
        string historial2 = "3porcos.txt";

        using (StreamReader leitor = new StreamReader(historial))
        {
            string linha;
            while((linha = leitor.ReadLine()) != null)
                Console.WriteLine(linha);
        }

        using(StreamWriter escritor = File.AppendText(historial))
            escritor.WriteLine("E O LOBO MAU COMEU OS A TODOS!");

        using (StreamReader leitor = new StreamReader(historial2))
        {
            string linha;
             while((linha = leitor.ReadLine()) != null)
                Console.WriteLine(linha);                
        }

        Console.ReadKey();
    }
}
