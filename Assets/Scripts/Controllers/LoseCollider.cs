﻿using UnityEngine;

namespace Controllers
{
    public class LoseCollider : MonoBehaviour
    {
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_sceneLoader != null)
                _sceneLoader.LoadGameOverScene();
        }
    }
}
