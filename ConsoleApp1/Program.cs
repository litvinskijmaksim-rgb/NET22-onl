using System;
using System.Collections.Generic;

class Program
{

    static string text = @"Wow! This is my 1st tsest. Do you see number42? Yes! 
Otto ran to room101. Anna loves level99. 
Are you ready? No, I am not! 
This sentence has no comma. But this one, definitely has a comma, right? 
Hey! Look at Bob — he found 777 coins! 
Is 12345 the longest digit-word? Maybe! 
Otto said: ""Wow!"" Anna replied: ""Yes!"" 
Final test. Done!";

    static void Main()
    {
        Console.WriteLine("Программа для анализа текста");


        while (true)
        {

            ShowMenu();


            string choice = Console.ReadLine();


            ProcessChoice(choice);
        }
    }


    static void ShowMenu()
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("ВЫБЕРИТЕ ДЕЙСТВИЕ:");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("1 - Найти слова с максимальным количеством цифр");
        Console.WriteLine("2 - Найти самое длинное слово и сколько раз оно встречается");
        Console.WriteLine("3 - Заменить цифры на слова");
        Console.WriteLine("4 - Показать сначала вопросы, потом восклицания");
        Console.WriteLine("5 - Показать предложения без запятых");
        Console.WriteLine("6 - Найти слова, где первая и последняя буква одинаковые");
        Console.WriteLine("7 - Поиск слов по части слова");
        Console.WriteLine("8 - Найти палиндромы");
        Console.WriteLine("0 - Выйти из программы");
        Console.WriteLine(new string('=', 50));
        Console.Write("Ваш выбор: ");
    }


    static void ProcessChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                FindWordsWithMostDigits();
                break;
            case "2":
                FindLongestWord();
                break;
            case "3":
                ReplaceDigitsWithWords();
                break;
            case "4":
                ShowQuestionsAndExclamations();
                break;
            case "5":
                ShowSentencesWithoutCommas();
                break;
            case "6":
                FindWordsSameStartEnd();
                break;
            case "7":
                SearchByPart();
                break;
            case "8":
                FindPalindromes();
                break;
            case "0":
                Console.WriteLine("Выход из программы...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Неверный выбор! Попробуйте снова.");
                break;
        }

        Console.WriteLine("\nНажмите Enter чтобы продолжить...");
        Console.ReadLine();
    }

    // 1. Найти слова с максимальным количеством цифр
    static void FindWordsWithMostDigits()
    {
        Console.WriteLine("\n=== Слова с максимальным количеством цифр ===");

        // Получаем все слова из текста
        string[] words = GetWordsFromText();

        int maxDigits = 0;
        List<string> resultWords = new List<string>();

        // Перебираем все слова
        foreach (string word in words)
        {
            int digitCount = CountDigitsInWord(word);


            if (digitCount > maxDigits)
            {
                maxDigits = digitCount;
                resultWords.Clear();
                resultWords.Add(word);
            }

            else if (digitCount == maxDigits && digitCount > 0)
            {
                resultWords.Add(word);
            }
        }


        if (resultWords.Count > 0)
        {
            Console.WriteLine($"Максимальное количество цифр: {maxDigits}");
            Console.WriteLine($"Слова: {string.Join(", ", resultWords)}");
        }
        else
        {
            Console.WriteLine("Слова с цифрами не найдены");
        }
    }


    static void FindLongestWord()
    {
        Console.WriteLine("\n=== Самое длинное слово ===");

        string[] words = GetWordsFromText();

        if (words.Length == 0)
        {
            Console.WriteLine("Слова не найдены");
            return;
        }


        string longestWord = "";
        foreach (string word in words)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }


        int count = 0;
        foreach (string word in words)
        {
            if (word == longestWord)
            {
                count++;
            }
        }

        Console.WriteLine($"Самое длинное слово: '{longestWord}'");
        Console.WriteLine($"Длина: {longestWord.Length} букв");
        Console.WriteLine($"Встречается раз: {count}");
    }

    // 3. Заменить цифры на слова
    static void ReplaceDigitsWithWords()
    {
        Console.WriteLine("\n=== Замена цифр на слова ===");

        string result = "";


        foreach (char c in text)
        {
            switch (c)
            {
                case '0': result += "ноль"; break;
                case '1': result += "один"; break;
                case '2': result += "два"; break;
                case '3': result += "три"; break;
                case '4': result += "четыре"; break;
                case '5': result += "пять"; break;
                case '6': result += "шесть"; break;
                case '7': result += "семь"; break;
                case '8': result += "восемь"; break;
                case '9': result += "девять"; break;
                default: result += c; break;
            }
        }

        Console.WriteLine("Текст после замены:");
        Console.WriteLine(result);
    }

    // 4. Показать вопросы и восклицания
    static void ShowQuestionsAndExclamations()
    {
        Console.WriteLine("\n=== Вопросительные и восклицательные предложения ===");

        string[] sentences = GetSentencesFromText();

        Console.WriteLine("ВОПРОСЫ:");
        bool foundQuestions = false;
        foreach (string sentence in sentences)
        {
            if (sentence.EndsWith("?"))
            {
                Console.WriteLine($" - {sentence}");
                foundQuestions = true;
            }
        }
        if (!foundQuestions) Console.WriteLine("Вопросы не найдены");

        Console.WriteLine("\nВОСКЛИЦАНИЯ:");
        bool foundExclamations = false;
        foreach (string sentence in sentences)
        {
            if (sentence.EndsWith("!"))
            {
                Console.WriteLine($" - {sentence}");
                foundExclamations = true;
            }
        }
        if (!foundExclamations) Console.WriteLine("Восклицания не найдены");
    }

    // 5. Показать предложения без запятых
    static void ShowSentencesWithoutCommas()
    {
        Console.WriteLine("\n=== Предложения без запятых ===");

        string[] sentences = GetSentencesFromText();

        bool found = false;
        foreach (string sentence in sentences)
        {

            if (!sentence.Contains(","))
            {
                Console.WriteLine($" - {sentence}");
                found = true;
            }
        }

        if (!found) Console.WriteLine("Предложения без запятых не найдены");
    }

    // 6. Найти слова с одинаковыми первой и последней буквой
    static void FindWordsSameStartEnd()
    {
        Console.WriteLine("\n=== Слова с одинаковыми первой и последней буквой ===");

        string[] words = GetWordsFromText();
        List<string> result = new List<string>();

        foreach (string word in words)
        {

            if (word.Length > 0)
            {

                char firstLetter = char.ToLower(word[0]);
                char lastLetter = char.ToLower(word[word.Length - 1]);


                if (firstLetter == lastLetter)
                {
                    result.Add(word);
                }
            }
        }

        if (result.Count > 0)
        {
            Console.WriteLine($"Найдено слов: {result.Count}");
            Console.WriteLine($"Слова: {string.Join(", ", result)}");
        }
        else
        {
            Console.WriteLine("Такие слова не найдены");
        }
    }

    // 7. Поиск по части слова
    static void SearchByPart()
    {
        Console.WriteLine("\n=== Поиск по части слова ===");
        Console.Write("Введите часть слова для поиска: ");
        string search = Console.ReadLine().ToLower(); // Переводим в нижний регистр

        if (string.IsNullOrEmpty(search))
        {
            Console.WriteLine("Вы ничего не ввели!");
            return;
        }

        string[] words = GetWordsFromText();
        List<string> result = new List<string>();

        foreach (string word in words)
        {

            if (word.ToLower().Contains(search))
            {
                result.Add(word);
            }
        }

        if (result.Count > 0)
        {
            Console.WriteLine($"Найдено слов: {result.Count}");
            Console.WriteLine($"Слова: {string.Join(", ", result)}");
        }
        else
        {
            Console.WriteLine("Совпадений не найдено");
        }
    }

    // 8. Найти палиндромы
    static void FindPalindromes()
    {
        Console.WriteLine("\n=== Поиск палиндромов ===");

        string[] words = GetWordsFromText();
        List<string> palindromes = new List<string>();

        foreach (string word in words)
        {

            if (word.Length >= 2 && IsAllLetters(word))
            {

                string reversed = "";
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    reversed += word[i];
                }


                if (word.ToLower() == reversed.ToLower())
                {
                    palindromes.Add(word);
                }
            }
        }

        if (palindromes.Count > 0)
        {
            Console.WriteLine($"Найдено палиндромов: {palindromes.Count}");
            Console.WriteLine($"Палиндромы: {string.Join(", ", palindromes)}");
        }
        else
        {
            Console.WriteLine("Палиндромы не найдены");
        }
    }



    // Получить все слова из текста
    static string[] GetWordsFromText()
    {
        List<string> words = new List<string>();
        string currentWord = "";

        foreach (char c in text)
        {
            // Если символ - буква или цифра, добавляем к текущему слову
            if (char.IsLetterOrDigit(c))
            {
                currentWord += c;
            }
            else
            {
                // Если нашли слово, добавляем в список
                if (currentWord.Length > 0)
                {
                    words.Add(currentWord);
                    currentWord = "";
                }
            }
        }

        // Добавляем последнее слово если есть
        if (currentWord.Length > 0)
        {
            words.Add(currentWord);
        }

        return words.ToArray();
    }

    // Получить все предложения из текста
    static string[] GetSentencesFromText()
    {
        List<string> sentences = new List<string>();
        string currentSentence = "";

        foreach (char c in text)
        {
            currentSentence += c;

            // Если символ - конец предложения
            if (c == '.' || c == '!' || c == '?')
            {
                sentences.Add(currentSentence.Trim());
                currentSentence = "";
            }
        }

        // Добавляем последнее предложение если есть
        if (currentSentence.Length > 0)
        {
            sentences.Add(currentSentence.Trim());
        }

        return sentences.ToArray();
    }

    // Посчитать цифры в слове
    static int CountDigitsInWord(string word)
    {
        int count = 0;
        foreach (char c in word)
        {
            if (char.IsDigit(c))
            {
                count++;
            }
        }
        return count;
    }

    // Проверить что слово состоит только из букв
    static bool IsAllLetters(string word)
    {
        foreach (char c in word)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }
}
