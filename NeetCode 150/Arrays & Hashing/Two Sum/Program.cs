using System;

  class Program
  {
  	public static int[] TwoSum(int[] arr,int target){
    	
        int left = 0;
        int right = arr.Length -1;
        
        while(left < right){
        	
            int sum = arr[left] + arr[right];
            
            if(sum == target){
            	return new int[] {left,right};
            }else if(sum > target){
            	right--;
            }else{
            	left++;
            }
        }
        return new int[] {-1,-1};
    }
    public static void Main(string[] args)
    {
      int[] arr = {5,12,9,14};
      int target = 21;
      int[] result = TwoSum(arr,target);
      Console.WriteLine($"[{String.Join(",",result)}]");    
    }
  }
