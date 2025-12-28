
using System;


public class WrongLoginException : Exception
{

    public WrongLoginException()
        : base()
    {
    }


    public WrongLoginException(string message)
        : base(message)
    {
    }
}


public class WrongPasswordException : Exception
{

    public WrongPasswordException()
        : base()
    {
    }


    public WrongPasswordException(string message)
        : base(message)
    {
    }
}


public class Validator
{

    public static bool Validate(string login, string password, string confirmPassword)
    {
        try
        {

            if (login.Length >= 20)
            {

                throw new WrongLoginException("Логин должен быть меньше 20 символов");
            }


            if (login.Contains(" "))
            {

                throw new WrongLoginException("Логин не должен содержать пробелы");
            }


            if (password.Length >= 20)
            {

                throw new WrongPasswordException("Пароль должен быть меньше 20 символов");
            }


            if (password.Contains(" "))
            {

                throw new WrongPasswordException("Пароль не должен содержать пробелы");
            }


            bool hasDigit = false;


            foreach (char c in password)
            {

                if (char.IsDigit(c))
                {
                    hasDigit = true;
                    break;
                }
            }


            if (!hasDigit)
            {

                throw new WrongPasswordException("Пароль должен содержать хотя бы одну цифру");
            }


            if (password != confirmPassword)
            {

                throw new WrongPasswordException("Пароль и подтверждение пароля не совпадают");
            }


            return true;
        }
        catch (WrongLoginException)
        {

            return false;
        }
        catch (WrongPasswordException)
        {

            return false;
        }
    }
}


class Program
{
    static void Main()
    {


        // Тест 1: Все данные верны
        bool result1 = Validator.Validate("user123", "pass123", "pass123");
        Console.WriteLine("Тест 1: " + result1);

        // Тест 2: Логин слишком длинный
        bool result2 = Validator.Validate("очень_длинный_логин_больше_20", "pass123", "pass123");
        Console.WriteLine("Тест 2: " + result2);

        // Тест 3: Пароль без цифр
        bool result3 = Validator.Validate("user", "password", "password");
        Console.WriteLine("Тест 3: " + result3);

        // Тест 4: Пароли не совпадают
        bool result4 = Validator.Validate("user", "pass123", "pass456");
        Console.WriteLine("Тест 4: " + result4);
    }
}
