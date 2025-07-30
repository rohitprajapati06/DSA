using System;
using System.Collections.Generic;

public class Program{
	public static int[] DailyTemperatures(int[] temperatures){
    	
        int n = temperatures.Length;
        int[] result = new int[n];
        Stack<int> stack = new Stack<int>();
        
        for(int i = n-1; i >= 0; i--){
        	
            while(stack.Count > 0 && temperatures[i] >= temperatures[stack.Peek()]){
            	stack.Pop();
            }
            
            result[i] = stack.Count == 0? 0 : stack.Peek() - i;
            stack.Push(i);
        }
        
        return result;
        
    }
	public static void Main(string[] args){
    	int[] temperatures = {73, 76, 72, 69, 71, 75, 74, 73};
        int[] output = DailyTemperatures(temperatures);
        Console.WriteLine($"[{String.Join(",",output)}]");
    }
}
