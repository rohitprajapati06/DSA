using System;
using System.Linq;

public class Program{
	public static int MinEatingSpeed(int[] piles , int hours){
    		
            int left = 1 ;
            int right = piles.Max();
            int result = right;
            
            while(left <= right){
            	
                int k = left + (right - left)/2;
                long totaltime = 0;
                foreach(int p in piles){
                	totaltime += (int)Math.Ceiling((double)p/k);
                }
                if(totaltime <= hours){
                	result = k;
                    right = k - 1;
                }else{
                	left = k + 1; 
                }
            }
           
           return result;
    }
	public static void Main(string[] args){
    	int[] piles = {6,3,7,11};
        int hours = 8;
        int output = MinEatingSpeed(piles,hours);
        Console.WriteLine($"Minimum Eating Speed is {output}");
    }
}
