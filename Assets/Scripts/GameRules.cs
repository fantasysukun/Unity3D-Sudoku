using UnityEngine;
using System.Collections;


public class GameRules : MonoBehaviour {

    public int Difficult;
    public static int DifficultBonus;
    public int TimeInMinutes;
    float BonusDroppingTime;
    float BigMoveDropTime1;
    float BigMoveDropTime2;
    float P_BigMoveDropTime1;
    float P_BigMoveDropTime2;
    // Use this for initialization
    void Start () {

        Difficult = 1;
        TimeInMinutes = 20;
        BonusDroppingTime = 0;
        DifficultBonus = TimeInMinutes * 3 * Difficult;
        Debug.Log("First DifficultBonus: " + DifficultBonus);

        //Testing
        //GmaeRuleChecking_And_Scoring("Player1", 2, 2, ConditionCheching.Testing9x9Grid_True);
    }

    void Update()
    {
        BonusDroppingTime += Time.deltaTime;
        if (BonusDroppingTime >= 20.0)
        {
            DifficultBonus -= 1;
            Debug.Log("DifficultBonus: " + DifficultBonus);
            BonusDroppingTime = 0;
        }

        
        if (BigMove1.Power >= 2)
        {
            if(P_BigMoveDropTime1 < BigMove1.Power)
            {
                BigMoveDropTime1 -= 3;
            }
            P_BigMoveDropTime1 = BigMove1.Power;

            BigMoveDropTime1 += Time.deltaTime;
            if (BigMoveDropTime1 >= 3.0)
            {
                BigMove1.Power = 1;
            }
            Debug.Log("BigMove1.Power Resest: " + BigMove1.Power);
            BigMoveDropTime1 = 0;
        }

        
        if (BigMove2.Power >= 2)
        {
            BigMoveDropTime2 += Time.deltaTime;
            if (BigMoveDropTime2 >= 3.0)
            {
                BigMove2.Power = 1;
            }
            Debug.Log("BigMove1.Power Resest: " + BigMove2.Power);
            BigMoveDropTime2 = 0;
        }
    }

    //Plz using this method for All Violation Checking 
    /*
    public static bool ViolationChecking(int x, int y, int[,] Grid9x9)
    {

        //         !!!!!!!!!! Attention !!!!!!!!!!
        //!!!!! Converation from Grid9x9 to Grid3x3 here !!!!!
        int[,] Grid3x3 = ConditionCheching.Testing3x3Grid_True;       //Need to conver Grid9x9 to Grid3x3
        int RelatetivePositionX = 0;    //Need to conver x to RelatetivePositionX
        int RelatetivePositionY = 0;    //Need to conver y to RelatetivePositionY
        int GridNumber = 0;             //input Grid number from 0-8, from the first to the last Grid.
        if (ConditionCheching.Violation(x, y, Grid9x9) || ConditionCheching.GridViolation(RelatetivePositionX, RelatetivePositionY, GridNumber, Grid3x3) )
        {
            return true;
        }

        return false;
    }
    */
    //Update Player's Score
    public static void SetPlayerScore(string Player, int score)
    {
        if (Player.Equals("Player1"))
        {
            Score1.score += score;
            print(Score1.score);
            print(DifficultBonus);
        }
        else if (Player.Equals("Player2"))
        {
            Score2.score += score;
        }
        else
        {
            Debug.Log("Error occur in GmaeRuleChecking_And_Scoring input string!!!");
        }
    }

    //Update Player's BigMove
    public static void SetPlayerBigMove(string Player, int BigMove)
    {
        if (Player.Equals("Player1"))
        {
            BigMove1.Power += BigMove;
            print("BigMove1.Power: " + BigMove1.Power);
        }
        else if (Player.Equals("Player2"))
        {
            BigMove2.Power += BigMove;
            print("BigMove2.Power: " + BigMove2.Power);
        }
        else
        {
            Debug.Log("Error occur in GmaeRuleChecking_And_Scoring input string!!!");
        }
    }

    //Update Player's BigMove
    public static int GetPlayerBigMove(string Player)
    {
        if (Player.Equals("Player1"))
        {
            return BigMove1.Power;
        }
        else if (Player.Equals("Player2"))
        {
            return BigMove2.Power;
        }
        return 1;
    }

    public static int[,] GetPlayerBigMoveChecking(string Player)
    {
        if (Player.Equals("Player1"))
        {
            return ConditionCheching1.BigMoveChecking;
        }
        else if (Player.Equals("Player2"))
        {
            return ConditionCheching2.BigMoveChecking;
        }
        return null;
    }

    //Game Main Logic goes here
    public static void GmaeRuleChecking_And_Scoring(string Player, int Row, int Col, int CurrentInput, int[,] PlayerCurrentMap)
    {
        //Debug.Log("GmaeRuleChecking_And_Scoring Running!!!");
        int score = 0;
        int BigMove = 0;


        //Big Move checking will be added later
        //trigger animation
        //3 second 

        //Bigmove current trigger animation
        if (Player.Equals("Player1"))
        {
            BigMove += ConditionCheching1.Specialchecking(PlayerCurrentMap, Row, Col, CurrentInput);
        }
        else if (Player.Equals("Player2"))
        {
            BigMove += ConditionCheching2.Specialchecking(PlayerCurrentMap, Row, Col, CurrentInput);
        }

        /*
        Debug.Log("score: " + score);
        Debug.Log("DifficultBonus: " + DifficultBonus);
        Debug.Log("BigMove: " + BigMove);
        */
        //First checking for Any violation 
        if (!ConditionCheching1.isValid(PlayerCurrentMap, Row, Col, CurrentInput))
        {
            //Debug.Log("ViolationChecking True Running!!!");
            Debug.Log("ViolationChecking True Running!!!");
            SetPlayerBigMove(Player, BigMove);
            score = -10 * DifficultBonus * GetPlayerBigMove(Player);
            SetPlayerScore(Player, score);
        }
        else
        {
            SetPlayerBigMove(Player, BigMove);
            score = 10 * DifficultBonus * GetPlayerBigMove(Player);
            SetPlayerScore(Player, score);
        }
        Debug.Log("score: " + score);

        //Special checking  will be added later
        string result = ConditionCheching1.WinningConditionChecking(numbercontroller.Current9X9Grid);
        Debug.Log("numbercontroller.Current9X9Grid: " + numbercontroller.Current9X9Grid[8, 8]);
        Debug.Log("result: " + result);

    }




}
