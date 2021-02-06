using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int _curSceneIndex;
    private int _sceneCount;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _sceneCount = SceneManager.sceneCountInBuildSettings;
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
}
