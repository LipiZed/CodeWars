namespace CodeWars.Tasks.LeetCode;

public class StringToInteger
{
    public int MyAtoi(string s)
    {
        s = s.Trim(' ');
        char[] specialChars = ['.', ',', '/', ' '];
        string result_string = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsLetter(s[i]) || specialChars.Contains(s[i]))
            {
                if ((s[i] == '-' || s[i] == '+') && i != 0  || specialChars.Contains(s[i]))
                {
                    break;
                }

                result_string += s[i];
            }
            else
            {
                break;
            }
        }

        if (string.IsNullOrEmpty(result_string))
        {
            return 0;
        }

        try
        {
            return int.Parse(result_string);
        }
        catch (OverflowException)
        {
            return result_string[0] == '-' ? int.MinValue : int.MaxValue;
        }
        catch (FormatException)
        {
            return 0;
        }
    }
}