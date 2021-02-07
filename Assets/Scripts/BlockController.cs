using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;

    private LevelController _levelController;

    private void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
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
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        _levelController.RemoveBreakableBlock();
    }
}
