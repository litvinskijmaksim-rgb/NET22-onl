using System;

public class Person
{
    private int age;

    public void SetAge(int age)
    {
        this.age = age;
    }

    public int GetAge()
    {
        return age;
    }

    public void Greet()
    {
        Console.WriteLine("Привет!");
    }
}

public class Student : Person
{
    public void Study()
    {
        Console.WriteLine("Я учусь");
    }

    public void ShowAge()
    {
        Console.WriteLine($"Мой возраст: {GetAge()} лет");
    }
}

public class Teacher : Person
{
    public void Explain()
    {
        Console.WriteLine("Я объясняю");
    }
}

public class StudentProfessorTest
{
    public static void Main(string[] args)
    {
        Person person = new Person();
        person.Greet();

        Student student = new Student();
        student.SetAge(20);
        student.Greet();
        student.ShowAge();
        student.Study();

        Teacher teacher = new Teacher();
        teacher.SetAge(35);
        teacher.Greet();
        teacher.Explain();
    }
}