using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1 — Гонка данных");
            Console.WriteLine("2 — Producer–Consumer");
            Console.WriteLine("0 — Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine() ?? "0";

            switch (choice)
            {
                case "1":
                    RaceConditionDemo.Run();
                    break;
                case "2":
                    ProducerConsumerDemo.Run();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
    }
}
