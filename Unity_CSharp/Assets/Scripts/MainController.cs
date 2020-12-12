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
        [SerializeField] private GameObject _endBonusPrefab;
        [SerializeField] private GameObject _speedBonusPrefab;
        [SerializeField] private GameObject _speedPenaltyPrefab;
        [SerializeField] private RenderTexture _screenShot;

        private List<IUpdatable> _updatables = new List<IUpdatable>();
        private GameEndController _gameEndController;
        private GameObject _statusText;
        private PlayerBall _player;
        private SaveDataRepo _repo;
        private Camera _mainCamera;
        private bool _onPause = false;

        #endregion

        #region UnityMethods

        private void Start()
        {
            this._player = FindObjectOfType<PlayerBall>();
            AddUpdatable(_player);

            var interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();

            new InitializerController(this, _player, Camera.main, interactiveObjects);

            _gameEndController = new GameEndController();
            _statusText = GameObject.FindGameObjectWithTag("StatusText");
            _repo = new SaveDataRepo();
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            _screenShot.Release();
            RenderTexture.active = _screenShot;
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

            if (Input.GetKeyDown(KeyCode.F5))
            {
                _repo.Save(_player, FindObjectsOfType<InteractiveObject>());
            }

            if (Input.GetKeyDown(KeyCode.F6))
            {
                _repo.Load(_player, FindObjectsOfType<InteractiveObject>(), _endBonusPrefab, _speedBonusPrefab, _speedPenaltyPrefab);
            }

            if (Input.GetKeyDown(KeyCode.F7))
            {
                _mainCamera.targetTexture = _screenShot;
                _mainCamera.Render();
                _mainCamera.targetTexture = null;
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
            Time.timeScale = 1;
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
