using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_App
{
    public class nQueen
    {
        public static string  displayBoard(int[] board )//output the board 
        {
            int boardLength = board.Length;// reas the board length
            string ss = "";
            for(int column=0;column<boardLength;column++)
            {
                for(int row=0;row<boardLength;row++)
                {
                    if (board[column] == row) { ss += "Q"; }//if the 
                    else { ss += "X"; }// thosewhich not the Queen
                }
                ss += "\n";//line feed
            }
            return ss;//returen result
        }//End of displayBoard
        public static bool solveQueen(int n ,out int[] board)
        {
            bool flag = false;
            board = new int[n];
            if (placeQueen(board, 0)) { flag = true; }
            return flag;
        }//End of solveQueen
        private static bool placeQueen(int[] board, int row)//put the Queen in the special place
        {
            bool flag = false;
            int n = board.Length;
            if (n == row) { flag = true; }
            else
            {   for(int colum = 0;colum<n;colum++)
                {
                    int c;
                    for(c=0;c<row;c++)
                    {
                        if (board[c]==colum||c-row==board[c]-colum||row-c==board[c]-colum) { break; }//if the queen in the same line||same row||diagonal than break for loop
                    }
                    if(c==row)
                    {
                        board[row] = colum;
                        if(placeQueen(board,row+1))//judge the next row Queen recursive
                        {
                            flag = true;break;
                        }
                    }
                }

            }
            return flag;//judge the Queen whther exist
        }//End of placeQueen
    }//End of class nQueen
}//End of nameplace
