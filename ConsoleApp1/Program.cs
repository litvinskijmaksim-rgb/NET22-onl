class Programm
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите кол-во строк в матрице (n<6): ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите кол-во стобцов в матрице (m<6): ");
        int m = int.Parse(Console.ReadLine());
        if (n > 6)
        {
            Console.WriteLine("Ошибка! Число строк не может быть больше 6! ");
            return;

        }
        else if (m > 6)
        {
            Console.WriteLine("Ошибка! Число столбцов не может быть больше 6!");
            return;
        }

        int[,] myArray = new int[n, m];
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                myArray[i, j] = rnd.Next(1, 101);
            }
        }
        int choice;
        do
        {
            Console.WriteLine("\n*** МЕНЮ ***");
            Console.WriteLine("1 - Показать матрицу");
            Console.WriteLine("2 - Найти максимальный элемент");
            Console.WriteLine("3 - Найти минимальный элемент");
            Console.WriteLine("4 - Посчитать сумму всех элементов");
            Console.WriteLine("5 - Посчитать среднее значение");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите действие: ");

            choice = Convert.ToInt32(Console.ReadLine());

            // Выполняем выбранное действие
            switch (choice)
            {
                case 1:
                    ShowMatrix(myArray, n, m);
                    break;
                case 2:
                    FindMax(myArray, n, m);
                    break;
                case 3:
                    FindMin(myArray, n, m);
                    break;
                case 4:
                    CalculateSum(myArray, n, m);
                    break;
                case 5:
                    CalculateAverage(myArray, n, m);
                    break;
                case 0:
                    Console.WriteLine("Выход из программы...");
                    break;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }

        } while (choice != 0); // Повторяем пока не выберут выход

    }
    static void ShowMatrix(int[,] mat, int rows, int cols)
    {
        Console.WriteLine("\nВаша матрица:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(mat[i, j] + "\t"); // Выводим элемент и табуляцию
            }
            Console.WriteLine(); // Переход на новую строку
        }
    }

    // Функция для поиска максимального элемента
    static void FindMax(int[,] mat, int rows, int cols)
    {
        int max = mat[0, 0];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i, j] > max)
                {
                    max = mat[i, j];
                }
            }
        }

        Console.WriteLine("Максимальный элемент: " + max);
    }

    // Функция для поиска минимального элемента
    static void FindMin(int[,] mat, int rows, int cols)
    {
        int min = mat[0, 0];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i, j] < min)
                {
                    min = mat[i, j];
                }
            }
        }

        Console.WriteLine("Минимальный элемент: " + min);
    }

    // Функция для подсчета суммы всех элементов
    static void CalculateSum(int[,] mat, int rows, int cols)
    {
        int sum = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum = sum + mat[i, j];
            }
        }

        Console.WriteLine("Сумма всех элементов: " + sum);
    }

    // Функция для подсчета среднего значения
    static void CalculateAverage(int[,] mat, int rows, int cols)
    {
        int sum = 0;
        int totalElements = rows * cols;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum = sum + mat[i, j];
            }
        }

        double average = (double)sum / totalElements;
        Console.WriteLine("Среднее значение: " + average.ToString("F2"));
    }
}







