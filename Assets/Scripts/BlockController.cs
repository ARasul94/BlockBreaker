using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [Header("links")]
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject sparkleVFX;
    [SerializeField] private Sprite[] lifetimeSprites;
    
    [Header("Components")] 
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Parameters")]
    [SerializeField] private int scoreForDestroying = 10;
    [SerializeField] private bool breakable = true;

    public bool Breakable => breakable;

    private int _lifes = 1;

    private LevelController _levelController;
    private GameStatus _gameStatus;

    private void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        _gameStatus = FindObjectOfType<GameStatus>();
        _lifes = lifetimeSprites.Length;
    }

    private void Start()
    {
        if (breakable)
            _levelController.AddBreakableBlock();
        
        UpdateBlockSprites();
    }

    private void UpdateBlockSprites()
    {
        var sprite = lifetimeSprites[_lifes - 1];

        if (sprite != null)
            spriteRenderer.sprite = sprite;
        else
        {
            Debug.LogError($"Block {gameObject.name} sprite equals to null");
        }
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
        _lifes--;
        if (_lifes <= 0)
            DestroyBlock();
        else
        {
            UpdateBlockSprites();
        }
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
