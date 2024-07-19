namespace Calculator;

public class Calculator
{
    private int[] _numbers;

    public int[] Numbers
    {
        get => _numbers;
        set
        {
            _numbers = value;
        }
    }

    public Calculator()
    {
        // pytanie ile liczb bedzie miało działanie
        string userInput;
        int userInputNumber;
        int userNumber;
        string sign;
        
        do
        {
            Console.WriteLine("How many numbers will your mathematical action have?: " );
            userInput = Console.ReadLine();
        } while (!int.TryParse(userInput, out userNumber));
        
        Numbers = new int[userNumber];
        
        
        // Wybranie działania
        
        do
        {
            Console.WriteLine("Choose your mathematical operation (+, -, *, /): ");
            sign = Console.ReadLine();
        } while (sign != "+" && sign != "-" && sign != "/" && sign != "*");

        string operation = "";
        // Dodawnie liczb do array
        for (int i = 0; i < Numbers.Length; i++)
        {
            Console.WriteLine($"\nEnter {i + 1} number: ");
            do
            {
                userInput = Console.ReadLine();
            } while (!int.TryParse(userInput, out userInputNumber));

            if (i == Numbers.Length -1)
                operation += $"{userInputNumber} ";
                
            else
                operation += $"{userInputNumber} {sign} ";
            
            Console.Write("\n" + operation);
            Numbers[i] = userInputNumber;
        }

        switch (sign)
        {
            case "+":
                Console.Write($"= {Numbers.Sum()}");
                break;
            
            case "-":
                Console.WriteLine($"= {Subtraction()}");
                break;
            
            case "*":
                Console.WriteLine($"= {Multiplication()}");
                break;
            
            case "/":
                Console.WriteLine($"= {Division()}");
                break;
            default:
                Console.WriteLine("Nieprawidłowy znak");
                break;
                
        }
        

    }
    private double Subtraction()
    {
        double result = 0;
        foreach (var number in Numbers)
        {
            if (result != 0)
            {
                result -= number;
            }

            else
            {
                result = number;
            }
        }
        
        return result;
    }
    
    private double Multiplication()
    {
        double result = 0;
        foreach (var number in Numbers)
        {
            if (result != 0)
            {
                result *= number;
            }

            else
            {
                result = number;
            }
        }
        
        return result;
    }
    
    private double Division()
    {
        double result = Numbers[0];
        for (int i = 1; i < Numbers.Length; i++)
        {
            if (Numbers[i] == 0)
            {
                Console.WriteLine("Error: Division by zero.");
                return 0;  // lub zgłoś wyjątek
            }
            result /= Numbers[i];
        }
        return result;
    }
    
}