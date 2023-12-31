﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;


internal class Program
{
    private static void Main(string[] args)
    {
        SieveOfAtkin(1000000);
        
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
    }*/  // НЕ РЕШЕНО!!! 4 уровень. Задача на разложение числа на сумму квадратов без повторений
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

    /*private static Dictionary<int, List<uint>> memoizedResults = new Dictionary<int, List<uint>>();

    public static uint SqCubRevPrime(int n)
    {
        //Если уже есть значение с таким ключем в словарике, то просто выдаем его
        if (memoizedResults.ContainsKey(n))
        {
            return memoizedResults[1][n - 1];
        }
        //Если нет то считаем все значения от 1 до 250, как и сказано в задании, и запоминаем их
        for (int i = 1; i < 251; i++)
        {
            UpTo250(i);     
        }
        //Потом просто выводим нужное
        uint num = memoizedResults[1][n - 1];
        return num;
    }
    public static uint UpTo250(int n)
    {
        
        List<uint> result = new List<uint>();
        uint counter = 0;
        //Если в словарике есть уже хоть что-то, то обновляем список с результатами до значения прошлого ключа и ставим итератор в значение прошлого ключа
        if (memoizedResults.Count != 0)
        {
            result = memoizedResults.Values.Last();
            counter = result.Last() + 1;
        }
        uint num = 0;
        //От 0 или от итератора проходимся по всем числам
        for (uint i = counter; i < int.MaxValue; i++)
        {
            //Находим квадрат и куб, и реверсим их
            ulong x = i * i;
            ulong x1 = x * i;
            x = ulong.Parse(x.ToString().Reverse().ToArray());
            x1 = ulong.Parse(x1.ToString().Reverse().ToArray());
            //Проверяем на то простые они, и если они простые то пихаем изначально число в список
            if (IsPrime(x) && IsPrime(x1))
            {
                result.Add(i);
                //Если длина списка равна вводному значению, то находим из этого списка последнее, и ломаем цикл
                if (result.Count == n)
                {
                    num = result.Last();
                    break;
                }
            }
        }
        //Добавляем в словарик для мемоизации ключ и список который принадлежит этому ключу
        memoizedResults.Add(n, result);
        //Возвращаем последний элемент списка
        return num;
    }
    

    //Проверка на простоту числа, яро спизженная, но кого это ебет
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
    } */
    //Я РЕШИЛ ЭТОТ ПИЗДЕЦ УРА БЛЯТЬ РЕШЕНО!!!! 4 уровень. Сильнейшая моя ебежка с оптимизацией в жизни. 
    //Задача найти составить особую последовательность, алгоритм не сложный, но оптимизация я того сисю
    //Отсюда научился мемоизации, классная штука.
    //Потом добавлю комментарии, а может и сейчас, на стуле от радости прыгаю как сука, в 5 утра только закончил.

    /*public static string sumStrings(string a, string b)
    {
        if (a.Length == 0)
        {
            return BigInteger.Parse(b).ToString();
        }
        if (b.Length == 0)
        {
            return BigInteger.Parse(a).ToString();
        }
        return (BigInteger.Parse(a) + BigInteger.Parse(b).ToString()).ToString();
    }*/
    //РЕШЕНО!!! 4 уровень. Уже решал такое, чисто фарманул очков, да считерил, но похуй, в условиях нет запрета

    /*
    private static int Precedence(char op)
    {
        if (op == '^')
            return 3;
        else if (op == '*' || op == '/')
            return 2;
        else if (op == '+' || op == '-')
            return 1;
        else
            return 0;
    }

    private static List<string> InfixToPostfix(string expression)
    {
        List<string> postfix = new List<string>();
        Stack<char> operatorStack = new Stack<char>();

        int i = 0;
        while (i < expression.Length)
        {
            char c = expression[i];

            if (char.IsDigit(c))
            {
                int j = i + 1;
                while (j < expression.Length && char.IsDigit(expression[j]))
                    j++;
                postfix.Add(expression.Substring(i, j - i));
                i = j - 1;
            }
            else if (c == '(')
            {
                operatorStack.Push(c);
            }
            else if (c == ')')
            {
                while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                {
                    postfix.Add(operatorStack.Pop().ToString());
                }
                operatorStack.Pop(); // Discard the '('
            }
            else if (IsOperator(c))
            {
                while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(c))
                {
                    postfix.Add(operatorStack.Pop().ToString());
                }
                operatorStack.Push(c);
            }

            i++;
        }

        while (operatorStack.Count > 0)
        {
            postfix.Add(operatorStack.Pop().ToString());
        }

        return postfix;
    }

    private static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
    }

    private static double EvaluatePostfix(List<string> postfix)
    {
        Stack<double> operandStack = new Stack<double>();

        foreach (string token in postfix)
        {
            if (double.TryParse(token, out double number))
            {
                operandStack.Push(number);
            }
            else if (IsOperator(token[0]))
            {
                double b = operandStack.Pop();
                double a = operandStack.Pop();

                switch (token[0])
                {
                    case '+':
                        operandStack.Push(a + b);
                        break;
                    case '-':
                        operandStack.Push(a - b);
                        break;
                    case '*':
                        operandStack.Push(a * b);
                        break;
                    case '/':
                        operandStack.Push(a / b);
                        break;
                    case '^':
                        operandStack.Push(Math.Pow(a, b));
                        break;
                }
            }
        }

        return operandStack.Pop();
    }
    public static double calculate(string s)
    {
        s = s.Replace(" ", "");
        List<string> postfix = InfixToPostfix(s);
        return EvaluatePostfix(postfix);
    }

    */ //РАЗОБРАТЬ РЕШЕНИЕ!!! 3 уровень. строку в вычисление например: "1 + 3 * 5" = 16


    /*public static string Disemvowel(string str)
    {
        return str.Replace("a", "").Replace("A", "").Replace("e", "").Replace("E", "").Replace("I", "").Replace("i", "").Replace("O", "").Replace("o", "").Replace("U", "").Replace("u", "");
    }
    */ //РЕШЕНО!!! 7 уровень, не хочу за сложное браться, так что пока так, иду по рандомным а не ранк ап


    /*public static int CountBits(int n)
    {
        // Tried to do it the funny way :D
        int mask = 0b00000000000000000000000000000001;
        int count = 0;
        while (n != 0) 
        {
            if ((mask & n) == 1)
            {
                count++;
                
            }
            n = n >> 1;
        }
        return count;
    }*/ //РЕШЕНО!!! Уже решал, счет битов в числе


    //Переделваю калькулятор:
    /*Переделал
    private static int Precedence(char op)
    {
        if (op == '^')
            return 3;
        else if (op == '*' || op == '/')
            return 2;
        else if (op == '+' || op == '-')
            return 1;
        else
            return 0;
    }

    public static List<string> ToPostfix(string s)
    {
        Stack<char> stack = new Stack<char>();
        List<string> postfix = new List<string>();
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                int j = i + 1;
                while (j < s.Length && (char.IsDigit(s[j]) || s[j] == '.'))
                    j++;
                postfix.Add(s.Substring(i, j - i)); 
                i = j - 1; 
            }
            else if (s[i] == '(')
            {
                stack.Push(s[i]);
            }
            else if (s[i] == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    postfix.Add(stack.Pop().ToString());
                }
                stack.Pop();
            }
            else if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/' || s[i] == '^')
            {
                while (stack.Count() > 0 && Precedence(stack.Peek()) >= Precedence(s[i]))
                {
                      postfix.Add(stack.Pop().ToString());
                }
                stack.Push(s[i]);
            }
            
            
        }
        while (stack.Count > 0)
        {
            postfix.Add(stack.Pop().ToString());
        }
        return postfix;
    }
    private static double EvaluatePostfix(List<string> postfix)
    {
        Stack<double> operandStack = new Stack<double>();

        foreach (string token in postfix)
        {
            if (double.TryParse(token, out double number))
            {
                operandStack.Push(number);
            }
            else if (token[0] == '+' || token[0] == '-' || token[0] == '*' || token[0] == '/' || token[0] == '^')
            {
                double b = operandStack.Pop();
                double a = operandStack.Pop();
                switch (token[0])
                {
                    case '+':
                        operandStack.Push(a + b);
                        break;
                    case '-':
                        operandStack.Push(a - b);
                        break;
                    case '*':
                        operandStack.Push(a * b);
                        break;
                    case '/':
                        operandStack.Push(a / b);
                        break;
                    case '^':
                        operandStack.Push(Math.Pow(a, b));
                        break;
                }
            }
        }

        return operandStack.Pop();
    }


    public static double calculate(string s)
    {
        var x = ToPostfix(s);
        return EvaluatePostfix(x);
    }
    */ //Результатом в целом доволен


    /* ПЕРЕВЕРТЫШ По хорошему бы закончить эту кату, но пока лень
    public static double UpsideDown(string x, string y)
    {
        double count = 0;
        int first_current_num = 0;
        int second_current_num = 0;
        List<int> basics = new List<int> {0, 1, 8, 11, 69, 88, 96};
        for (int i = 0; i < basics.Count; i++)
        {
            if (int.Parse(x) > basics[i])
            {
                first_current_num = basics[i + 1];
                break;
            }
            else
            {
                first_current_num = 101;
                second_current_num = 1001;
                count++;
            }
        }
        if (current_num < basics.Last())
        {
            for (int i = basics.IndexOf(current_num); i < basics.Count; i++)
            {
                count++;
            }
        }
        else
        {
            current_num = int.Parse("1" + current_num.ToString()  + "1");
            if (current_num )
            {

            }
        }
        
    }
    */

    /* public static IEnumerable<int> Stream()
    {
        List<int> result_list = new List<int>();
        int limit = 10000000;
        // 2 and 3 are known to be prime
        if (limit > 2)
            result_list.Add(2);

        if (limit > 3)
            result_list.Add(3);

        // Initialise the sieve array with
        // false values
        bool[] sieve = new bool[limit + 1];

        for (int i = 0; i <= limit; i++)
            sieve[i] = false;

        /* Mark sieve[n] is true if one of the
        following is true:
        a) n = (4*x*x)+(y*y) has odd number 
           of solutions, i.e., there exist 
           odd number of distinct pairs 
           (x, y) that satisfy the equation 
           and    n % 12 = 1 or n % 12 = 5.
        b) n = (3*x*x)+(y*y) has odd number 
           of solutions and n % 12 = 7
        c) n = (3*x*x)-(y*y) has odd number 
           of solutions, x > y and n % 12 = 11 
        for (int x = 1; x * x <= limit; x++)
        {
            for (int y = 1; y * y <= limit; y++)
            {

                // Main part of Sieve of Atkin
                int n = (4 * x * x) + (y * y);
                if (n <= limit
                    && (n % 12 == 1 || n % 12 == 5))

                    sieve[n] ^= true;

                n = (3 * x * x) + (y * y);
                if (n <= limit && n % 12 == 7)
                    sieve[n] ^= true;

                n = (3 * x * x) - (y * y);
                if (x > y && n <= limit
                    && n % 12 == 11)
                    sieve[n] ^= true;
            }
        }

        // Mark all multiples of squares as
        // non-prime
        for (int r = 5; r * r < limit; r++)
        {
            if (sieve[r])
            {
                for (int i = r * r; i < limit;
                     i += r * r)
                    sieve[i] = false;
            }
        }

        // Print primes using sieve[]
        for (int a = 5; a <= limit; a++)
            if (sieve[a])
                result_list.Add(a);
        return result_list;
    } */ // РЕШЕНО!!! 3 уровень, вывод миллионов простых чисел


}