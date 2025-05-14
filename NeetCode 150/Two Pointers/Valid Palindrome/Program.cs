using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valid_Palindrome
{
    internal class Program
    {
        public static bool IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                if (!char.IsLetterOrDigit(s[start]))
                {
                    start++;
                }
                else if (!char.IsLetterOrDigit(s[end]))
                {
                    end--;
                }
                else
                {
                    if (char.ToLower(s[start]) != char.ToLower(s[end]))
                    {
                        return false;
                    }
                    start++;
                    end--;
                }
            }
            return true;
        }
        public static void Main(string[] args)
        {
            string s = "A man, a plan, a canal: Panama";
            if (IsPalindrome(s))
            {
                Console.WriteLine("It is an Palindrome");
            }
            else {
                Console.WriteLine("It is not an Palindrome");
            }
        }
    }
}
