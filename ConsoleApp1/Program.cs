using System;

namespace AnimalProgram
{
    
    abstract class Animal
    {
        public string Name { get; set; }

        
        public void SetName(string name)
        {
            Name = name;
        }

        
        public string GetName()
        {
            return Name;
        }

       
        public abstract void Eat();
    }

    
    class Dog : Animal
    {
        
        public override void Eat()
        {
            Console.WriteLine($"{Name} ест корм.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Dog dog = new Dog();

            
            Console.WriteLine("Введите имя собаки:");
            string dogName = Console.ReadLine();

            
            dog.SetName(dogName);

            
            Console.WriteLine($"Имя собаки: {dog.GetName()}");

            
            dog.Eat();

            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}