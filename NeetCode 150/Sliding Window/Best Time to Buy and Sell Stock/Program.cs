using System;

public class Program{
	public static int BuyAndSellStocks(int[] prices){
    	int left = 0 , right = 1;  // left (buy)  right (sell)
        int maxprofit =0;
        
        while(right < prices.Length){
        	if(prices[left] < prices[right]){
            	int profit = prices[right] - prices[left];
                maxprofit = Math.Max(maxprofit,profit);
            }else{
            	left = right;
            }
            right++;
        }
        return maxprofit;
    }
	public static void Main(string[] args){
    	int[] prices = {7,6,4,3,1};
        int result = BuyAndSellStocks(prices);
        Console.WriteLine(result);
    }
}
