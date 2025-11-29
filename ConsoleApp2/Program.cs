using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число N: ");
        int N = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(" Числа от N до 1:");
        for (int i = N; i >= 1; i--)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("2. Последовательность кратных 7:");

        for (int i = 7; i <= 100; i += 7)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("3. Последовательность Фибоначчи:");

        if (N >= 1)
        {
            long a = 0, b = 1;
            Console.Write(a + " ");

            if (N >= 2)
            {
                Console.Write(b + " ");
            }

            for (int i = 3; i <= N; i++)
            {
                long next = a + b;
                Console.Write(next + " ");
                a = b;
                b = next;
            }
        }

        Console.WriteLine();
    }
}
