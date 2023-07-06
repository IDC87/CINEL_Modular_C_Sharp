using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a date in the format DD/MM/YYYY:");
        string day = "";
        string month = "";
        string year = "";

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Enter)
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

            // Update the displayed format
            Console.Clear();
            Console.WriteLine("Indique a data de inicio da despesa (DD/MM/YYYY)");
            Console.WriteLine("Current Date: " + FormatDate(day, month, year));
        }
        if (!validar_data(day, month, year)) Console.WriteLine("DATA INVALIDA!!");
        

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

        if (year_int < 1970 && year_int > 2025)
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
}