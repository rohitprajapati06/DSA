using System;

public class Program{
	public static int BinarySearch(int[] nums , int target){
    		
            int left = 0 ;
            int right = nums.Length - 1;
            
            while(left <= right){
            	int mid = left + (right - left) / 2;
                
                if(nums[mid] == target){
                	return mid;
                }else if(nums[mid] < target){
                	left = mid + 1;
                }else{
                	right = mid - 1;
                }
            }
          return -1;
    }
	public static void Main(string[] args){
    	int[] nums = {-1,0,2,4,6,8};
        int target = 6;
        int result = BinarySearch(nums,target);
        Console.WriteLine(result);
    }

}
