using System;

public class Program{
	public static bool PermutationString(string s1 ,string s2){
    	 	
            if(s1.Length > s2.Length)return false;
            
            int[] s1Freq = new int[26];
            int[] s2Freq = new int[26];
            
            for(int i = 0; i < s1.Length ; i++){
            	s1Freq[s1[i] - 'a']++;
                s2Freq[s2[i] - 'a']++;
            }
            
            if(AreEqual(s1Freq,s2Freq)) return true;
            
            for(int i = s1.Length ; i < s2.Length ; i++){
            	
                s2Freq[s2[i - s1.Length] - 'a']--;
                s2Freq[s2[i] - 'a']++;
                
                if(AreEqual(s1Freq,s2Freq)) return true;
            }
            
            return false;
            
    }
    
    private static bool AreEqual(int[] a,int[] b){
    	 
         for(int i = 0 ; i < 26 ; i++){
         		if(a[i] != b[i])return false;    
         }
         return true;
    }
    
	public static void Main(string[] args){
    	string s1 = "abc";
        string s2 = "fezcdbca";
        
        bool result = PermutationString(s1 ,s2);
        Console.WriteLine("Is Permutation String ? "+result);
    }
}
