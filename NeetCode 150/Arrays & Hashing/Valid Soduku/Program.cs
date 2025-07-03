using System;
using System.Collections.Generic;

public class Program
{ 	
 	public static bool IsValidSudoku(char[][] board){
    	  
          HashSet<string> hash = new HashSet<string>();
          
          for(int i = 0 ; i < 9 ; i++){
          	  for(int j = 0 ; j < 9 ; j++){
              		
                    char current = board[i][j];
                    if(current != '.'){
                    	 string rowkey = $"row{i}-{current}";
                         string colkey = $"col{j}-{current}";
                         string boxkey = $"box{i/3}{j/3}-{current}";
                         
                         if(hash.Contains(rowkey)|| hash.Contains(colkey) || hash.Contains(boxkey)){
                    	return false;
                    	}
                    
                      hash.Add(rowkey);
                      hash.Add(colkey);
                      hash.Add(boxkey);
                    }    
              }
          }
          
          return true;
          
    }
    public static void Main()
    {
        char[][] board = new char[9][]
        {
            new char[] { '5','3','.','.','7','.','.','.','.' },
            new char[] { '6','.','.','1','9','5','.','.','.' },
            new char[] { '.','9','8','.','.','.','.','6','.' },
            new char[] { '8','.','.','.','6','.','.','.','3' },
            new char[] { '4','.','.','8','.','3','.','.','1' },
            new char[] { '7','.','.','.','2','.','.','.','6' },
            new char[] { '.','6','.','.','.','.','2','8','.' },
            new char[] { '.','.','.','4','1','9','.','.','5' },
            new char[] { '.','.','.','.','8','.','.','7','9' }
        };

        bool isValid = IsValidSudoku(board);
        Console.WriteLine("Is the Sudoku board valid? " + isValid);
    }
}
