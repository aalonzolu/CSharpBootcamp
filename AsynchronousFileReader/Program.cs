using System;
using System.IO;
using System.Threading.Tasks;

namespace AsynchronousFileReader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // filePath aalonzo.txt in the same directory as the project
                string filePath = "../../../files/aalonzo.txt";
                string fileContents = await File.ReadAllTextAsync(filePath);
                Console.WriteLine("File contents:");
                Console.WriteLine(fileContents);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unknown error occurred: {ex.Message}");
            }
        }
    }
}