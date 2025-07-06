using System;

public class Program{
	public static int[] TwoSumII(int[] arr , int target){
    	
        int left = 0;
        int right = arr.Length - 1;
        
        while(left < right){
        	
            int sum = arr[left] + arr[right];
            if(sum == target){
            	return new int[] {arr[left],arr[right]};
            }else if(sum > target){
            	right--;
            }else{
            	left++;
            }
        }
        return new int[] {-1,-1};
    }
	public static void Main(){
    	int[] arr = {1,2,3,4};
        int target = 3;
        int[] result = TwoSumII(arr,target);
        Console.WriteLine($"[{String.Join(",",result)}]");
    }
}
