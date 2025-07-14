using System;
using System.Collections.Generic;

class Program{

  	public static int[] MaxSlidingWindow(int[] nums,int k){
    	
        int left = 0 , right = 0;
        var q = new LinkedList<int>();
        int[] output = new int[nums.Length - k + 1]; 
        
        while(right < nums.Length){
        	 
             while(q.Count > 0 && nums[q.Last.Value] < nums[right]){
             	q.RemoveLast();
             }
             
             q.AddLast(right);
             
             if(left > q.First.Value){
             	q.RemoveFirst();
             }
             
             if(right + 1 >= k){
             	output[left] = nums[q.First.Value];
                left++;
             }
             right++;
        }
         return output;
    }
    static void Main(string[] args)
    {
      int[] nums = { 1, 2, 1, 0, 4, 2, 6 };
      int k = 3;
      int[] output = MaxSlidingWindow(nums, k);
      Console.WriteLine(string.Join(",", output));     
    }
}
