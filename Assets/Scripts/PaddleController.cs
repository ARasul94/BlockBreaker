using System;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16;
    [SerializeField] private float minX = -7;
    [SerializeField] private float maxX = 7;
    [SerializeField] private float ballOffset;

    public float BallOffset => ballOffset;

    private BallController _ball;
    private GameStatus _gameStatus;
    private float _startYPos;


    private void Awake()
    {
        _ball = FindObjectOfType<BallController>();
        _gameStatus = FindObjectOfType<GameStatus>();
        _startYPos = transform.position.y;
    }

    private void Update()
    {
        var mousePositionInUnits = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = new Vector2(mousePositionInUnits, _startYPos);
    }

    private float GetXPos()
    {
        if (_gameStatus.AutoPlay)
        {
            return _ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits - screenWidthInUnits / 2;
        }
    }
}
