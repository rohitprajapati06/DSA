using System;
using System.Collections.Generic;

  class Program
  {
    public static int ConsecutiveSequence(int[] arr){
    	
        HashSet<int> hash = new HashSet<int>(arr);
        int longest = 0;
        
        foreach(int num in arr){
        	  
             if(!hash.Contains(num - 1)){
             	 int currentnum = num;
                 int streak = 1;
                 
                 while(hash.Contains(currentnum + 1)){
                 	  currentnum++;
                      streak++;
                 }
                 longest = Math.Max(longest,streak);
             }
        }
        return longest;
    }
    static void Main(string[] args)
    {
      int[] arr = {100 , 4 , 200 , 3 , 1 , 2};
      int output = ConsecutiveSequence(arr);
      Console.WriteLine(output);    
    }
  }
