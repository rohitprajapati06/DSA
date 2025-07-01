using System;

namespace Product of Array Except Self{
  
  class Program {
   public static int[] Product(int[] arr){
   
   		int n = arr.Length;
   		int[] output = new int[n];
        
        output[0] = 1;
        for(int i = 1 ; i < n ;i++){
        	output[i] = output[i-1] * arr[i-1];
        }
        
        int right = 1;
        for(int i = n -1 ; i >= 0 ; i--){
        	output[i] *= right;
            right *= arr[i];
        }
        
        return output;        
   }
    public static void Main(string[] args)
    {
      int[] arr = {1,2,3,4};
      int[] result = Product(arr);
      foreach(int i in result){
      		Console.Write(i + " ");
      }   
    }
  }
}
