using System;
using System.Diagnostics;
using System.Threading;

public static class RaceConditionDemo
{
    private static int counter;
    private static object lockObj = new object();

    public static void Run()
    {
        Console.WriteLine("\n--- Задание 1: Гонка данных ---");
        Console.Write("Введите количество потоков: ");
        int threadsCount = int.Parse(Console.ReadLine() ?? "4");

        Console.Write("Введите число инкрементов для каждого потока: ");
        int increments = int.Parse(Console.ReadLine() ?? "100");

        Console.Write("Выводить шаги? (y/n): ");
        bool showSteps = Console.ReadLine()?.ToLower() == "y";

        // Запуск всех методов последовательно с одинаковым количеством потоков
        RunIncrementTest(UnsafeIncrement, threadsCount, increments, showSteps, "UnsafeIncrement");
        RunIncrementTest(LockIncrement, threadsCount, increments, showSteps, "LockIncrement");
        RunIncrementTest(InterlockedIncrement, threadsCount, increments, showSteps, "InterlockedIncrement");
    }

    private static void RunIncrementTest(Action<int> incrementMethod, int threadsCount, int increments, bool showSteps, string methodName)
    {
        counter = 0;
        Stopwatch sw = Stopwatch.StartNew();

        Thread[] threads = new Thread[threadsCount];
        for (int i = 0; i < threadsCount; i++)
        {
            threads[i] = new Thread(() =>
            {
                for (int j = 0; j < increments; j++)
                {
                    incrementMethod(1);
                    if (showSteps)
                        Console.WriteLine($"{methodName} step: {counter}");
                }
            });
            threads[i].Start();
        }

        foreach (var t in threads)
            t.Join();

        sw.Stop();
        Console.WriteLine($"{methodName}:\nВремя: {sw.ElapsedMilliseconds} ms, Итоговое значение counter = {counter}");
    }

    private static void UnsafeIncrement(int n)
    {
        for (int i = 0; i < n; i++)
            counter++;
    }

    private static void LockIncrement(int n)
    {
        for (int i = 0; i < n; i++)
        {
            lock (lockObj)
            {
                counter++;
            }
        }
    }

    private static void InterlockedIncrement(int n)
    {
        for (int i = 0; i < n; i++)
            Interlocked.Increment(ref counter);
    }
}
