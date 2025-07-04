using System;

public class Program{
	
    public static bool ValidAnagram(string s , string t){
    	
         if(s.Length != t.Length){
         	return false;
         }
         
         int[] count = new int[26];
         
         for(int i = 0 ; i < s.Length ; i++){
         	 
             count[s[i] - 'a']++;
             count[t[i] - 'a']--;
         }
         
         foreach(int c in count){
         	 if(c != 0){
             	return false;
             }
         }
      
     return true;
     
    }
    public static void Main(){
        bool result = ValidAnagram("jam","jar");
        bool output = ValidAnagram("stop","pots");

       Console.WriteLine($" Is Anagram Valid ? {result}");
       Console.WriteLine($" Is Anagram Valid ? {output}");
        
    }
}
