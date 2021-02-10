using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0, 5)][SerializeField] private float gameSpeed = 1;
    [SerializeField] private bool autoPlay;
    [SerializeField] private EarnedScore spawnTextPrefab;

    public bool AutoPlay => autoPlay;

    private int _score;
    private ScoreController _scoreController;
    private BallController _ball;
    private Transform _canvasTransform;

    private void Awake()
    {
        _scoreController = FindObjectOfType<ScoreController>();
        _canvasTransform = GameObject.FindGameObjectWithTag("GameCanvas").transform;
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

    public void AddScore(int additionalScore, Vector3 position)
    {
        var scoreToAdd = (int) (additionalScore * _ball.GetBonus());
        _score += scoreToAdd;
        _scoreController.UpdateDisplayedScore(_score);

        if (_canvasTransform == null)
            return;
        
        var spawnText = Instantiate(spawnTextPrefab, position, Quaternion.identity, _canvasTransform);
        spawnText.SetValue(scoreToAdd);
    }
}
