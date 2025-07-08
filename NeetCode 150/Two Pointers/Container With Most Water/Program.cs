using System;

public class Program{
	public static int ContainerWithMostWater(int[] heights){
    	 
         int left = 0;
         int right = heights.Length-1;
         int maxArea = 0;
         
         while(left < right){
         	int height = Math.Min(heights[left],heights[right]);
            int width = right - left;
            int area = height * width;
            maxArea = Math.Max(area,maxArea);
            
            if(heights[left] < heights[right]){
            	left++;
            }else{
            	right--;
            }
         }
        return maxArea;
    }
	public static void Main(string[] args){
    	int[] heights = {1,7,2,5,4,7,3,6};
        int result = ContainerWithMostWater(heights);
        Console.WriteLine(result);
    }
}
