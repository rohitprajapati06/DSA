using System;

public class Program{
	public static int TrappingRainWater(int[] height){
    	
        int left = 0;
        int right = height.Length -1;
        int leftMax = 0;
        int rightMax = 0;
        int water = 0;
        
        while(left < right){
        	if(height[left] < height[right]){
            	if(height[left] >= leftMax){
                	leftMax = height[left];
                }else{
                	water += leftMax - height[left];
                }
                left++;
            }else{
            	if(height[right] >= rightMax){
                	rightMax = height[right];
                }else{
                	water += rightMax - height[right];
                }
                right--;
            }
        }
        return water;
    }
	public static void Main(string[] args){
    	int[] height = {0,2,0,3,1,0,1,3,2,1};
        int result = TrappingRainWater(height);
        Console.WriteLine(result);
    }
}
