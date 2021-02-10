using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class LevelController : MonoBehaviour
    {
        private int _breakableBlocksCount = 0;
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();
        }

        public void AddBreakableBlock()
        {
            _breakableBlocksCount++;
        }
    
        public void RemoveBreakableBlock()
        {
            _breakableBlocksCount--;

            if (_breakableBlocksCount <= 0)
            {
                _sceneLoader.LoadNextScene();
            }
        }
    }
}
