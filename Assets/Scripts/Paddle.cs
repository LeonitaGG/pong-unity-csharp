using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float padding = 1f;
    float minY;
    float maxY;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding; //added padding so the paddles don't hit the absolute edge
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayers();
    }

    public void MovePlayers()
    {
        if (tag == "Player 1")
        {
            float currentPosY = Input.GetAxis("Vertical2") * Time.deltaTime * movementSpeed;
            float newPosY = transform.position.y + currentPosY;
            float yPos = Mathf.Clamp(newPosY, minY, maxY); //use Mathf.Clamp to keep the Paddle within 2 values of Y (*so it doesn't go off the edge of the gamespace)
            transform.position = new Vector2(transform.position.x, yPos);
        }
        if (tag == "Player 2")
        {
            float currentPosY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
            float newPosY = transform.position.y + currentPosY;
            float yPos = Mathf.Clamp(newPosY, minY, maxY); 
            transform.position = new Vector2(transform.position.x, yPos);
        }
    }



}
