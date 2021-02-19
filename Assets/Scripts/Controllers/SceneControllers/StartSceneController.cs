﻿using System;
using Controllers.ChoosePlayer;
using Models;
using UnityEngine;

namespace Controllers.SceneControllers
{
    public class StartSceneController : MonoBehaviour
    {
        [SerializeField] private StartMenu startMenu;
        [SerializeField] private ChoosePlayerController choosePlayer;
        [SerializeField] private CreatePlayerController createPlayer;

        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();

            if (startMenu == null)
                throw new Exception("No StartMenu object in StartSceneController");
            
            if (choosePlayer == null)
                throw new Exception("No ChoosePlayer object in StartSceneController");
            
            if (createPlayer == null)
                throw new Exception("No CreatePlayer object in StartSceneController");
        }

        private void Start()
        {
            startMenu.OnStartClicked.AddListener(OpenChoosePlayerMenu);
            choosePlayer.Initiate(SelectPlayer, OpenCreatePlayerMenu, OpenStartMenu);
            createPlayer.Initiate(SelectPlayer, OpenChoosePlayerMenu);
        }

        private void OpenChoosePlayerMenu()
        {
            startMenu.gameObject.SetActive(false);
            createPlayer.gameObject.SetActive(false);
            choosePlayer.gameObject.SetActive(true);
        }

        private void OpenCreatePlayerMenu()
        {
            startMenu.gameObject.SetActive(false);
            createPlayer.gameObject.SetActive(true);
            choosePlayer.gameObject.SetActive(false);
        }

        private void OpenStartMenu()
        {
            startMenu.gameObject.SetActive(true);
            createPlayer.gameObject.SetActive(false);
            choosePlayer.gameObject.SetActive(false);
        }

        private void SelectPlayer(Player player)
        {
            //TODO Add logic to save player infopla
            
            _sceneLoader.LoadNextScene();
        }
    }
}
