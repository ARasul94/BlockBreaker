﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float canvasMin = 1f;
    [SerializeField] float canvasMax = 15f;
    // Start is called before the first frame update

    GameSession theGameSession;
    Ball theBall;
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
        
    }

    // Update is called once per frame
    void Update()
    {   

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), canvasMin, canvasMax);
        transform.position = paddlePos;
    }

    private float GetXPos(){

        if(theGameSession.IsAutoPlayEnabled()){
            return theBall.transform.position.x;
        }else{
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
