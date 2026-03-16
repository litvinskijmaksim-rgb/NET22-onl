using ConsoleApp8.Interfaces;
using ConsoleApp8.Models;


namespace ConsoleApp8.Notifiers;


public class ConsoleNotifier : INotifier
{
    public void Send(Order order)
    {
        Console.WriteLine($" Уведомление отправлено на {order.CustomerEmail}");
        Console.WriteLine($" Текст: Спасибо за заказ {order.ProductName}!");
    }
}