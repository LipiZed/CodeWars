using CodeWars.Data;
using System.Numerics;

namespace CodeWars.Tasks.LeetCode;

public class AddTwoNumbers
{
    public ListNode AddTwoNumbersResult(ListNode l1, ListNode l2)
    {
        string firstNumber = "";
        string secondNumber = "";
    
        // Собираем первое число
        while (true)
        {
            firstNumber += l1.val.ToString();
            if (l1.next == null)
            {
                break;
            }
            else
            {
                l1 = l1.next;
            }
        }

        // Собираем второе число
        while (true)
        {
            secondNumber += l2.val.ToString();
            if (l2.next == null)
            {
                break;
            }
            else
            {
                l2 = l2.next;
            }
        }

        // Конвертируем строки в BigInteger
        BigInteger firstBigInt = BigInteger.Parse(new string(firstNumber.Reverse().ToArray()));
        BigInteger secondBigInt = BigInteger.Parse(new string(secondNumber.Reverse().ToArray()));

        // Складываем два числа
        BigInteger resultNum = firstBigInt + secondBigInt;

        // Преобразуем результат обратно в строку с развернутым порядком
        string result = new string(resultNum.ToString().Reverse().ToArray());

        // Создаем связанный список результата
        ListNode resultNode = new ListNode(result[0] - '0'); // Первый символ преобразуем в число
        ListNode current = resultNode;

        for (int i = 1; i < result.Length; i++)
        {
            current.next = new ListNode(result[i] - '0'); // Создаем следующий узел с текущей цифрой
            current = current.next; // Переходим к следующему узлу
        }

        return resultNode;

    }
}