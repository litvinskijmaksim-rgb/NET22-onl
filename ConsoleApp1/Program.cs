using System;
public class Phone
{
    public string _number;
    public string _model;
    public double _weight;

    public Phone ()
    {
        Console.WriteLine("Создан телефон без параметров");
    }
    public Phone(string _number, string _model)
    {
        Console.WriteLine($"Создан телефон: номер {_number}, модель {_model}");
    }

    public Phone (string _number, string _model, double _weight) 
    
    {
        Console.WriteLine($"Создан телефон: номер: {_number}, модель: {_model}, вес: {_weight}");
    
    }
    public void ReceiveCall(string name)
    {
        Console.WriteLine($"Звонит {name}");
    }
    public void ReceiveCall (string name, string _number) 
    {
        Console.WriteLine($"Звонит {name} с телефона {_number}");
    }
    public string GetNumber()
    {
        return _number;
    }
    
        public void SendMessage(params string[] numbers)
    {
        Console.WriteLine("Отправляю сообщение на номера:");

        
        foreach (string num in numbers)
        {
            Console.WriteLine(num); 
        }
    }
}
class Program 
{
    static void Main()
    {
        Console.WriteLine("\tСоздание телефона");
        Phone phone1 = new Phone();
        phone1._number = "802976392785";
        phone1._model = "Samsung s10";
        phone1._weight = 195.0;

        Phone phone2 = new Phone("80295721084", "iphone11");

        Phone phone3 = new Phone("80299741185", "Xiomi Ultra",154);

        Console.WriteLine("\n ИНФОРМАЦИЯ О ТЕЛЕФОНАХ ");

        Console.WriteLine($"Телефон 1: Номер: {phone1._number}, Модель: {phone1._model}, Вес: {phone1._weight}");
        Console.WriteLine($"Телефон 2: Номер: {phone2._number}, Модель: {phone2._model}, Вес: {phone2._weight}");
        Console.WriteLine($"Телефон 3: Номер: {phone3._number}, Модель: {phone3._model}, Вес: {phone3._weight}");

        Console.WriteLine("\n ПРИЕМ ЗВОНКОВ ");

  
        Console.Write("Телефон 1: ");
        phone1.ReceiveCall("Анна");

        Console.Write("Телефон 2: ");
        phone2.ReceiveCall("Петя");

        Console.Write("Телефон 3: ");
        phone3.ReceiveCall("Маша");

        Console.WriteLine("\n ПОЛУЧЕНИЕ НОМЕРОВ ");

        
        Console.WriteLine($"Номер телефона 1: {phone1.GetNumber()}");
        Console.WriteLine($"Номер телефона 2: {phone2.GetNumber()}");
        Console.WriteLine($"Номер телефона 3: {phone3.GetNumber()}");

        Console.WriteLine("\n ПРИЕМ ЗВОНКА С НОМЕРОМ (перегруженный метод) ");

        
        phone1.ReceiveCall("Анна", "+375441111111");
        Console.WriteLine("\n=== ОТПРАВКА СООБЩЕНИЙ ===");

      
        Console.WriteLine("Отправка на 3 номера:");
        phone1.SendMessage("+375291111111", "+375292222222", "+375293333333");

        
        Console.WriteLine("\nОтправка на 1 номер:");
        phone1.SendMessage("+375294444444");

        
        Console.WriteLine("\nОтправка на 5 номеров:");
        phone1.SendMessage("111", "222", "333", "444", "555");
    }
}