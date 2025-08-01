using System;

public class Program{
	public static int CarFleet(int target,int[] position,int[] speed){
    	
        int n = position.Length;
        int[][] pairs = new int[n][];
        for(int i = 0 ; i < n; i++){
        	pairs[i] = new int[] {position[i],speed[i]};
        }
        
        Array.Sort(pairs,(a,b)=> b[0].CompareTo(a[0]));
        
        int fleet = 1;
        double currtime = (double)(target - pairs[0][0])/pairs[0][1];
        for(int i = 1; i < n; i++){
        	double prevtime = (double)(target - pairs[i][0])/ pairs[i][1];
            
            if(currtime > prevtime){
            	fleet++;
                prevtime = currtime;
            }
        }
        
        return fleet;
    }
	public static void Main(){
    	int target = 10;
        int[] position = {4,1,0,7};
        int[] speed = {2,2,1,1};
        int output = CarFleet(target,position,speed);
        Console.WriteLine(output);
    }
}
