using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _sceneLoader.LoadGameOverScene();
    }
}
