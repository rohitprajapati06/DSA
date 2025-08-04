using System;
using System.Collections.Generic;

public class Program{
	public static int LargestRectangleInHistogram(int[] heights){
    	
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;
        
        Array.Resize(ref heights, heights.Length + 1);
        heights[heights.Length - 1] = 0;
        
        for(int i = 0; i < heights.Length; i++){
        	
            while(stack.Count > 0 && heights[i] < heights[stack.Peek()]){
            	int height = heights[stack.Pop()];
                int width =  (stack.Count == 0)? 0 : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea , height * width);
            }
            stack.Push(i);
        }
        return maxArea;
        
    }
	public static void Main(string[] args){
    	int[] heights = {7,1,7,2,2,4};
        int result = LargestRectangleInHistogram(heights);
        Console.WriteLine(result);
    }
}
