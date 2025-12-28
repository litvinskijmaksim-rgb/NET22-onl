using System;

public class Pair<S, T>
{

    private readonly S first;
    private readonly T second;


    public Pair(S firstValue, T secondValue)
    {
        first = firstValue;
        second = secondValue;
    }


    public S First
    {
        get { return first; }
    }

    public T Second
    {
        get { return second; }
    }
}


public class ComparablePair<T, U> : IComparable<ComparablePair<T, U>>
    where T : IComparable<T>
    where U : IComparable<U>
{

    private readonly T first;
    private readonly U second;


    public ComparablePair(T firstValue, U secondValue)
    {
        first = firstValue;
        second = secondValue;
    }


    public T First
    {
        get { return first; }
    }

    public U Second
    {
        get { return second; }
    }


    public int CompareTo(ComparablePair<T, U> other)
    {
        if (other == null)
        {

            return 1;
        }


        int firstComparison = this.first.CompareTo(other.first);


        if (firstComparison != 0)
        {
            return firstComparison;
        }


        return this.second.CompareTo(other.second);
    }
}


class Program
{
    static void Main()
    {

        Console.WriteLine("=== Пример 1: Простая пара ===");
        Pair<string, int> person = new Pair<string, int>("Иван", 25);
        Console.WriteLine($"Имя: {person.First}, Возраст: {person.Second}");


        Console.WriteLine("\n=== Пример 2: Сравнимые пары ===");


        ComparablePair<int, string> pair1 = new ComparablePair<int, string>(1, "яблоко");
        ComparablePair<int, string> pair2 = new ComparablePair<int, string>(1, "банан");
        ComparablePair<int, string> pair3 = new ComparablePair<int, string>(2, "апельсин");


        Console.WriteLine($"pair1 и pair2: {pair1.CompareTo(pair2)}");
        Console.WriteLine($"pair2 и pair1: {pair2.CompareTo(pair1)}");
        Console.WriteLine($"pair1 и pair3: {pair1.CompareTo(pair3)}");
        Console.WriteLine($"pair3 и pair1: {pair3.CompareTo(pair1)}");


        Console.WriteLine("\n=== Пример 3: Сортировка ===");
        ComparablePair<int, string>[] pairs = new ComparablePair<int, string>[]
        {
            new ComparablePair<int, string>(3, "зима"),
            new ComparablePair<int, string>(1, "весна"),
            new ComparablePair<int, string>(2, "лето"),
            new ComparablePair<int, string>(1, "осень")
        };

        Console.WriteLine("До сортировки:");
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.First}: {pair.Second}");
        }


        Array.Sort(pairs);

        Console.WriteLine("\nПосле сортировки:");
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.First}: {pair.Second}");
        }
    }
}



