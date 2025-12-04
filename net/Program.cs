using System;
public class CreditCard
{
    public string Accountnumber;
    private decimal balance;

    public CreditCard(string accountnumber, decimal initialbalance)
    {
        Accountnumber = accountnumber;
        balance = initialbalance;

    }
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"На карту {Accountnumber} внесено {amount} руб. ");

        }
        else
        { Console.WriteLine("Сумма пополнения должна быть больше нуля"); }


    }
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма снятия должна быть больше нуля");
        }
        else if (amount > balance)
        {

            Console.WriteLine("Недостаточно средств");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"С карты {Accountnumber} снято {amount} руб. ");
        }
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Номер карточки: {Accountnumber}, баланс карточнки: {balance} руб. ");
    }

}
class Program

{
    static void Main()
    {


        CreditCard card1 = new CreditCard("1234-5678-9999", 100);
        CreditCard card2 = new CreditCard("1234-5678-8888", 200);
        CreditCard card3 = new CreditCard("1234-5678-7777", 300);
        Console.WriteLine("Начальное состояние всех карт: ");
        card1.PrintInfo();
        card2.PrintInfo();
        card3.PrintInfo();


        card1.Deposit(200);
        card2.Deposit(100);
        card3.Withdraw(50);

        Console.WriteLine("Текущее состояние всех карточек:");
        card1.PrintInfo();
        card2.PrintInfo();
        card3.PrintInfo();
    }





}



