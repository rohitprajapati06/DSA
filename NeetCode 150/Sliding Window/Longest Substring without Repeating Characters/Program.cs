using System;
using System.Collections.Generic;

class Program
{
    public static int LongestSubstring(string s) {

        if (String.IsNullOrEmpty(s)) {
            return 0;
        }

        HashSet<char> c = new HashSet<char>();
        int left = 0, maxlength = 0;

        for(int right = 0; right < s.Length; right++)
        {

            while (c.Contains(s[right]))
            {
                c.Remove(s[left]);
                left++;
            }
            c.Add(s[right]);
            maxlength = Math.Max(maxlength, right - left + 1);   
        }
        return maxlength;
    }
    public static void Main(string[] args)
    {
        string s = "abcabcbb";
        int op = LongestSubstring(s);
        Console.WriteLine($" input : {s}  output : {op}");
    }
}