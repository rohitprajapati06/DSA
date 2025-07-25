using System;
using System.Collections.Generic;

public class Program{
	public static bool ValidParenthesis(string s){
    	 
         Stack<char> stack = new Stack<char>();
         Dictionary<char,char> dict = new Dictionary<char,char>(){
         	{'}' , '{'},
            {']' , '['},
            {')' , '('}
         };
         
         foreach(char c in s){
         	 if(c == '{' || c == '[' || c == '('){
             	  stack.Push(c);
             }else{
             	 if(stack.Count == 0 || stack.Pop() != dict[c]){
                 	 return false;
                 }
             }
         }
         
         return stack.Count == 0;
    }
	public static void Main(string[] args){
    	 string s = "{[()]}";
         bool result = ValidParenthesis(s);
         Console.WriteLine($" Is Parenthesis Valid ? : {result}");
    }
}
