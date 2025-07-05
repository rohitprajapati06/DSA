using System;
using System.Collections.Generic;

public class Program{
	
    public static bool HasDuplicate(int[] arr){
    	
         HashSet<int> hash = new HashSet<int>();
         foreach(int num in arr){
         		
               if(hash.Contains(num)){
               		return true;
               }else{
               		hash.Add(num);
               }
         }
         
         return false;
    }
    public static void Main(string[] args){
    	
        int[] arr = {1,2,4,3,5,9};
        bool result = HasDuplicate(arr);
        Console.WriteLine($"Does Array has Duplicate Elements ? {result}");
    }
}
