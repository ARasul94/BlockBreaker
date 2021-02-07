using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private int scoreForDestroying = 10;

    private LevelController _levelController;
    private GameStatus _gameStatus;

    private void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        _gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Start()
    {
        _levelController.AddBreakableBlock();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        _gameStatus.AddScore(scoreForDestroying);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        _levelController.RemoveBreakableBlock();
    }
}
