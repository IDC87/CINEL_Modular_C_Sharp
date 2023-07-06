using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;

//  Contas: 
//     - rendas ou prestação mensais
//     - Água
//     - Luz
//     - Internet
//     - telemóvel

// tipo de despesa
// data da despesa
// data de pagamento
// montante

// Black
// DarkBlue
// DarkGreen
// DarkCyan
// DarkRed
// DarkMagenta
// DarkYellow
// Gray
// DarkGray
// Blue
// Green
// Cyan
// Red
// Magenta
// Yellow
// White

namespace Despesas_de_casa
{
    public class Tipo_Despesa
    {
        public string? tipo_despesa;
        private int n_despesa = 1;
        public List <string> despesas = new List <string>();

        public void despesa()
        {
            while(true)
            {
                Console.Clear();
                Program.title();
                Console.ForegroundColor = ConsoleColor.DarkGray;                
                Program.transform_bold($"        Qual a {n_despesa}ª despesa?", 0);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Program.transform_italic(" (Sair - 2)", 1);
                Console.ResetColor();                
               
                tipo_despesa = Program.read_all_input('2');
                
                if(tipo_despesa == "2")
                    break;
                else
                {                    
                    if (despesas.Contains(tipo_despesa))
                    {
                        Console.Clear();
                        Program.title();
                        Console.WriteLine("Despesa já introduzida!");  
                        Console.ReadKey(); 
                    }
                    else
                    {
                        despesas.Add(tipo_despesa);   
                        n_despesa++;
                        Data_Despesa.data_despesa(despesas[^1]);
                    }
                }

            }
            /* Console.Clear();
            foreach(string element in despesas)
                Console.WriteLine(element); */
        }
    }

    public class Data_Despesa
    {
        public static void data_despesa(string despesa_atual)
        {
            Console.Clear();
            Program.title();           
            Program.inserir_data($"Data de inicio da despesa {despesa_atual}");
            


        }



    }

    public class Data_Pagamento
    {

    }

    public class Montante
    {

    }

    public class Program
    {
        public static void inserir_data(string str)
        {
            //Console.WriteLine("Enter a date in the format DD/MM/YYYY:");
            string day = "";
            string month = "";
            string year = "";
            bool flag = true;

            Program.transform_bold(str + " " + FormatDate(day, month, year), 1);

            while(flag == true)
            {
                while (true)
                {  
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                    if (keyInfo.Key == ConsoleKey.Enter && year.Length == 4)
                        break;

                    if (keyInfo.Key == ConsoleKey.Backspace)
                    {
                        if (year.Length > 0)
                        {
                            year = year.Substring(0, year.Length - 1);
                        }
                        else if (month.Length > 0)
                        {
                            month = month.Substring(0, month.Length - 1);
                        }
                        else if (day.Length > 0)
                        {
                            day = day.Substring(0, day.Length - 1);
                        }
                    }
                    else if (char.IsDigit(keyInfo.KeyChar))
                    {
                        if (day.Length < 2)
                        {                   
                            day += keyInfo.KeyChar;
                        }
                        else if (month.Length < 2)
                        {
                            month += keyInfo.KeyChar;
                        }
                        else if (year.Length < 4)
                        {
                            year += keyInfo.KeyChar;
                        }
                    }

                    Console.Clear();
                    Program.title();
                    Program.transform_bold(str + " " + FormatDate(day, month, year), 1);
                }
                if (!validar_data(day, month, year))
                {
                    Console.Clear();
                    Program.title();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("      Data Inválida, insira novamente!");
                    Console.ResetColor();  
                    Thread.Sleep(1000);
                    Console.Clear();
                    Program.title();                   
                    day = "";
                    month = "";
                    year = "";    
                    Program.transform_bold(str + " " + FormatDate(day, month, year), 1);       
                }
                else
                    flag = false;
            }
            Console.WriteLine("Entered Date: " + FormatDate(day, month, year));
        }

        static string FormatDate(string day, string month, string year)
        {
            return $"{day.PadRight(2, '_')}/{month.PadRight(2, '_')}/{year.PadRight(4, '_')}";
        }

        static bool validar_data(string day, string month, string year)
        {
            int year_int = Int16.Parse(year);
            int month_int = Int16.Parse(month);
            int day_int = Int16.Parse(day);

            if (year_int < 1970 || year_int > 2025)
                return false;
            if (month_int < 1 || month_int > 12)
                return false;
            if (day_int > 31)
                return false;

            if (month_int == 2)
                {
                    if (IsLeapYear(year_int))
                    {
                        if (day_int > 29)
                            return false;
                    }
                    else
                    {
                        if (day_int > 28)
                            return false;
                    }
                }
                else if (month_int == 4 || month_int == 6 || month_int == 9 || month_int == 11)
                {
                    if (day_int > 30)
                        return false;
                }
                return true;
        }
        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
        
        public static void title()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            transform_bold("---------- GESTÃO DE CONTAS DOMÉSTICAS ---------\n", 1);            
            Console.ResetColor();
        }

        // Isto serve para converter o input string para int e validar que nao da erro caso o input seja uma string em vez de um int
        public static int read_and_convert()
        { 
            string str = Console.ReadLine() ?? string.Empty;
            bool isINT = int.TryParse(str, out _); 
            
            if(isINT)
            {
                int num = Int16.Parse(str);
                return num;
            }
            else
                return 0;           
        }

        // permite nos menus introduzir apenas a opcao sem ter necessidade de carregar enter
        public static char read_key()
        {
            char c;
            ConsoleKeyInfo keypressed = Console.ReadKey(intercept: true);
            c = keypressed.KeyChar;

            return c;
        }

        // funcao que guarda todo o readInput e vai mostrando no terminal o que e escrito mas faz o que a funcao read_key tmb faz
        public static string read_all_input(char c)
        {
            
            StringBuilder str = new StringBuilder();
            ConsoleKeyInfo pressedkey;
            do
            {
                pressedkey = Console.ReadKey(intercept: true);
                if (pressedkey.Key != ConsoleKey.Enter)
                {
                    str.Append(pressedkey.KeyChar);
                    Console.Write(pressedkey.KeyChar);
                    if(str[0] == c)
                    {
                        Thread.Sleep(300);
                        return "2";
                    }
                }
            }while(pressedkey.Key != ConsoleKey.Enter);
            string UserStr = str.ToString();
            Console.WriteLine(UserStr);
            return UserStr;
        }

        public static void transform_italic(string str, int flag)
        {
            if (flag == 1)
            Console.WriteLine($"\x1B[3m{str}\x1B[0m");
            else
                Console.Write($"\x1B[3m{str}\x1B[0m");
        }

        public static void transform_bold(string str, int flag)
        {
            if (flag == 1)
            Console.WriteLine($"\x1B[1m{str}\x1B[0m");
            else
                Console.Write($"\x1B[1m{str}\x1B[0m");
        }        

        static int Menu()
        {
            Console.Clear();
            title();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            title();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1 - Adicionar Despesa");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("2 - Sair\n");
            Console.ResetColor();
            
            char menu_inicial = read_key();
            Thread.Sleep(300);

            while(menu_inicial != '2')
            {
                if (menu_inicial == '1')
                    return 1;
                else if (menu_inicial != '2')
                {
                    Console.Clear();
                    title();
                    Console.WriteLine("Opção Errada!\n");

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("1 - Adicionar Despesa");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("2 - Sair\n");
                    Console.ResetColor();

                    menu_inicial = read_key();
                    Thread.Sleep(300);
                }
            }
            return 0;
        }

        static void Credits()
        {
            Console.Clear();
            title();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            transform_bold("MADE BY: ", 1);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string signature = @"
             _   _      _    _______
            | | | |    | |  /  ___  \  
            | | | |    | | /  /   \  \
            | | \ \    / / |  |   |  |
            | |  \ \__/ /  \  \___/  /
            |_|   \____/    \_______/
                ";
            Console.WriteLine(signature);
        }
        static void Main(string[] args)
        {
            if (Menu() == 1)
            {
                //Console.Clear();
                Tipo_Despesa tipoDespesa = new Tipo_Despesa();
                title();
                tipoDespesa.despesa();
            }

            Credits();

        

        


        }
    }
    
}