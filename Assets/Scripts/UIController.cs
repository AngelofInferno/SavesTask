using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private Text _coinsValueText;
        [SerializeField] private Text _currentLevelText;

        public Slider HpSlider => _hpSlider;

        public Text CoinsValueText => _coinsValueText;

        public Text CurrentLevelText => _currentLevelText;

        private static UIController _instance = null;

        public static UIController Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);
        }
    }
}