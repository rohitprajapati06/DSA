using System;
using System.Collections.Generic;

public class Program{
	public static int EvalRPN(string[] arr){
    	 
        Stack<int> stack = new Stack<int>();
        foreach(string s in arr){
        	if(s == "+" || s == "-" || s == "*" || s== "/"){
            	 int b = stack.Pop(); 
                 int a = stack.Pop(); 
                 int result = 0 ;
                 
                 switch(s){
                 	 case "+" : result = a + b; break;
                     case "-" : result = a - b; break;
                     case "/" : result = a / b; break;
                     case "*" : result = a * b; break;                     
                 }
                 stack.Push(result);
            }else{
            	stack.Push(int.Parse(s));
            }
        }
        
        return stack.Pop();
    }
	public static void Main(string[] args){
    	string[] arr = {"1","2","+","3","*","4","-"};
        int output = EvalRPN(arr);
        Console.WriteLine(output);
    }
}
