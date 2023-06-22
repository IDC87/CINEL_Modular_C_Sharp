using System;
using System.Threading;

class Exercise1
{
    public static void Run()
    {
        Console.WriteLine("Exercise 1");
        Console.WriteLine("Introduza o valor da Temperatura: ");
        int temp = Convert.ToInt32(Console.ReadLine());
        if(temp < 0)
            Console.Write("Tempo Gelado\n"); 
        else if (temp <= 10)
            Console.Write("Tempo Muito Frio\n"); 
        else if (temp <= 20)
            Console.Write("Tempo frio\n"); 
        else if (temp <= 30)
            Console.Write("Tempo Normal\n");
        else if (temp <= 40)
            Console.Write("Tempo Quente\n");
        else
            Console.Write("Tempo Muito Quente\n");

        Console.WriteLine("\n");
    }
}
class Exercise2
{
    public static void Run()
    {
        Console.WriteLine("Exercise 2");
        Console.WriteLine("Introduza o valor da Altura ");
        string? alturaString = Console.ReadLine();
        Console.WriteLine("Introduza o valor do Peso ");
        string? pesoString = Console.ReadLine();
        float altura, peso;
        altura = float.TryParse(alturaString, out float parsedAltura) ? parsedAltura : 0f;
        peso = float.TryParse(pesoString, out float parsedPeso) ? parsedPeso : 0f;

        float IMC = peso / (altura * altura); 
        Console.WriteLine(); 
        
        if(IMC < 16.9)            
            Console.WriteLine("Muito abaixo do peso");           
        else if (IMC > 16.9 && IMC <= 18.4)
            Console.WriteLine("Abaixo do peso");        
        else if (IMC > 18.4 && IMC <= 24.9)
            Console.WriteLine("Peso Normal");
        else if (IMC >= 25 && IMC <= 29.9)
            Console.WriteLine("Acima do peso");
        else if (IMC >= 30 && IMC <= 34.9)
            Console.WriteLine("Obesidade grau I");
        else if (IMC >= 35 && IMC <= 40)
            Console.WriteLine("Obesidade grau II");
        else
            Console.WriteLine("Obesidade grau III");
        
        Console.WriteLine("IMC: {0:F2}", IMC);      
    }
}
class Exercise3
{
    public static void Run()
    {
        Console.WriteLine("Exercise 3");
        Random  aleatorio = new Random();            
        int row = 0;
        int col = 0;
        int col_sum = 0;

        for( row = 0; row < 20; row++)
        {
            col_sum = 0;   
            for( col = 0; col < 20; col++)
            {
                int k = aleatorio.Next(9);
                Console.Write(k);
                col_sum = col_sum + k;
            }
            Console.Write(" ->" + col_sum);
            Console.WriteLine();
        }        
    }
}
class Exercise4
{
    public static void Run()
    {
        Console.WriteLine("Exercise 4");
        Console.WriteLine("\nIntroduza um numero inteiro: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int i = 1;
        int quadrado = 1;
        int soma_quadrados = 0;
        while(i <= n)
        {
            quadrado = i * i;
            soma_quadrados = soma_quadrados + quadrado;
            i++;            
        }
        Console.WriteLine("Soma dos quadrados = " + soma_quadrados);        
    }
}
class Exercise5
{
    public static void Run()
    {
        Random  randomARR = new Random();
        int[] Z = new int [500];
        Console.WriteLine("\nIntroduza um numero inteiro (1 - 100): ");
        int find = Convert.ToInt32(Console.ReadLine());
        int find_count = 0;
        Console.WriteLine("Exercise 5");
        for(int l = 0; l < 500; l++)
        {
            Z[l] = randomARR.Next(100) + 1;
            if (find == Z[l])
                find_count++;;
             Console.Write(Z[l]+ ",");
        }
        Console.WriteLine();
        Console.WriteLine("\nNumero " + find + " Encontrado " + find_count + " vezes!" );
    }
}

class Program
{
    static void Main(string[] args)
    {
        string? input;     

        do
        {
           // Console.Clear();
            Console.WriteLine("Which exercise to run (1 to 5) quit('x')?: ");
            input = Console.ReadLine();

            if(input == "1")
            {
                Console.Clear();                
                Exercise1.Run();
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

            }
            else if(input == "2")
            {                
                Console.Clear();                
                Exercise2.Run();
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
                
            else if(input == "3")
            {
                Console.Clear();                
                Exercise3.Run();
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else if(input == "4")
            {
                Console.Clear();                
                Exercise4.Run();
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else if(input == "5")
            {
                Console.Clear();                
                Exercise5.Run();
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }while(!(input == "x"));
            
    }
}







