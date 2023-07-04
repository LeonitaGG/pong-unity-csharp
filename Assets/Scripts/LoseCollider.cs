using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    GameStatus myGame;
    Ball myBall;

    private void OnTriggerEnter2D(Collider2D collision) //
    {
        myGame = FindObjectOfType<GameStatus>();
        myBall = FindObjectOfType<Ball>();

        if (tag == "Player 2 Score") //added tags to the LoseColliders to differentiate them
        {
            myGame.CalculateScore1();
            myBall.ResetBallPosition();
        }

        if (tag == "Player 1 Score")
        {
            myGame.CalculateScore2();
            myBall.ResetBallPosition();
        }
        
    }

}
