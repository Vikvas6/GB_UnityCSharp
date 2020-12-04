using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GeekbrainsUnityCSharp
{
    public class MainController : MonoBehaviour
    {

        #region Fields

        public delegate void PickUpBonus(string bonusType);
        public event PickUpBonus PickUpBonusEvent;

        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _victoryMenu;

        private List<IUpdatable> _updatables = new List<IUpdatable>();
        private GameEndController _gameEndController;
        private GameObject _statusText;
        private bool _onPause = false;

        #endregion

        #region UnityMethods

        private void Start()
        {
            var player = FindObjectOfType<PlayerBall>();
            AddUpdatable(player);

            var interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();

            new InitializerController(this, player, Camera.main, interactiveObjects);

            _gameEndController = new GameEndController();
            _statusText = GameObject.FindGameObjectWithTag("StatusText");
        }

        private void Update()
        {
            for (int i = 0; i < _updatables.Count; i++)
            {
                _updatables[i].UpdateTick();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

        #endregion

        #region Methods

        public void FirePickUpBonusEvent(string bonusType)
        {
            PickUpBonusEvent?.Invoke(bonusType);
        }

        public void AddUpdatable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void EndGame()
        {
            _gameEndController.EndGame();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        public void Pause()
        {
            if (!_onPause)
            {
                _onPause = true;
                _mainMenu.SetActive(true);
                _statusText.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {
                _onPause = false;
                _mainMenu.SetActive(false);
                _statusText.SetActive(true);
                Time.timeScale = 1;
            }
        }

        public void GameEndVictory()
        {
            _onPause = true;
            _victoryMenu.SetActive(true);
            _mainMenu.SetActive(false);
            Time.timeScale = 0;
        }

        #endregion
    }
}
