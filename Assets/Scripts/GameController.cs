using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        private GameModel _gameModel;

        private GameState _currentGameState;

        private static GameController _instance = null;

        public static GameController Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            _currentGameState = GameState.NONE;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _gameModel = new GameModel(0);
        }

        private void Update()
        {
            if (InputController.Instance.IsSaving)
            {
                SaveAllData();
            }
        }

        public int GetCurrentLevel()
        {
            return _gameModel.CurrentGameLevel;
        }

        public GameState GetCurrentState()
        {
            return _currentGameState;
        }

        public void ChangeLevel()
        {
            _gameModel.CurrentGameLevel++;
            SceneManager.LoadScene($"Level{_gameModel.CurrentGameLevel}");
        }

        public void StartLevel()
        {
            _currentGameState = GameState.START;
            ChangeLevel();
        }

        public void LoadLevel()
        {
            _currentGameState = GameState.LOAD;
            _gameModel = SaveLoadController.LoadGameData();
            SceneManager.LoadScene($"Level{_gameModel.CurrentGameLevel}");
        }

        public void SaveAllData()
        {
            var model = PlayerStatusController.Instance.GetDefaultData();
            SaveLoadController.SaveData(new object[]{model, _gameModel});
        }

        /*public void LoadAllData()
        {
            var model = SaveLoadController.LoadPlayerData();
            PlayerStatusController.Instance.SetDefaultData(model);
            Debug.Log(model.Hp);
        }*/
    }

    public enum GameState
    {
        NONE, START, LOAD
    }
}