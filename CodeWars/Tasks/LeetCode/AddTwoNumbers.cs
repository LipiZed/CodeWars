using CodeWars.Data;

namespace CodeWars.Tasks.LeetCode;

public class AddTwoNumbers
{
    public int AddTwoNumbersResult(ListNode l1, ListNode l2)
    {
        string firstNumber = "";
        string secondNumber = "";
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
        int result_num = Convert.ToInt32(new string(firstNumber.Reverse().ToArray())) 
                         + Convert.ToInt32(new string(secondNumber.Reverse().ToArray()));
        string result = new string(result_num.ToString().Reverse().ToArray());
        ListNode result_node = new ListNode();
        return result_num;
    }
}