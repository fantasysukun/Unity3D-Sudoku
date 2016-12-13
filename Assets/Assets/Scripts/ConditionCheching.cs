﻿using UnityEngine;
using System.Collections;

public class ConditionCheching : MonoBehaviour {

    public bool[] Row;
    public bool[] Column;
    public bool[] Grid;
    public bool[] OneToNine;
    public bool AllRowFilled;
    public bool AllColumnFilled;
    public bool AllGridFilled;
    public bool AllOneTONiceFilled;

    public static int[,] Testing9x9Grid = new int[,] {
            {5,2,7,0,0,6,4,0,0 },
            {0,9,1,0,5,0,0,3,6 },
            {4,0,0,0,0,9,0,8,0 },
            {2,0,0,0,1,0,3,0,4 },
            {0,0,4,2,0,0,7,6,0 },
            {0,0,0,0,0,0,0,5,2 },
            {0,4,0,8,0,0,0,0,5 },
            {0,6,0,5,4,7,1,0,0 },
            {0,0,2,0,3,1,0,4,8 } };

    public static int[,] Testing3x3Grid = new int[,] {
            {5,2,7 },
            {0,9,1 },
            {4,0,0 },};

    public int[,] Testing9x9Grid_False = new int[,] {
            {5,2,7,0,0,6,4,0,0 },
            {0,9,1,0,5,0,0,3,6 },
            {4,0,5,0,0,9,0,8,0 },
            {2,0,0,0,1,0,3,0,4 },
            {0,0,4,2,0,0,7,6,0 },
            {0,0,0,0,0,0,0,5,2 },
            {0,4,0,8,0,0,0,0,5 },
            {0,6,0,5,4,7,1,0,0 },
            {0,0,2,0,3,1,0,4,8 } };

    public int[,] Testing3x3Grid_False = new int[,] {
            {5,2,7 },
            {0,9,1 },
            {4,0,5 },};

    public static int[,] Testing9x9Grid_True = new int[,] {
            {5,2,7,0,0,6,4,0,0 },
            {0,9,1,0,5,0,0,3,6 },
            {4,0,6,0,0,9,0,8,0 },
            {2,0,0,0,1,0,3,0,4 },
            {0,0,4,2,0,0,7,6,0 },
            {0,0,0,0,0,0,0,5,2 },
            {0,4,0,8,0,0,0,0,5 },
            {0,6,0,5,4,7,1,0,0 },
            {0,0,2,0,3,1,0,4,8 } };

    public static int[,] Testing3x3Grid_True = new int[,] {
            {5,2,7 },
            {0,9,1 },
            {4,0,6 },};

    public static int[,] FinalMap = new int[,] {
            {3,9,1,2,8,6,5,7,4 },
            {4,8,7,3,5,9,1,2,6 },
            {6,5,2,7,1,4,8,3,9 },
            {8,7,5,4,3,1,6,9,2 },
            {2,1,3,9,6,7,4,8,5 },
            {9,6,4,5,2,8,7,1,3 },
            {1,4,9,6,7,3,2,5,8 },
            {5,3,8,1,4,2,9,6,7 },
            {7,2,6,8,9,5,3,4,1 } };

    public static int[,] FinalMap1 = new int[,] {
            {3,9,1,2,8,6,5,7,4 },
            {4,8,7,3,5,9,1,2,6 },
            {6,5,2,7,1,4,8,3,9 },
            {8,7,5,4,3,1,6,9,2 },
            {2,1,3,9,6,7,4,8,5 },
            {9,6,4,5,2,8,7,1,3 },
            {1,4,9,6,7,3,2,5,8 },
            {5,3,8,1,4,2,9,6,7 },
            {7,2,6,8,9,5,3,4,0 } };

    public static int[,] FinalMap2 = new int[,] {
            {3,9,1,2,8,6,5,7,4 },
            {4,8,7,3,5,9,1,2,6 },
            {6,5,2,7,1,4,8,3,9 },
            {8,7,5,4,3,1,6,9,2 },
            {2,1,3,9,6,7,4,8,5 },
            {9,6,4,5,2,8,7,1,3 },
            {1,4,9,6,7,3,2,5,8 },
            {5,3,8,1,4,2,9,6,7 },
            {7,2,6,8,9,5,3,4,2 } };
    // Use this for initialization
    void Start () {
        Row = new bool[9];
        Column = new bool[9];
        Grid = new bool[9];

        for (int i=0; i < 9; i++)
        {
            Row[i] = false;
            Column[i] = false;
            Grid[i] = false;
        }
        AllRowFilled = false;
        AllColumnFilled = false;
        AllGridFilled = false;
        AllOneTONiceFilled = false;

        //Sample Unit Testing
        int GridNumber = 0; //The first Grid
        /*
        Debug.Log("Violation: " +  Violation(0, 0, Testing9x9Grid));
        Debug.Log("GridViolation: " + GridViolation(0, 0, GridNumber, Testing3x3Grid));

        Debug.Log("Violation: " + Violation(0, 0, Testing9x9Grid_False) + " Expected False");
        Debug.Log("GridViolation: " + GridViolation(0, 0, GridNumber, Testing3x3Grid_False) + " Expected True");
        */

        //Testing for final checking
        Debug.Log("FinalMap: " + solveSudoku(FinalMap) + " Expected True");
        Debug.Log("FinalMap1: " + solveSudoku(FinalMap1) + " Expected False");
        Debug.Log("FinalMap2: " + solveSudoku(FinalMap2) + " Expected False");
    }

    //Input Position x and Position y for the Player input number
    //Input 9x9 Grid map for the whole map
    //Return a bool of this input number Violate the Horizontal & Vertical rule or not
    public static bool Violation(int x, int y, int[,] Grid9x9)
    {

        //Debug.Log("x: " + x + ", y: " + y);
        bool Result = false;
        for (int Row = 0; Row < Grid9x9.GetLength(0); Row++)
        {
            for (int Col = 0; Col < Grid9x9.GetLength(1); Col++)
            {
                if( (Row == x || Col == y) && !(Row == x && Col == y))
                {
                    if(Grid9x9[x , y] == Grid9x9[Row , Col] && Grid9x9[x , y] != 0)
                    {
                        /*
                        Debug.Log("x: " + x + ", y: " + y);
                        Debug.Log("Map[x , y]: " + Map[x, y]);
                        Debug.Log("Row: " + Row + ", Col: " + Col);
                        Debug.Log("Map[Row , Col]: " + Map[Row, Col]);
                        */
                        return Result = true;
                    }
                }
            }
        }

        return Result;
    }

    //Input Position x and Position y for the Player input number
    //Input 3x3 Grid map for where the Player input number is located
    //Return a bool of this input number Violate the Grid rule or not
    public static bool GridViolation(int x, int y, int GridNumber, int[,] Grid3x3)
    {
        //Debug.Log("x: " + x + ", y: " + y);
        bool Result = false;
        for (int Row = 0; Row < Grid3x3.GetLength(0); Row++)
        {
            for (int Col = 0; Col < Grid3x3.GetLength(1); Col++)
            {
                if (!(Row == x && Col == y))
                {
                    if (Grid3x3[x, y] == Grid3x3[Row, Col] && Grid3x3[x, y] != 0)
                    {
                        /*
                        Debug.Log("x: " + x + ", y: " + y);
                        Debug.Log("Map[x , y]: " + Map[x, y]);
                        Debug.Log("Row: " + Row + ", Col: " + Col);
                        Debug.Log("Map[Row , Col]: " + Map[Row, Col]);
                        */
                        return Result = true;
                    }
                }
            }
        }

        return Result;
    }

    public string WinningConditionChecking()
    {
        string Player1 = "Player1";
        string Player2 = "Player2";

        if (solveSudoku(FinalMap))
        {
            if(Score1.score > Score2.score)
            {
                //play winning animation for player1
                return Player1;
            }
            else
            {
                //play winning animation for player2
                return Player2;
            }
        }
        return "The Game has not finished yet. solveSudoku returns false.";
    }

    //Final checking
    //input a final map from player for checking
    public bool solveSudoku(int[,] board)
    {
        if (board == null || board.GetLength(0) == 0)
            return false;
        return solve(board);
    }

    public bool solve(int[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i,j] == 0)
                {
                    return false;
                }
                else
                {
                    for (int c = 1; c <= 9; c++)    //trial. Try 1 through 9
                    {                       
                        if (isValid(board, i, j, c))
                        {
                            return false;           //it should not be valid
                        }
                    }
                }
            }
        }
        return true;
    }

    private bool isValid(int[,] board, int row, int col, int c)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i,col] != 0 && board[i,col] == c) return false; //check row
            if (board[row,i] != 0 && board[row,i] == c) return false; //check column
            if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != 0 &&
                board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c) return false; //check 3*3 block
        }
        return true;
    }

}
