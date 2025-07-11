using System;

public class Program{
	public static int CharacterReplacement(string s , int k){
    	  int left = 0;
          int maxCount = 0 , maxlength = 0 ;
          int[] freq = new int[26];
          
          for(int right = 0; right < s.Length; right++){
          	  	
                freq[s[right] - 'A']++;
                maxCount = Math.Max(maxCount,freq[s[right] - 'A']);
                
                while((right - left + 1) - maxCount > k){
                	freq[s[left] - 'A']--;
                    left++;
                }
                
               maxlength = Math.Max(maxlength,right - left + 1); 
          }
          
          return maxlength;
    }
	public static void Main(string[] args){
    	string s ="AABABBA";
        int k = 1;
        int result = CharacterReplacement(s,k);
        Console.WriteLine(result);
    }
}
