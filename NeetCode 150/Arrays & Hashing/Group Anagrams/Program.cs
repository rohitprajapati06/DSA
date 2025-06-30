using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
  class Program
  {
    
    public static List<List<string>> GroupAnagrams(string[] words){
    
    	 Dictionary<string ,List<string>> map = new Dictionary<string ,List<string>>();
         
         foreach(var word in words){
         
         int[] count = new int[26];
         foreach(char c in word){
             count[c - 'a']++;
         }
         
         StringBuilder keybuilder = new StringBuilder();
         for(int i = 0 ; i < 26 ; i++){
         		keybuilder.Append("#");
                keybuilder.Append(count[i]);
         }
         
         string key = keybuilder.ToString();
         
         if(!map.ContainsKey(key)){
         	 map[key] = new List<string>();
         }
         	 map[key].Add(word);
             	      
       }  
		return new List<List<string>>(map.Values);  
    }
    public static void Main(string[] args)
    {
    	string[] words = { "eat", "tea", "tan", "ate", "nat", "bat" };
        var result = GroupAnagrams(words);

        foreach (var group in result)
        {
            Console.WriteLine($"[{string.Join(", ", group)}]");
        }
    }
  }
}

/////
