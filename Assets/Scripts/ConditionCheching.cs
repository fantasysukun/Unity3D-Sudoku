using UnityEngine;
using System.Collections;

public class ConditionCheching : MonoBehaviour {

    public bool[] Row;
    public bool[] Column;
    public bool[] Grid;
    public bool AllRowFilled;
    public bool AllColumnFilled;
    public bool AllGridFilled;

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

        //Sample Unit Testing
        /*
        Debug.Log("Violation: " +  Violation(0, 0, Testing9x9Grid));
        Debug.Log("GridViolation: " + GridViolation(0, 0, Testing3x3Grid));

        Debug.Log("Violation: " + Violation(0, 0, Testing9x9Grid_False) + " Expected False");
        Debug.Log("GridViolation: " + GridViolation(0, 0, Testing3x3Grid_False) + " Expected True");
        */
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
    public static bool GridViolation(int x, int y, int[,] Grid3x3)
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


    // Update is called once per frame
    void Update () {
	
	}

}
