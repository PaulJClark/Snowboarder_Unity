using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] int currentScore = 0;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    string scoreInt;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
            Debug.Log(currentScore);
        }

    }

    public void DisableMovement()
    {
        canMove = false;
    }


    void RespondToBoost()
    {
        // if we push up, then speed up
        //otherwise stay at normal speed

        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
            currentScore += 1;
        }

        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
            currentScore += 3;

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
            currentScore += 2;
        }
    }

    public string GetCurrentScore()
    {
        scoreInt= currentScore.ToString();
        return scoreInt;
    }
}
