using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0, 5)][SerializeField] private float gameSpeed = 1;
    [SerializeField] private bool autoPlay;

    public bool AutoPlay => autoPlay;

    private int _score;
    private ScoreController _scoreController;
    private BallController _ball;

    private void Awake()
    {
        _scoreController = FindObjectOfType<ScoreController>();
        _ball = FindObjectOfType<BallController>();
    }

    private void Start()
    {
        _score = 0;
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            autoPlay = !autoPlay;
        }
    }

    public void AddScore(int additionalScore)
    {
        _score += (int)(additionalScore * _ball.GetBonus());
        _scoreController.UpdateDisplayedScore(_score);
    }
}
