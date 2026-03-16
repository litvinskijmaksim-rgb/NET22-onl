using ConsoleApp8.Interfaces;
using ConsoleApp8.Models;


namespace ConsoleApp8.Repositories;


public class SimpleOrderRepository : IOrderRepository
{
    private int _nextId = 1;
    private List<Order> _orders = new();

    public void Save(Order order)
    {
        order.Id = _nextId++;
        _orders.Add(order);
        Console.WriteLine($" Заказ #{order.Id} сохранен в памяти");
    }
}