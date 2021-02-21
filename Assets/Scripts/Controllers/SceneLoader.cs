using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private ScoreTable scoreTable;
        

        private int _curSceneIndex;
        private int _sceneCount;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _curSceneIndex = SceneManager.GetActiveScene().buildIndex;
            _sceneCount = SceneManager.sceneCountInBuildSettings;
        }

        private void Start()
        {
            SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
        }

        public void LoadNextScene()
        {
            if (_curSceneIndex < _sceneCount - 1)
            {
                _curSceneIndex++;
            }
            else
            {
                _curSceneIndex = 0;
            }
            
            SceneManager.LoadScene(_curSceneIndex);
        }

        private void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            //TODO added logic to update player score info
        }

        public void RetryLevel()
        {
            SceneManager.LoadScene(_curSceneIndex);
        }

        public void LoadGameOverScene()
        {
            _curSceneIndex = _sceneCount - 1;
            SceneManager.LoadScene(_curSceneIndex);
        }

        public string GetCurrentLevelName()
        {
            return SceneManager.GetSceneByBuildIndex(_curSceneIndex).name;
        }
    }
}
