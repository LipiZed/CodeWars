namespace CodeWars.Tasks.LeetCode;
using System.Linq;
public class ReverseInt
{
    public int reverse(int x)
    {
        if (x < 0)
        {
            string result = new string(x.ToString().Remove(0,1).Reverse().ToArray());
            try
            {
                int result_int = int.Parse("-" + result);
                return result_int;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        string result2 = new string(x.ToString().Reverse().ToArray());
        try
        {
            int result_int2 = int.Parse(result2);
            return result_int2;
        }
        catch (Exception e)
        {
            return 0;
        }
    }
}