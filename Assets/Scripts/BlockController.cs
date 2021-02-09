using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [Header("links")]
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject sparkleVFX;
    
    [Header("Parameters")]
    [SerializeField] private int scoreForDestroying = 10;
    [SerializeField] private int lifes = 1;
    [SerializeField] private bool breakable = true;


    private LevelController _levelController;
    private GameStatus _gameStatus;

    private void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        _gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Start()
    {
        if (breakable)
            _levelController.AddBreakableBlock();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (breakable)
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        lifes--;
        if (lifes <= 0)
            DestroyBlock();
    }

    private void DestroyBlock()
    {
        PlaySFX();
        PlayVFX();
        AddScore();
        Destroy(gameObject);
        _levelController.RemoveBreakableBlock();
    }

    private void PlaySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void PlayVFX()
    {
        var sparkles = Instantiate(sparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1);
    }

    private void AddScore()
    {
        _gameStatus.AddScore(scoreForDestroying);
    }
}
