using System;

public class Program{
	public static bool Search2DMatrix(int[][] matrix, int target){
    	 
         int n = matrix[0].Length;
         int m = matrix.Length;
         int left = 0 ,  right = m * n -1;
         
         while(left <= right){
         	
            int mid = left + (right - left) / 2;
            int midValue = matrix[mid/n][mid%n];
            
            if(midValue == target){
            	return true;
            }else if(midValue < target){
            	left = mid + 1;
            }else{
            	right = mid - 1;
            }
         }
         
         return false;
    }
	public static void Main(string[] args){
    	 
         var matrix = new int[][] {
            new int[] { 1, 3, 5, 7 },
            new int[] { 10, 11, 16, 20 },
            new int[] { 23, 30, 34, 60 }
         };
         
         int target = 15;
         bool result = Search2DMatrix(matrix,target);
         Console.WriteLine($"Element {target} found in 2D Matrix ? : {result}");
    }
}
