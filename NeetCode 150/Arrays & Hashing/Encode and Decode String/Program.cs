using System;
using System.Collections.Generic;
using System.Text;

namespace Encode_and_Decode_Strings
{
    internal class Program
    {
        public static string Encode(string[] input)
        {
            StringBuilder encode = new StringBuilder();
            foreach (string str in input)
            {
                encode.Append(str.Length).Append("#").Append(str);
            }
            return encode.ToString();
        }

        public static List<string> Decode(string s)
        {
             List<string> result = new List<string>();
            int i = 0;

             while (i < s.Length)
            {
                int j = i;
                while (s[j] != '#') j++;

                int length = int.Parse(s.Substring(i, j - i));
                j++; 

                string str = s.Substring(j, length);
                result.Add(str);

                i = j + length;
            }

            return result;
        }

        static void Main(string[] args)
        {
            string[] input = { "neet", "code", "love", "you" };
            string s = Encode(input);
            Console.WriteLine(s);

            List<string> output = Decode(s);
            Console.WriteLine("Decoded: [" + string.Join(", ", output) + "]");
        }
    }
}
