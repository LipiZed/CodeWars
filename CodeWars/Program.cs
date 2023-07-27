using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.XPath;


internal class Program
{
    private static void Main(string[] args)
    {
        var x = DateTime.Now;
        for (int i = 0; i < 250; i++)
        {
            Console.WriteLine(SqCubRevPrime(i));
        }
        Console.WriteLine(DateTime.Now.Subtract(x));
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
    }*/ // НЕ РЕШЕНО!!! 4 уровень. Задача на разложение числа на сумму квадратов без повторений
    /*public static string FirstNonRepeatingLetter(string s)
    {
        //Уже поздно не понимаю че я тут наговнокодил, вроде как беру чар, меняю его на точку и если такой же чар есть в строке то значит идем далее, и все
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
    }*/ //РЕШЕНО!!! 5 уровень. Задача на поиск первой неповторяющейся буквы
    /*public static BigInteger perimeter(BigInteger n)
    {
        Решение туповатое, теперь уже понимаю можно было бы нахуй и без массива обойтись, ну оно работает и по времени прошло, значит нормально
        Считаю числа фибоначчи и кидаю их в массив
        var fib = new BigInteger[(int)(n + 1)];
        BigInteger res = 0;
        fib[0] = 1;
        fib[1] = 1;
        for (int i = 2; i < n + 1; i++)
        {
            fib[i] = fib[i - 1] + fib[i - 2];
        }
        Суммирую все числа фибоначчи из массива
        foreach (var item in fib)
        {
            res += item;
        }
        Умножаю сумму на 4
        return res * 4;
    }*/ // РЕШЕНО!!! 5 уровень. Периметр фигуры, построенной из квадратов со стороной как числа фибоначи

    /*
    public static string formatDuration(int seconds) 
    {
        //Ну тут в целом тупейшие вычисления для которых и комментарии не нужны, в целом по названиям переменных можно все понять
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
    } */ // РЕШЕНО!!! 4 уровень. Задача на получение строки с датой из секунд а-ля "лет, дней, часов, минут, секунд"
         //Это просто какой-то пиздец а не вывод, или кучу ифов продолжай писать, или покумекай с массивами и кортежами, может перечисления помогут, авось, еще исправь косяк с выводом нуля 
         //Нихуя не массив ни кортеж кстати не помог, помог только храни его бог чат гпт

    /*public static string Add(string a, string b)
    {
        BigInteger x = BigInteger.Parse(a);
        BigInteger y = BigInteger.Parse(b);
        return (x + y).ToString(); // Fix this!
    }*/ // РЕШЕНО!!! 4 уровень. Сумма огромных чисел
    /*public static string StripComments(string text, string[] commentSymbols)
    {
        //Разбиваю строку на подстроки по переносам
        var strings = text.Split('\n');
        // Этими циклами ищу индексы данных символов в строке, и выбираю минимальный индекс
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
            //Сношу все что идет после этого индекса вместе с ним, и убираю лишние пробелы которые могли появиться
            strings[i] = strings[i].Substring(0, min_index);
            strings[i] = strings[i].TrimEnd(' ');
        }
        //Восстанавливаю изначальный вид строки добавляя переносы
        string result = string.Empty;
        foreach (var item in strings)
        {
            result += item + "\n";
        }
        //Тут убираю лишний перенос в конце
        return result.Substring(0, result.Length - 1);
    }*/ // РЕШЕНО!!! 4 уровень. Ката по убиранию из строки всего после конченых данных символов. Вот эти каты конченые, в которых линку за 3 строки, я ебал, надо учить линку

    /*public static BigInteger fib(int n)
    {
        //Тут комментариев не будет так как я сам не ебу как оно работает, эта проклятая математика меня чуть не убила а еще закодить её это вообще пиздец
        //Так что спиздил все что мог, откуда мог, оно замечательно работает я доволен
        if (n == 0)
            return 0;

        int sign = (n < 0 && n % 2 == 0) ? -1 : 1;
        n = Math.Abs(n);
        BigInteger[][] F = Pow(new BigInteger[][] { new BigInteger[] { 1, 1 }, new BigInteger[] { 1, 0 } }, n, IdentityMatrix(2), MatrixMultiply);
        return sign * F[0][1];
    }

    static BigInteger[][] Pow(BigInteger[][] x, int n, BigInteger[][] I, Func<BigInteger[][], BigInteger[][], BigInteger[][]> mult)
    {
        if (n == 0)
            return I;
        else if (n == 1)
            return x;
        else if (n < 0)
        {
            BigInteger[][] y = Pow(x, -n, I, mult);
            y = InverseMatrix(y);
            return (n % 2 == 0) ? y : MatrixMultiply(y, x);
        }
        else
        {
            BigInteger[][] y = Pow(x, n / 2, I, mult);
            y = MatrixMultiply(y, y);
            if (n % 2 == 1)
                y = MatrixMultiply(x, y);
            return y;
        }
    }

    static BigInteger[][] IdentityMatrix(int n)
    {
        BigInteger[][] matrix = new BigInteger[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new BigInteger[n];
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                    matrix[i][j] = 1;
                else
                    matrix[i][j] = 0;
            }
        }
        return matrix;
    }

    static BigInteger[][] MatrixMultiply(BigInteger[][] A, BigInteger[][] B)
    {
        int n = A.Length;
        int m = B[0].Length;
        BigInteger[][] result = new BigInteger[n][];
        for (int i = 0; i < n; i++)
        {
            result[i] = new BigInteger[m];
            for (int j = 0; j < m; j++)
            {
                result[i][j] = 0;
                for (int k = 0; k < B.Length; k++)
                {
                    result[i][j] += A[i][k] * B[k][j];
                }
            }
        }
        return result;
    }

    static BigInteger[][] InverseMatrix(BigInteger[][] matrix)
    {
        BigInteger det = matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        BigInteger[][] inverse = new BigInteger[2][];
        inverse[0] = new BigInteger[] { matrix[1][1], -matrix[0][1] };
        inverse[1] = new BigInteger[] { -matrix[1][0], matrix[0][0] };
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                inverse[i][j] /= det;
            }
        }
        return inverse;
    }
    */ // РЕШЕНО!!! 3 уровень. Быстрейший способ вычисления чисел Фибоначчи, работает и с отрицательными значениями


    /*public static List<string> Top3(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) //Если вводят пустую строку, то выводить пустой список, но тут я обсерился и вывожу список с 3мя элементами, но решение приняло
        {
            List<string> result = new List<string> { " ", " ", " " };
            return result;
        }
        //Удаляю все возможные и невозможные символы из строки т.к они по заданию считаются пустыми местами
        s = s.Replace('/', ' ').Replace('\\', ' ').Replace('#', ' ').Replace('.', ' ').Replace(',', ' ').Replace('"', ' ').Replace('-', ' ').Replace('!', ' ').Replace('_', ' ').Replace(';', ' ').Replace('?', ' ').Replace('@', ' ').Replace('(', ' ').Replace(')', ' ').Replace(':', ' ').Replace("'''", " ").Replace(" \'", " ");
        List<string> list = new List<string>();
        //Жестрочайше пизжу код со стаковерфлоу который мне делает словарик из слов по частоте по убыванию
        var words = s
        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .GroupBy(w => w.ToLower())
        .OrderByDescending(g => g.Count());
        //Из этого словарика переношу все в список по ключу
        foreach (var word in words)
        {
            list.Add(word.Key);
        }
        //Убираю лишние элементы из списка до тех пор пока его длина не будет меньшле или равна 3м
        while (list.Count() > 3)
        {
            list.Remove(list.Last());
        }
        //Удаляю лишние символы которые вдруг что могли появиться
        list.Remove("\'");
        list.Remove(" ");
        return list;
    }*/ //РЕШЕНО!!!! 4 уровень. Ката по поиску 3х наиболее часто входящий слов в строку.


    //Надо бы начать писать более полные описания алгоритмов которые я делаю, чтобы потом если что подглядывать, сейчас этим и займусь.
    //УПД: допилил комменты

    private static Dictionary<int, List<uint>> memoizedResults = new Dictionary<int, List<uint>>();

    public static uint SqCubRevPrime(int n)
    {
        List<uint> result = new List<uint>();
        if (n == 0) 
        {
            result.Add(0);
            memoizedResults[n] = result;
            return 0;
        }
        if (n == 1)
        {
            result.Add(89);
            memoizedResults[n] = result;
            return 89;
        }
        uint y = 0;
        if (memoizedResults.ContainsKey(n - 1))
        {
            result = memoizedResults[n - 1];
            y = memoizedResults[n - 1].Last();
        }
        uint num = 0;
        for (uint i = y + 1 ; i < int.MaxValue; i++)
        {
            ulong x = i * i;
            ulong x1 = x * i;
            x = ulong.Parse(x.ToString().Reverse().ToArray());
            x1 = ulong.Parse(x1.ToString().Reverse().ToArray());
            if (IsPrime(x) && IsPrime(x1))
            {
                result.Add(i);
                if (result.Count == n)
                {
                    num = result.Last();
                    break;
                }
            }
        }
        memoizedResults[n] = result;
        return num;
    }

    static bool IsPrime(ulong number)
    {
        if (number < 2) return false;
        if (number == 2 || number == 3) return true;
        if (number % 2 == 0 || number % 3 == 0) return false;

        ulong i = 5;
        ulong w = 2;

        while (i * i <= number)
        {
            if (number % i == 0) return false;
            i += w;
            w = 6 - w;
        }

        return true;
    }
}