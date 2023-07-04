using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{

    [SerializeField] Text player1Score;
    [SerializeField] Text player2Score;

    [SerializeField] bool speedUp;
    [SerializeField] bool randomBounce;
    //[SerializeField] Ball ballPosition;

    public int playerOneScore = 0;
    public int playerTwoScore = 0;

    //public Vector2 GetBallPosition() { return ballPosition.transform.position; }

    // Start is called before the first frame update
    void Start()
    {
        player1Score = GameObject.Find("Player 1 Score").GetComponent<Text>();
        player2Score = GameObject.Find("Player 2 Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    public void CalculateScore1()
    {
        playerOneScore++;
    }

    public void CalculateScore2()
    {
        playerTwoScore++;
    }

    public void DisplayScore()
    {
        player1Score.text = playerOneScore.ToString();
        player2Score.text = playerTwoScore.ToString();
    }

    public bool SpeedUp() //need to work on implementing this "gamemode"
    {
        return speedUp;
    }

    public bool RandomBounce()
    {
        return randomBounce;
    }
}
