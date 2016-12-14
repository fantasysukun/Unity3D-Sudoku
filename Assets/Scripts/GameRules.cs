using UnityEngine;
using System.Collections;


public class GameRules : MonoBehaviour
{

    public int Difficult;
    public static int DifficultBonus;
    public int TimeInMinutes;
    float BonusDroppingTime;

    public int BigMove1;
    public int BigMove2;
    ConditionCheching conditionCheching;
    // Use this for initialization
    void Start()
    {

        Difficult = 1;
        TimeInMinutes = 20;
        BonusDroppingTime = 0;
        DifficultBonus = TimeInMinutes * 3 * Difficult;
        Debug.Log("First DifficultBonus: " + DifficultBonus);
        BigMove1 = 1;
        BigMove2 = 1;

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

    }

    //Plz using this method for All Violation Checking 
    public static bool ViolationChecking(int x, int y, int[,] Grid9x9)
    {

        //         !!!!!!!!!! Attention !!!!!!!!!!
        //!!!!! Converation from Grid9x9 to Grid3x3 here !!!!!
        int[,] Grid3x3 = ConditionCheching.Testing3x3Grid_True;       //Need to conver Grid9x9 to Grid3x3
        int RelatetivePositionX = 0;    //Need to conver x to RelatetivePositionX
        int RelatetivePositionY = 0;    //Need to conver y to RelatetivePositionY
        int GridNumber = 0;             //input Grid number from 0-8, from the first to the last Grid.
        if (ConditionCheching.Violation(x, y, Grid9x9) || ConditionCheching.GridViolation(RelatetivePositionX, RelatetivePositionY, GridNumber, Grid3x3))
        {
            return true;
        }

        return false;
    }

    //Update Player's Score
    public static void SetPlayerScore(string Player, int score)
    {
        if (Player.Equals("Player1"))
        {
            Score1.score += score;
            print(Score1.score);
            print(DifficultBonus);
            //BigMove = BigMove1;
        }
        else if (Player.Equals("Player2"))
        {
            Score2.score += score;
            //BigMove = BigMove2;
        }
        else
        {
            Debug.Log("Error occur in GmaeRuleChecking_And_Scoring input string!!!");
        }
    }

    //Game Main Logic goes here
    public static void GmaeRuleChecking_And_Scoring(string Player, int x, int y, int[,] PlayerMap)
    {
        //Debug.Log("GmaeRuleChecking_And_Scoring Running!!!");
        int score = 0;
        int BigMove = 1;


        //Big Move checking will be added later

        /*
        Debug.Log("score: " + score);
        Debug.Log("DifficultBonus: " + DifficultBonus);
        Debug.Log("BigMove: " + BigMove);
        */
        //First checking for Any violation 
        if (ViolationChecking(x, y, PlayerMap))
        {
            //Debug.Log("ViolationChecking True Running!!!");
            score = -10 * DifficultBonus * BigMove;
            SetPlayerScore(Player, score);
        }
        else
        {
            //Debug.Log("ViolationChecking False Running!!!");
            score = 10 * DifficultBonus * BigMove;
            SetPlayerScore(Player, score);
        }
        Debug.Log("score: " + score);

        //Special checking  will be added later
        string result = ConditionCheching.WinningConditionChecking(numbercontroller.Current9X9Grid);
        Debug.Log("numbercontroller.Current9X9Grid: " + numbercontroller.Current9X9Grid[8, 8]);
        Debug.Log("result: " + result);

    }


}