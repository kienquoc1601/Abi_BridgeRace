using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        //public Scene scene;
        private static int currentScene = (int)Scene.MainMenu;

        public enum Scene
        {
            MainMenu,
            Lv1,
            Lv2,
            Lv3,
            Lv4,
            Lv5
        }

        public static event Action<Scene> OnGameSceneChanged;
        private void Awake()
        {
            Instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(currentScene.ToString());
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void Load(Scene scene)
        {
            currentScene = (int)scene;
            SceneManager.LoadScene(scene.ToString());
        }
        public void NextLevel()
        {
            int nextScene = currentScene + 1;
            currentScene = nextScene;
            SceneManager.LoadScene(((Scene)nextScene).ToString());
        }
        public void RetryLevel()
        {
            SceneManager.LoadScene(((Scene)currentScene).ToString());
        }
    }
}