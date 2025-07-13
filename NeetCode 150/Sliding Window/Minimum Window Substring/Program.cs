using System;
using System.Collections.Generic;

public class Program
{
    public static string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            return "";

        Dictionary<char, int> targetFreq = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (!targetFreq.ContainsKey(c))
                targetFreq[c] = 0;
            targetFreq[c]++;
        }

        Dictionary<char, int> windowFreq = new Dictionary<char, int>();
        int left = 0, right = 0;
        int matched = 0;
        int minLen = int.MaxValue;
        int minStart = 0;

        while (right < s.Length)
        {
            char c = s[right];
            if (!windowFreq.ContainsKey(c))
                windowFreq[c] = 0;
            windowFreq[c]++;

            if (targetFreq.ContainsKey(c) && windowFreq[c] <= targetFreq[c])
                matched++;

            while (matched == t.Length)
            {
                if (right - left + 1 < minLen)
                {
                    minLen = right - left + 1;
                    minStart = left;
                }

                char leftChar = s[left];
                windowFreq[leftChar]--;
                if (targetFreq.ContainsKey(leftChar) && windowFreq[leftChar] < targetFreq[leftChar])
                    matched--;
                left++;
            }

            right++;
        }

        return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
    }  

    public static void Main(string[] args)
    {

        string s = "ADOBECODEBANC";
        string t = "ABC";

        string result = MinWindow(s, t);
        Console.WriteLine("Minimum Window Substring: " + result);
    }
}
