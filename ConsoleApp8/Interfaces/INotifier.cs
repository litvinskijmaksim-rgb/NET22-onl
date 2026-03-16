using ConsoleApp8.Models;


namespace ConsoleApp8.Interfaces;


public interface INotifier
{
    void Send(Order order);  
}