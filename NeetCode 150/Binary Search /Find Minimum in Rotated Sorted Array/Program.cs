using System;

public class Program{
	public static int FindMinimum(int[] arr){
    	
        int left = 0;
        int right = arr.Length -1;
        
        while(left < right){
        	
             int mid = left + (right - left) / 2;
             if(arr[mid] > arr[right]){
             	  left = mid + 1;
             }else{
             	  right = mid;
             }
        }
        
        return arr[left]; // or arr[right]
    }
	public static void Main(string[] args){
    	int[] arr = {3,4,5,6,1,2};
        int result = FindMinimum(arr);
        Console.WriteLine(result);
    }
}
