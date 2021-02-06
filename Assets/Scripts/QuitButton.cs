using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    private Button _quitButton;
    
    private void Awake()
    {
        _quitButton = GetComponent<Button>();

        if (_quitButton == null)
            throw new Exception("No Button component");
        
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OnDestroy()
    {
        _quitButton.onClick.RemoveListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
