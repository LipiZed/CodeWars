namespace CodeWars.Tasks.LeetCode;
using System;
public class Substring
{
    public int LengthOfLongestSubstring(string s)
    {
        if (String.IsNullOrEmpty(s))
        {
            return 0;
        }
        List<string> substrings = new List<string>();
        string substring = "";
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (!substring.Contains(s[j]))
                {
                    substring += s[j];
                }
                else
                {
                    break;
                }
            }
            substrings.Add(substring);
            substring = "";
        }

        if (substrings.Max(substring => substring.Length) == 0)
        {
            return 1;
        }
        return substrings.Max(substring => substring.Length);
    }
}