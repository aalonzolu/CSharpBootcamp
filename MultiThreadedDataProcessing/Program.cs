using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MultiThreadedDataProcessing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] data = Enumerable.Range(1, 1000).ToArray(); // Sample data

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await ProcessDataAsync(data);

            stopwatch.Stop();
            Console.WriteLine($"Processing completed in {stopwatch.ElapsedMilliseconds} milliseconds.");
        }

        static async Task<int[]> ProcessDataAsync(int[] data)
        {
            const int chunkSize = 100; // Define the chunk size

            int chunkCount = data.Length / chunkSize;
            Task<int>[] processingTasks = new Task<int>[chunkCount];

            for (int i = 0; i < chunkCount; i++)
            {
                // Create Chunk from chunkSize
                int[] chunk = data.Skip(i * chunkSize).Take(chunkSize).ToArray();
                // process the chunk
                processingTasks[i] = ProcessChunkAsync(chunk);
            }
            
            Console.WriteLine($"Chunks count: {chunkCount}");

            return await Task.WhenAll(processingTasks);
        }

        static async Task<int> ProcessChunkAsync(int[] chunk)
        {
            await Task.Delay(100);
            return chunk.Sum();
        }
    }
}