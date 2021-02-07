using UnityEngine;

public class BallController : MonoBehaviour
{
    private PaddleController _paddle;
    private Vector3 _offset;
    private void Awake()
    {
        _paddle = FindObjectOfType<PaddleController>();
        _offset = new Vector3(0, _paddle.BallOffset, 0);
    }

    private void Start()
    {
        UpdateBallPositionOnPaddle();
    }

    private void LateUpdate()
    {
        UpdateBallPositionOnPaddle();
    }

    private void UpdateBallPositionOnPaddle()
    {
        transform.position = _paddle.transform.position + _offset;
    }
}
