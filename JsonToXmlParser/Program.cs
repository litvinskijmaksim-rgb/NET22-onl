using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

namespace JsonToXmlParser
{
    // Классы данных
    public class Squad
    {
        public string SquadName { get; set; }
        public string HomeTown { get; set; }
        public int Formed { get; set; }
        public string SecretBase { get; set; }
        public bool Active { get; set; }
        public List<Member> Members { get; set; }
    }

    public class Member
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecretIdentity { get; set; }
        public List<string> Powers { get; set; }
    }

    // Основной класс программы
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для парсинга JSON в XML");
            Console.WriteLine("==================================");

            try
            {
                Console.Write("Введите путь к папке с JSON файлом: ");
                string folderPath = Console.ReadLine();

                ProcessJsonFolder(folderPath);

                Console.WriteLine("\nОперация завершена успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void ProcessJsonFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException($"Папка не найдена: {folderPath}");

            string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

            if (jsonFiles.Length == 0)
                throw new FileNotFoundException($"В папке {folderPath} не найдено JSON файлов");

            if (jsonFiles.Length > 1)
            {
                Console.WriteLine("\nНайдено несколько JSON файлов:");
                for (int i = 0; i < jsonFiles.Length; i++)
                    Console.WriteLine($"{i + 1}. {Path.GetFileName(jsonFiles[i])}");

                Console.Write("\nВыберите номер файла для обработки (1-" + jsonFiles.Length + "): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= jsonFiles.Length)
                    ProcessJsonFile(jsonFiles[choice - 1]);
                else
                    throw new ArgumentException("Неверный выбор файла");
            }
            else
            {
                ProcessJsonFile(jsonFiles[0]);
            }
        }

        static void ProcessJsonFile(string filePath)
        {
            Console.WriteLine($"\nОбработка файла: {Path.GetFileName(filePath)}");

            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length == 0)
                throw new InvalidDataException("JSON файл пуст");

            string jsonContent = File.ReadAllText(filePath);

            Squad squad;
            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                squad = JsonSerializer.Deserialize<Squad>(jsonContent, options);

                if (squad == null)
                    throw new InvalidDataException("Не удалось десериализовать JSON");
            }
            catch (JsonException ex)
            {
                throw new InvalidDataException($"Некорректный JSON формат: {ex.Message}");
            }

            Console.WriteLine($"Успешно распарсен отряд: {squad.SquadName}");
            Console.WriteLine($"Количество членов: {squad.Members?.Count ?? 0}");

            ConvertToXml(squad);
        }

        static void ConvertToXml(Squad squad)
        {
            try
            {
                string safeSquadName = string.Join("_", squad.SquadName.Split(Path.GetInvalidFileNameChars()));
                string xmlFileName = $"{safeSquadName}.xml";

                XmlSerializer serializer = new XmlSerializer(typeof(Squad));

                string outputFolder = Path.Combine(Environment.CurrentDirectory, "Output");
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                string outputPath = Path.Combine(outputFolder, xmlFileName);

                using (StreamWriter writer = new StreamWriter(outputPath))
                    serializer.Serialize(writer, squad);

                Console.WriteLine($"XML файл сохранен: {outputPath}");
                Console.WriteLine("\nИнформация о сохраненном файле:");
                Console.WriteLine($"Имя файла: {xmlFileName}");
                Console.WriteLine($"Размер: {new FileInfo(outputPath).Length} байт");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при сохранении XML: {ex.Message}");
            }
        }
    }
}
