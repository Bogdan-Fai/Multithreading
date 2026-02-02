using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public static class ProducerConsumerDemo
{
    public static void Run()
    {
        Console.WriteLine("\n--- Задание 2: Producer–Consumer ---");

        var queue = new BlockingCollection<int>(boundedCapacity: 100);
        var cts = new CancellationTokenSource();

        Console.WriteLine("Нажмите любую клавишу для остановки...");
        Task.Run(() =>
        {
            Console.ReadKey();
            cts.Cancel();
        });

        // Producer
        Task producer = Task.Run(() =>
        {
            for (int i = 1; i <= 50; i++)
            {
                if (cts.IsCancellationRequested)
                    break;

                queue.Add(i);
                Console.WriteLine($"Produced: {i}");
                Thread.Sleep(50);
            }
            queue.CompleteAdding();
        });

        // Consumers
        Task[] consumers = new Task[3];
        for (int i = 0; i < consumers.Length; i++)
        {
            consumers[i] = Task.Run(() =>
            {
                try
                {
                    foreach (var item in queue.GetConsumingEnumerable(cts.Token))
                    {
                        int result = item * 2;
                        Thread.Sleep(100);
                        Console.WriteLine($"Consumer {Task.CurrentId} processed: {item} -> {result}");
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine($"Consumer {Task.CurrentId} canceled");
                }
            }, cts.Token);
        }

        Task.WaitAll(consumers);
        Console.WriteLine("Все задачи завершены.");
    }
}
