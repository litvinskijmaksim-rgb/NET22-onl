class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("+ - сложение");
        Console.WriteLine("- - вычитание");
        Console.WriteLine("* - умножение");
        Console.WriteLine("/ - деление");
        Console.WriteLine("% - процент от числа");
        Console.WriteLine("sqrt - квадратный корень");
        Console.Write("Ваш выбор: ");

        string operation = Console.ReadLine();
        double result = 0;
        if (operation == "+")
        {
            Console.WriteLine("Введите первое число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            double b = Convert.ToDouble(Console.ReadLine());
            result = a + b;
            Console.WriteLine("Ответ: " + result);
        }
        else if (operation == "-")
        {
            Console.WriteLine("Введите первое число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            double b = Convert.ToDouble(Console.ReadLine());
            result = a - b;
            Console.WriteLine("Ответ: " + result);
        }
        else if (operation == "*")
        {
            Console.WriteLine("Введите первое число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            double b = Convert.ToDouble(Console.ReadLine());
            result = a * b;
            Console.WriteLine("Ответ: " + result);
        }
        else if (operation == "/")
        {
            Console.WriteLine("Введите первое число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            double b = Convert.ToDouble(Console.ReadLine());
            result = a / b;
            Console.WriteLine("Ответ: " + result);

        }
        else if (operation == "%")
        {
            Console.WriteLine("Введите число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите процент : ");
            double percent = Convert.ToDouble(Console.ReadLine());
            result = (a * percent) / 100;
            Console.WriteLine("Ответ: " + result);
        }
        else if (operation == "sqrt")
        {
            // КВАДРАТНЫЙ КОРЕНЬ
            Console.Write("Введите число: ");
            double a = Convert.ToDouble(Console.ReadLine());

            if (a < 0)
            {
                Console.WriteLine("Ошибка: нельзя извлечь корень из отрицательного числа!");
            }
            else
            {
                result = Math.Sqrt(a);
                Console.WriteLine("Квадратный корень из " + a + " = " + result);
                Console.WriteLine("Ответ: " + result);
            }
        }
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();

    }
}
