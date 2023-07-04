using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float xPush;
    [SerializeField] float[] yPush; //added "-10" and "10" values for Y-Push element on Ball gameObject - this will allow the ball to be launched either up/down direction

    [SerializeField] Paddle leftPaddle;
    [SerializeField] Paddle rightPaddle;

    Vector2 leftPaddleToBallVector;
    Vector2 rightPaddleToBallVector;

    Rigidbody2D myRigidBody;
    GameStatus game;
    AudioSource myAudioSource;

    public Vector2 GetBallPosition() { return this.transform.position; }

    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        leftPaddleToBallVector = transform.position - leftPaddle.transform.position;
        rightPaddleToBallVector = transform.position + rightPaddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            ResetBallPosition();
            LaunchBallOnClick();

        }
    }

    public void LockBallToLeftPaddle()
    {
        Vector2 paddlePostion = new Vector2(leftPaddle.transform.position.x, leftPaddle.transform.position.y);
        transform.position = paddlePostion + leftPaddleToBallVector;
    }

    public void LockBallToRightPaddle()
    {
        Vector2 paddlePosition = new Vector2(rightPaddle.transform.position.x, rightPaddle.transform.position.y);
        transform.position = paddlePosition - rightPaddleToBallVector;
    }

    public void LaunchBallOnClick()
    {
        if (Input.GetKeyDown("space"))
        {
            hasStarted = true;
            float yDirection = yPush[Random.Range(0, yPush.Length)]; //set it so on pressing space, the ball will go in either of 2 directions (*from the 2 values in the yPush array), this randomises on each press
            myRigidBody.velocity = new Vector2(xPush, yDirection);
            //Debug.Log(GetBallPosition());
        }
    }

    public void ResetBallPosition() //method to reset the ball based upon lead in score -> To-do: reset ball to opposing paddle based off whoever just scored
    {
        hasStarted = false;
        game = FindObjectOfType<GameStatus>();

        if (game.playerOneScore >  game.playerTwoScore)
        {
            LockBallToRightPaddle();
        }
        else
        {
            LockBallToLeftPaddle();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (hasStarted == true)
            {
                myAudioSource.Play(); //added sfx that plays when the ball hits any collider (i.e. walls, paddle)
            }

            game = FindObjectOfType<GameStatus>();
            if (game.RandomBounce()) //if "Random Bounce" is enabled on Game status....
            {
                Vector2 velocityTweak = new Vector2(Random.Range(0f, 3f), Random.Range(2f, 5f)); //this randomly changes the trajectory of the ball (within a set range of x/y values) each time the ball collides with wall/paddle
                myRigidBody.velocity += velocityTweak;
            }
    }

}
