namespace SortNumbers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a list of numbers separated by comma");
        string input = Console.ReadLine();

        if(input == null)
        {
            Console.WriteLine("Invalid input");
            return;
        }
        
        List<double> numbers = input
            .Split(',')
            .Where(x => double.TryParse(x, out _))
            .Select(double.Parse).ToList();

        numbers.Sort();

        Console.WriteLine("Sorted numbers: ");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}