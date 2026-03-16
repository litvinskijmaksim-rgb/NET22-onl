using ConsoleApp8.Models;


namespace ConsoleApp8.Interfaces;


public interface IOrderRepository
{
    void Save(Order order);  
}