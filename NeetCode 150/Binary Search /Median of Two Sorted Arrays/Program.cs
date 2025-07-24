using System;

public class Program{
	public static double MedainOfTwoSortedArrays(int[] num1 , int[] num2){
    	 
         int x = num1.Length;
         int y  = num2.Length;
         int low = 0 , high = x;
         
         while(low <= high){
         	
            int partitionX = (low + high) / 2;
            int partitionY = (x + y + 1) / 2 - partitionX;
            
            int LeftX = (partitionX == 0)? int.MinValue : num1[partitionX - 1];
            int RightX = (partitionX == x)? int.MaxValue : num1[partitionX];
            
            int LeftY = (partitionY == 0)? int.MinValue : num2[partitionY - 1];
            int RightY = (partitionY == y)? int.MaxValue : num2[partitionY];	
            if(LeftX <= RightY && LeftY <= RightX){
            	
                if(((x + y) % 2) == 0){
                	return (Math.Max(LeftX,LeftY) + Math.Min(RightX, RightY)) / 2.0;
                }else{
                	return Math.Max(LeftX,LeftY);
                }
                
            }else if (LeftX > RightY)
            {
                high = partitionX - 1;
            }
            else
            {
                low = partitionX + 1;
            }
            
         }
       throw new ArgumentException("Input arrays are not sorted.");
    }
	public static void Main(string[] args){
    	 int[] num1 = {1,3};
         int[] num2 = {2,4};
         double result = MedainOfTwoSortedArrays(num1 ,num2);
         Console.WriteLine(result);
    }
}
