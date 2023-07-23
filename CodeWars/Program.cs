using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.XPath;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
    }

    /*public static string decompose(long n)
    {
        List<long> list = new List<long>();
        long x = n * n; // Получаем квадрат исходного числа


        TODO: Нужно переделать этот алгоритм чтобы он не выдавал вариантов с повторами, как это сделать пока не понятно, но можешь поп
        робовать рекурсию, авось поможет

        while (x != 0)
        {
            list.Add(n - 1); // Добавляем исход - 1 в результирующий список (Эту часть надо переделать т.к иногда не подходит)
            x = x - ((n - 1) * (n - 1)); // Вычитаем из квадрата исходника, квадрат подходящего числа
            while (n * n > x) // Получаем n, квадрат которого будет меньше полученного икса
            {
                n = n - 1;
            }
            n = n + 1; // Прибавляем для корретного отображения в ответе

        }

        list.Reverse();
        string result = string.Empty;
        foreach (var item in list)
        {
            result += item.ToString() + " ";
        }
        return result.TrimEnd();
    }*/ //Задача на разложение числа на сумму квадратов без повторений
    /*public static string FirstNonRepeatingLetter(string s)
    {
        List<char> d = new List<char>();
        string lower_string = s.ToLower();
        foreach (var item in lower_string)
        {
            d.Add(item);
        }
        for (int i = 0; i < d.Count(); i++)
        {
            char x = d[i];
            d[i] = '.';
            if (d.Contains(x))
            {
                d[i] = x;
                continue;
            }
            else
            {
                return s[i].ToString();
            }
        }
        return string.Empty;
    }*/ //Задача на поиск первой неповторяющейся буквы
    /*public static BigInteger perimeter(BigInteger n)
    {
        var fib = new BigInteger[(int)(n + 1)];
        BigInteger res = 0;
        fib[0] = 1;
        fib[1] = 1;
        for (int i = 2; i < n + 1; i++)
        {
            fib[i] = fib[i - 1] + fib[i - 2];
        }
        foreach (var item in fib)
        {
            res += item;
        }
        return res * 4;
    }*/ //Периметр фигуры, построенной из квадратов со стороной как числа фибоначи

    /*
    public static string formatDuration(int seconds) 
    {
        if (seconds < 0)
        {
            return "Bruh";
        }
        if (seconds == 0)
        {
            return "now";
        }
        if (seconds < 60)
        {
            if (seconds == 1)
            {
                return "1 second";
            }
            return $"{seconds} seconds";
        }
        if (seconds < 3600)
        {
            string result = string.Empty;
            int minutes = (int)Math.Floor((double)(seconds / 60));
            int left_seconds = seconds - minutes * 60;
            List<int> time = new List<int> { 0, 0, 0, minutes, left_seconds };
            return FormatTime(time);
            
        }
        if (seconds < 86400)
        {
            string result = string.Empty;
            int hours = (int)Math.Floor((double)(seconds / 3600));
            int left_minutes = (seconds - hours * 3600);
            int minutes = (int)Math.Floor((double)(left_minutes / 60));
            int left_seconds = left_minutes - minutes * 60;
            List<int> time = new List<int> { 0, 0, hours, minutes, left_seconds };
            return FormatTime(time);
        }
        if (seconds < 31536000)
        {
            string result = string.Empty;
            int days = (int)Math.Floor((double)(seconds / 86400));
            int left_hours = (seconds - days * 86400);
            int hours = (int)Math.Floor((double)(left_hours / 3600));
            int left_minutes = (left_hours - hours * 3600);
            int minutes = (int)Math.Floor((double)(left_minutes / 60));
            int left_seconds = left_minutes - minutes * 60;
            List<int> time = new List<int> { 0, days, hours, minutes, left_seconds };
            return FormatTime(time);
        }
        if (seconds > 31536000)
        {
            string result = string.Empty;
            int years = (int)Math.Floor((double)(seconds / 31536000));
            int left_days = seconds - years * 31536000;
            int days = (int)Math.Floor((double)(left_days / 86400));
            int left_hours = (left_days - days * 86400);
            int hours = (int)Math.Floor((double)(left_hours / 3600));
            int left_minutes = (left_hours - hours * 3600);
            int minutes = (int)Math.Floor((double)(left_minutes / 60));
            int left_seconds = left_minutes - minutes * 60;
            List<int> time = new List<int> { years, days, hours, minutes, left_seconds };
            return FormatTime(time);
        }
        return null;
    }

    public static string FormatTime(List<int> timeValues)
    {
        List<string> timeUnits = new List<string> { "year", "day", "hour", "minute", "second" };
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < timeValues.Count; i++)
        {
            int timeValue = timeValues[i];

            if (timeValue > 0)
            {
                string unit = timeUnits[i];
                if (result.Length > 0)
                {
                    result.Append(", ");
                }

                result.Append(timeValue);
                result.Append(" ");
                result.Append(timeValue == 1 ? unit : unit + "s");
            }
        }

        string output = result.ToString();
        int lastCommaIndex = output.LastIndexOf(",");
        if (lastCommaIndex >= 0)
        {
            output = output.Remove(lastCommaIndex, 1).Insert(lastCommaIndex, " and");
        }

        return output;
    } */ //Задача на получение строки с датой из секунд а-ля "лет, дней, часов, минут, секунд"
         //Это просто какой-то пиздец а не вывод, или кучу ифов продолжай писать, или покумекай с массивами и кортежами, может перечисления помогут, авось, еще исправь косяк с выводом нуля 
         //Нихуя не массив ни кортеж кстати не помог, помог только храни его бог чат гпт

    /*public static string Add(string a, string b)
    {
        BigInteger x = BigInteger.Parse(a);
        BigInteger y = BigInteger.Parse(b);
        return (x + y).ToString(); // Fix this!
    }*/ //Легчайшая ката 4 уровня

    public static string StripComments(string text, string[] commentSymbols)
    {
        var strings = text.Split('\n');
        for (int i = 0; i < strings.Length; i++)
        {
            int min_index = strings[i].Length;
            for (int j = 0; j < commentSymbols.Length; j++)
            {
                if (strings[i].Contains(commentSymbols[j]))
                {
                    int index = strings[i].IndexOf(commentSymbols[j]);
                    if (index < min_index)
                    {
                        min_index = index;
                    }
                    
                }
                
            }
            strings[i] = strings[i].Substring(0, min_index);
            strings[i] = strings[i].TrimEnd(' ');
        }
        string result = string.Empty;
        foreach (var item in strings)
        {
            result += item + "\n";
        }
        return result.Substring(0, result.Length - 1);
    }


}