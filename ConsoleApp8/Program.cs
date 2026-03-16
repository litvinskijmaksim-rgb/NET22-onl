using ConsoleApp8.Interfaces;
using ConsoleApp8.Notifiers;
using ConsoleApp8.Repositories;
using ConsoleApp8.Services;

namespace OrderApp;

class Program
{
    static void Main()
    {
        

        
        IOrderRepository repository = new SimpleOrderRepository();
        INotifier notifier = new ConsoleNotifier();

        
        var orderService = new OrderService(repository, notifier);

        
        while (true)  
        {
            Console.Write("\nВведите название товара (или 'exit' для выхода): ");
            var product = Console.ReadLine();

            if (product?.ToLower() == "exit") break;
            if (string.IsNullOrEmpty(product)) continue;

            Console.Write("Введите email: ");
            var email = Console.ReadLine();

            if (string.IsNullOrEmpty(email)) continue;

            
            orderService.CreateOrder(product, email);
        }

        Console.WriteLine("\nПока!");
    }
}
