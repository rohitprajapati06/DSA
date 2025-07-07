using System;
using System.Collections.Generic;

public class Program{
	public static List<List<int>> ThreeSum(int[] nums){
    	
        Array.Sort(nums);
        List<List<int>> result = new List<List<int>>();
        
        for(int i = 0; i < nums.Length -2 ; i++){
        	
            if(i > 0 && nums[i] == nums[i-1])continue;
            
            int left = i + 1;
            int right = nums.Length -1;
        	
            while(left < right){
            	int sum = nums[i] + nums[left] + nums[right];
                
                if(sum == 0){
                	result.Add(new List<int> {nums[i],nums[left],nums[right]});
                    
                    while(left > right && nums[left] == nums[left + 1])left++;
                    while(left > right && nums[right] == nums[right -1])right--;
                    left++;
                    right--;
                    
                }else if(sum > 0){
                	left++;
                }else{
                	right--;
                }                
            }
        }
        
        return result;
    }
	public static void Main(){
    	  int[] nums = { -1, 0, 1, 2, -1, -4 };
          var triplets = ThreeSum(nums);
          foreach(var triple in triplets){
          	Console.WriteLine($"[{String.Join(",",triple)}]");
          }
    }
}
