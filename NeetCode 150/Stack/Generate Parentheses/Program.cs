using System;
using System.Collections.Generic;

public class Program{
	public static List<string> GenerateParenthesis(int n){
    	
        var result = new List<string>();
        BackTracking(result,"",0,0,n);
        return result;
    }
    
    public static void BackTracking(List<string> result , string current , int open , int close , int max ){
    	
        if(current.Length == max * 2){
        	result.Add(current);
            return;
        }
        
        if(open < max){
        	BackTracking(result,current + "(", open + 1 , close , max);
        }
        
        if(close < open){
        	BackTracking(result,current + ")",open , close + 1 , max);
        }
    			
    }
	public static void Main(){
    	int n = 2;
        List<string> output = GenerateParenthesis(n);
        foreach(var item in output){
        	Console.Write($"[{item}] ");
        }
    }
}
