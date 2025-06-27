using System;
using System.Collections.Generic;

class Program{
	public static int[] TopKFrequent(int[] nums,int k){
		
		Dictionary<int,int> count = new Dictionary<int,int>();
		foreach(int num in nums){
			 if(count.ContainsKey(num)){
			 	 count[num]++;
			 }else{
			 	 count[num] = 1;
			 }
		}
		
		List<int>[] freq = new List<int>[nums.Length + 1];
		for(int i = 0 ; i < freq.Length ; i++){
			 freq[i] = new List<int>();
		}
		
		foreach(var entry in count){
			 freq[entry.Value].Add(entry.Key);
		}
		
		int[] result = new int[k];
		int index = 0 ;
		
		for(int i = freq.Length -1 ; i > 0 && index < k ; i--){
			
			foreach(int n in freq[i]){
				  result[index++] = n;
				  if(index == k){
				  		return result;
				  }
			}
		}
		
		return result;
		
	}
	public static void Main()
	{
    int[] nums = { 1, 1, 1, 2, 2, 3 };
    int k = 2;

    int[] result = TopKFrequent(nums, k);

    Console.WriteLine("Top " + k + " frequent elements:");
    for (int i = 0; i < result.Length; i++)
    {
        Console.Write(result[i] + " ");
    }
    Console.WriteLine();
	}
}
