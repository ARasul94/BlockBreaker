using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextSceneButton : MonoBehaviour
{
    private Button _nextSceneButton;
    
    private void Start()
    {
        _nextSceneButton = GetComponent<Button>();

        if (_nextSceneButton == null)
            throw new Exception("No Button component");
        
        _nextSceneButton.onClick.AddListener(OnNextButtonClicked);
    }

    private void OnDestroy()
    {
        _nextSceneButton.onClick.RemoveListener(OnNextButtonClicked);
    }

    private void OnNextButtonClicked()
    {
        var sceneLoader = FindObjectOfType<SceneLoader>();

        if (sceneLoader == null)
        {
            Debug.LogError("No SceneLoader");
            return;
        }
        
        sceneLoader.LoadNextScene();
    }
}
