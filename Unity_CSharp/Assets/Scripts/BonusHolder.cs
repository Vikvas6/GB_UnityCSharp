using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    public class BonusHolder : MonoBehaviour
    {

        #region Fields

        public delegate void PickUpBonus(string bonusType);
        public event PickUpBonus PickUpBonusEvent;

        [SerializeField] private int _speedBonusTime = 15;
        [SerializeField] private int _bonusesToWin = 5;

        private Player _player;
        private GameEndController _gameEndController;
        private int _endBonusesCount = 0;

        #endregion

        #region UnityMethods

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _gameEndController = new GameEndController();
        }

        #endregion

        #region Methods

        public void AddBonusCommon(string bonusType)
        {
            PickUpBonusEvent?.Invoke(bonusType);
        }

        public int AddEndBonus()
        {
            AddBonusCommon("EndBonus");
            _endBonusesCount++;
            if (_endBonusesCount >= _bonusesToWin)
            {
                _gameEndController.EndGame();
            }
            return _endBonusesCount;
        }

        public void AddSpeedBonus()
        {
            AddBonusCommon("SpeedBonus");
            DoubleSpeed();
            Invoke(nameof(DecreaseSpeed), _speedBonusTime);
        }

        public void AddSpeedPenalty()
        {
            AddBonusCommon("SpeedPenalty");
            DecreaseSpeed();
            Invoke(nameof(DoubleSpeed), _speedBonusTime);
        }

        private void DoubleSpeed()
        {
            _player.Speed *= 2;
        }

        private void DecreaseSpeed()
        {
            _player.Speed /= 2;
        }

        #endregion

    }
}
