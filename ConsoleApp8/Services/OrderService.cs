using ConsoleApp8.Interfaces;
using ConsoleApp8.Models;


namespace ConsoleApp8.Services;


public class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly INotifier _notifier;

    
    public OrderService(IOrderRepository repository, INotifier notifier)
    {
        _repository = repository;
        _notifier = notifier;
    }

    public void CreateOrder(string productName, string email)
    {
        
        if (string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine(" Ошибка: Название товара не может быть пустым");
            return;
        }

       
        var order = new Order
        {
            ProductName = productName,
            CustomerEmail = email
        };

        
        _repository.Save(order);

        
        _notifier.Send(order);

        Console.WriteLine($" Готово! Заказ #{order.Id} создан");
    }
}