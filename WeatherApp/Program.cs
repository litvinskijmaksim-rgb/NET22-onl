using System;
using System.Net;
using System.Globalization;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ПРОГРАММА ДЛЯ ПОЛУЧЕНИЯ ПОГОДЫ");



            string city = "Minsk";


            string apiKey = "28155c2b5e85c6bf434fa6ee7d58cd60";


            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=ru";

            Console.WriteLine($"Запрашиваем погоду для города: {city}");


            try
            {

                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;


                string json = client.DownloadString(url);


                int tempIndex = json.IndexOf("\"temp\":") + 7;
                int tempEndIndex = json.IndexOf(",", tempIndex);
                string tempStr = json.Substring(tempIndex, tempEndIndex - tempIndex);

                float temperature = float.Parse(tempStr, CultureInfo.InvariantCulture);


                int descIndex = json.IndexOf("\"description\":\"") + 15;
                int descEndIndex = json.IndexOf("\"", descIndex);
                string description = json.Substring(descIndex, descEndIndex - descIndex);


                int humidityIndex = json.IndexOf("\"humidity\":") + 11;
                int humidityEndIndex = json.IndexOf(",", humidityIndex);
                string humidityStr = json.Substring(humidityIndex, humidityEndIndex - humidityIndex);
                int humidity = int.Parse(humidityStr);


                Console.WriteLine("===== РЕЗУЛЬТАТ =====");
                Console.WriteLine($"Город: {city}");
                Console.WriteLine($"Температура: {temperature}°C");
                Console.WriteLine($"Погода: {description}");
                Console.WriteLine($"Влажность: {humidity}%");
                Console.WriteLine("=====================");
            }
            catch (Exception error)
            {
                Console.WriteLine("ОШИБКА!");
                Console.WriteLine($"Что-то пошло не так: {error.Message}");
                Console.WriteLine("\nПодробности ошибки:");
                Console.WriteLine($"Тип ошибки: {error.GetType().Name}");

                if (error.Message.Contains("формат"))
                {
                    Console.WriteLine("\nСОВЕТ: Проблема с форматом числа!");
                    Console.WriteLine("API возвращает числа с точкой (например -7.81)");
                    Console.WriteLine("а программа ожидает с запятой (-7,81)");
                }

                Console.WriteLine("\nПроверьте:");
                Console.WriteLine("1. Есть ли интернет");
                Console.WriteLine("2. Правильный ли API ключ");
                Console.WriteLine("3. Попробуйте позже");
            }

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}