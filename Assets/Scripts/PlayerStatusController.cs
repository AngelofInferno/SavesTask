using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerStatusController : MonoBehaviour
    {
        private PlayerStatusModel _playerStatusModel;
        private PlayerMovement _playerMovement;

        private static PlayerStatusController _instance;

        public static PlayerStatusController Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            if (_playerMovement == null)
            {
                _playerMovement = FindObjectOfType<PlayerMovement>();
            }

            DontDestroyOnLoad(gameObject);
        }
        

        private void Start()
        {
            
            var currentState = GameController.Instance.GetCurrentState();
            _playerStatusModel = new PlayerStatusModel();
            if (currentState == GameState.LOAD)
            {
                var model = SaveLoadController.LoadPlayerData();
                if (model != null)
                {
                    SetDefaultData(model);
                    Debug.Log(_playerStatusModel.Hp);
                }
            }
        }
        

        public void AddScore(int coins)
        {
            _playerStatusModel.Coins += coins;
            UIController.Instance.CoinsValueText.text = $"Coins: {_playerStatusModel.Coins}";
            if (_playerStatusModel.Coins / _playerStatusModel.CoinsToLevelUp >= _playerStatusModel.CurrentLevel)
            {
                _playerStatusModel.CurrentLevel++;
                UIController.Instance.CurrentLevelText.text = $"Player Level: {_playerStatusModel.CurrentLevel}";
            }
        }

        public void DamagePlayer(float hp)
        {
            _playerStatusModel.Hp -= hp;
            UIController.Instance.HpSlider.value = _playerStatusModel.Hp / 100;
        }
        public void SetDefaultData(PlayerStatusModel playerStatusModel)
        {
            _playerStatusModel = playerStatusModel;
            _playerMovement.SetMovement(new Vector3(_playerStatusModel.xPos,
                _playerStatusModel.yPos, _playerStatusModel.zPos));
            //SetMovement(new Vector3(_playerStatusModel.xPos, _playerStatusModel.yPos, _playerStatusModel.zPos));
            UIController.Instance.HpSlider.value = _playerStatusModel.Hp / 100;
            UIController.Instance.CoinsValueText.text = $"Coins: {_playerStatusModel.Coins}";
            UIController.Instance.CurrentLevelText.text = $"Player Level: {_playerStatusModel.CurrentLevel}";
        }

        public PlayerStatusModel GetDefaultData()
        {
            if (_playerMovement == null)
            {
                _playerMovement = FindObjectOfType<PlayerMovement>();
            }
            var vector3 = _playerMovement.GetMovement();
            _playerStatusModel.xPos = vector3.x;
            _playerStatusModel.yPos = vector3.y;
            _playerStatusModel.zPos = vector3.z;
            return _playerStatusModel;
        }
    }
}