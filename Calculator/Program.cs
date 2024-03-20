
namespace BootcampCalculator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the calculator program!");
        Console.WriteLine("Please enter two numbers");

        Console.Write("First number: ");
        
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out _))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        double firstNumber = double.Parse(input);

        Console.Write("Second number: ");
        input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out _))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        double secondNumber = double.Parse(input);

        Console.WriteLine("Please select the operation to perform:");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");


        double result = double.NaN;
        int operation = 0;
        while (operation is <= 0 or > 4)
        {
            Console.Write("Enter the number of the operation: ");
            operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    result = Calculator.Add(firstNumber, secondNumber);
                    break;
                case 2:
                    result = Calculator.Subtract(firstNumber, secondNumber);
                    break;
                case 3:
                    result = Calculator.Multiply(firstNumber, secondNumber);
                    break;
                case 4:
                    result = Calculator.Divide(firstNumber, secondNumber);
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }

        Console.WriteLine($"The result is: {result}");
    }
}

