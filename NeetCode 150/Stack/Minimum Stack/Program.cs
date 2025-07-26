using System;
using System.Collections.Generic;

public class MinStack{

	private Stack<int> mainstack;
    private Stack<int> minstack;
    
    public MinStack(){
    	mainstack = new Stack<int>();
        minstack = new Stack<int>();
    }
    
    public void Push(int val){
    	mainstack.Push(val);
        if(minstack.Count == 0 || val <= minstack.Peek()){
        	minstack.Push(val);
        }
    }
    
    public void Pop(){
    	if(mainstack.Count == 0) return ;
        int removed = mainstack.Pop();
        if(removed == minstack.Peek()){
        	minstack.Pop();
        }
    }
    
    public int Top(){
    	return mainstack.Peek();
    }
    
    public int GetMin(){
    	return minstack.Peek();
    }
    
	public static void Main(string[] args){
    	
        MinStack stack = new MinStack();
		stack.Push(5);
		Console.WriteLine("Pushed 5 -> Min: " + stack.GetMin()); 

		stack.Push(3);
		Console.WriteLine("Pushed 3 -> Min: " + stack.GetMin()); 

		stack.Push(7);
		Console.WriteLine("Pushed 7 -> Min: " + stack.GetMin()); 

		stack.Push(2);
		Console.WriteLine("Pushed 2 -> Min: " + stack.GetMin()); 

		stack.Pop();
		Console.WriteLine("Popped -> Min: " + stack.GetMin());   

		Console.WriteLine("Top element: " + stack.Top());
	}
}
