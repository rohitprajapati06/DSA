using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Seacrh
{
    public  class Program
    {
        public static int BinarySearchArray(int[] arr,int target) {

            Array.Sort(arr);
            int left = 0;
            int right = arr.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target)
                {
                    return mid;
                }else if (arr[mid] < target) {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }               
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 }; 
            int target = 17;
            int index = BinarySearchArray(arr,target);
            if(index >= 0)
            {
                Console.WriteLine("Element Found at index "+index);
            }
            else
            {
                Console.WriteLine("Element not found");
            }
        }
    }
}
