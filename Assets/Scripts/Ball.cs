using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    [SerializeField] Paddle paddle1; 
    [SerializeField] float xVel = 0f; 
    [SerializeField] float yVel = 15f; 
    bool hasStarted = false;

    Vector2 paddleToBallVector; 
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector =  transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted){
            LockBallToPaddle(); 
            LaunchOnSpacePressed();
        }
       

    }

    private void LaunchOnSpacePressed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 15f);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle(){
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

}
