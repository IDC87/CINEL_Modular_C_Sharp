using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using System.Linq;
using System.Globalization;

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

//namespace Despesas_de_casa
//{
    public class Despesas
    {
        public string s_tipo_despesa {get; set;}
        public string s_data_despesa {get; set;}
        public string s_data_pagamento {get; set;}
        public decimal d_montante {get; set;}
        public int dias_restantes {get; set;}
    }

    public class Gestao_despesas
    {
        public static void DisplayDespesas(List<Despesas> despesas)
        {
            Console.WriteLine("Lista das Despesas:");
            
            foreach (Despesas despesa in despesas)
            {
                Console.WriteLine($"Tipo Despesa: {despesa.s_tipo_despesa}");
                Console.WriteLine($"Data Despesa: {despesa.s_data_despesa}");
                Console.WriteLine($"Data Pagamento: {despesa.s_data_pagamento}");
                Console.WriteLine($"Montante: {despesa.d_montante}€");
                Console.WriteLine($"Dias até ao pagamento: {despesa.dias_restantes} dias");
                Console.WriteLine();
            }
        }

        public static void ExportDespesas(List<Despesas> despesas, string filePath)
        {
            using (StreamWriter exportar = new StreamWriter(filePath))
            {
                exportar.WriteLine("Lista das Despesas:");
                exportar.WriteLine();
                
                foreach (Despesas despesa in despesas)
                {
                    exportar.WriteLine($"Tipo Despesa: {despesa.s_tipo_despesa}");
                    exportar.WriteLine($"Data Despesa: {despesa.s_data_despesa}");
                    exportar.WriteLine($"Data Pagamento: {despesa.s_data_pagamento}");
                    exportar.WriteLine($"Montante: {despesa.d_montante}€");
                    exportar.WriteLine($"Dias até ao pagamento: {despesa.dias_restantes} dias");
                    exportar.WriteLine();
                }

            }
        }
    }
    
    public class Tipo_Despesa
    {
        public string? atual_despesa;
        public int n_despesa = 1;
        public List <Despesas> despesas = new List <Despesas>();

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
               
                atual_despesa = Program.read_all_input('2');
                
                if(atual_despesa == "2")
                    break;
                else
                {                    
                    /* if (despesas.Any(d => d.s_tipo_despesa == atual_despesa))
                    {
                        Console.Clear();
                        Program.title();
                        Console.ForegroundColor = ConsoleColor.DarkRed;            
                        Program.transform_italic("      Despesa já introduzida!", 1);
                        Console.ResetColor();
                        Thread.Sleep(900);
                    }
                    else
                    { */
                        Despesas novaDespesa = new Despesas
                        {
                            s_tipo_despesa = atual_despesa
                        };
                        despesas.Add(novaDespesa);   
                        n_despesa++;
                        Data_Despesa.data_despesa(despesas, novaDespesa.s_tipo_despesa);
                        Data_Pagamento.data_pagamento(despesas, novaDespesa.s_tipo_despesa);
                        Montante.montante_despesa(despesas, novaDespesa.s_tipo_despesa);
                    //}
                }
            }
            Console.Clear();  
            Gestao_despesas.DisplayDespesas(despesas);
            string filePath = "contas.txt";
            Gestao_despesas.ExportDespesas(despesas, filePath);            
            Console.ReadKey();            
        }
    }

    public class Data_Despesa
    {
        public static void data_despesa(List<Despesas> despesas, string despesa_atual)
        {
            Console.Clear();            
            Program.title();           
            string s_data = Program.inserir_data($"Data de inicio da despesa {despesa_atual}");  
            Despesas despesa = despesas.FirstOrDefault(d => d.s_tipo_despesa == despesa_atual);
            if (despesa != null)
                despesa.s_data_despesa = s_data;            

        }
    }

    public class Data_Pagamento
    {
        public static void data_pagamento(List<Despesas> despesas, string despesa_atual)
        {
            while (true)
            {
                Console.Clear();            
                Program.title();           
                string s_data = Program.inserir_data($"Data de pagamento da despesa {despesa_atual}");  
                Despesas despesa = despesas.FirstOrDefault(d => d.s_tipo_despesa == despesa_atual);
                if (despesa != null)
                    despesa.s_data_pagamento = s_data;
                if(((Program.convert_date(despesa.s_data_pagamento)) - (Program.convert_date(despesa.s_data_despesa))) < 0) 
                {
                    Console.Clear();
                    Program.title();
                    Console.ForegroundColor = ConsoleColor.DarkRed;            
                    Program.transform_italic("Data de pagamento não pode ser mais antiga que a data da despesa!", 1);
                    Console.ResetColor();
                    Thread.Sleep(2500);                                   
                }
                else
                {
                    int pagamento = (int)Program.convert_date(despesa.s_data_pagamento);
                    int despesa_now = (int)Program.convert_date(despesa.s_data_despesa);
                    despesa.dias_restantes = pagamento - despesa_now;
                    despesa.dias_restantes = despesa.dias_restantes / 86400;                    
                    break;
                }
            }
        }
    }

    public class Montante
    {
        public static void montante_despesa(List<Despesas> despesas, string despesa_atual)
        {
            Console.Clear();
            Program.title();         
            Program.transform_bold($"        Qual o valor da despesa {despesa_atual} em €?", 1);
           
            Despesas despesa = despesas.FirstOrDefault(d => d.s_tipo_despesa == despesa_atual);
            if (despesa != null)
            {
                while (true)
                {
                    string montanteInput = Console.ReadLine() ?? string.Empty;
                    if (decimal.TryParse(montanteInput, out decimal montante))
                    {
                        despesa.d_montante = montante;
                        Console.WriteLine($"Montante atualizado: {despesa.d_montante}€");
                        Thread.Sleep(1200);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Program.title();
                        Console.ForegroundColor = ConsoleColor.DarkRed; 
                        Console.WriteLine("               Valor Inválido!");
                        Console.ResetColor();
                        Thread.Sleep(900);
                        Console.Clear();
                        Program.title();
                        Program.transform_bold($"        Qual o valor da despesa {despesa_atual} em €?", 1);
                    }
                }
            }
        }
    }

    public class Total_Despesas_ano
    {
        public static void DisplaySumByYear(List<Despesas> despesas)
        {
            var sumByYear = despesas.GroupBy(d => GetYear(d.s_data_despesa))
                                .Select(g => new { Year = g.Key, Sum = g.Sum(d => d.d_montante) });
            char c;
            Console.Clear();
            Program.title();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Program.transform_bold("Soma do Montante por Ano: (1 - para continuar, 2 - Sair)", 1);
            Console.ResetColor();
            foreach (var item in sumByYear)
            {
                Program.transform_bold("Ano: ", 0);
                Console.Write(item.Year + ",");
                 Program.transform_bold(" Acumulado: ", 0);
                Console.WriteLine(item.Sum + "€");                
                c = Program.read_key();
                if (c == '2')
                    break;
                else if(c == '1')
                    continue;
            }
        }
        private static int GetYear(string date)
        {
            if (DateTime.TryParse(date, out DateTime dateTime))
                return dateTime.Year;
            
            return 0; 
        }

    }


    public class Program
    {
        public static long convert_date(string str)
        {
            string format = "dd/MM/yyyy";
            DateTime date = DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = date.ToUniversalTime() - unixEpoch;
            long unixTime = (long)timeSpan.TotalSeconds;
            return unixTime;
        }

        public static string inserir_data(string str)
        {
            string day = "";
            string month = "";
            string year = "";
            bool flag = true;
            string full_date = "";

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
                            year = year.Substring(0, year.Length - 1);
                        
                        else if (month.Length > 0)
                            month = month.Substring(0, month.Length - 1);
                        
                        else if (day.Length > 0)
                            day = day.Substring(0, day.Length - 1);
                    }
                    else if (char.IsDigit(keyInfo.KeyChar))
                    {
                        if (day.Length < 2)                  
                            day += keyInfo.KeyChar;
                        else if (month.Length < 2)
                            month += keyInfo.KeyChar;
                        else if (year.Length < 4)
                            year += keyInfo.KeyChar;
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
            full_date = day + "/" + month + "/" + year;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            transform_bold("      Data Validada com sucesso!", 1);
            Console.ResetColor(); 
            Thread.Sleep(900);
            return full_date;
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
                
                if (pressedkey.Key == ConsoleKey.Backspace)
                {
                    if (str.Length > 0)
                    {
                        str.Length--;
                        Console.Write("\b \b"); 
                    }
                }
                else if (pressedkey.Key != ConsoleKey.Enter)
                {
                    str.Append(pressedkey.KeyChar);
                    Console.Write(pressedkey.KeyChar);
                    
                    if (str[0] == c)
                    {
                        Thread.Sleep(300);
                        return "2";
                    }
                }
            } while (pressedkey.Key != ConsoleKey.Enter);
            
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
            char menu_inicial;
            
            Console.Clear();
            title();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            transform_bold("1 - Adicionar Despesa", 1);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            transform_bold("2 - Visualizar o total de despesas por Ano", 1);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            transform_bold("3 - Visualizar o total de despesas tipo de Despesa", 1);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            transform_bold("4 - Sair\n", 0);
            Console.ResetColor();
            
            menu_inicial = read_key();
            Thread.Sleep(300);

            while(menu_inicial != '4')
            {
                if (menu_inicial == '1')
                    return 1;
                else if (menu_inicial == '2')
                    return 2;
                 else if (menu_inicial == '3')
                    return 3;
                else
                {
                    Console.Clear();
                    title();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    transform_italic("      Opção Errada!\n", 1);
                    Console.ResetColor();
                    Thread.Sleep(900);
                    Console.Clear();
                    title();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    transform_bold("1 - Adicionar Despesa", 1);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    transform_bold("2 - Visualizar o total de despesas por Ano", 1);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    transform_bold("3 - Visualizar o total de despesas tipo de Despesa", 1);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    transform_bold("4 - Sair\n", 0);
                    Console.ResetColor();

                    menu_inicial = read_key();
                    Thread.Sleep(300);
                }
            }
            return 4;
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
            Console.Clear(); // COMENTAR ISTO PARA VER OS WARNINGS
            title();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Tipo_Despesa tipoDespesa = new Tipo_Despesa();
            int menuOption = Menu();

            while(true)
            {
                if (menuOption == 1)
                {                
                    title();
                    tipoDespesa.despesa();  
                    menuOption = Menu();
                              
                }
                else if (menuOption == 2)
                {
                    if (tipoDespesa.n_despesa == 1)
                    {
                        Console.Clear();
                        title();
                        transform_bold("Nenhuma despesa ainda inserida", 1);
                        Thread.Sleep(900);
                        menuOption = Menu();                        
                    }
                    else                    
                        Total_Despesas_ano.DisplaySumByYear(tipoDespesa.despesas);
                }
                else if (menuOption == 3)
                {
                    if (tipoDespesa.n_despesa == 1)
                    {
                        Console.Clear();
                        title();
                        transform_bold("Nenhuma despesa ainda inserida", 1);
                        Thread.Sleep(900);
                        menuOption = Menu();                        
                    }

                }
                else if (menuOption == 4)
                {
                    break;

                }
            }

            Credits();
        }
    }
//}

        

    