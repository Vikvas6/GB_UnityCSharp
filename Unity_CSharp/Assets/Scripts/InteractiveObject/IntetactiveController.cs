using UnityEngine;

namespace GeekbrainsUnityCSharp
{
    public class IntetactiveController
    {

        #region Fields

        private PlayerBase _player;
        private MainController _mainController;
        private static IntetactiveController _singleton;

        private int _speedBonusTime;
        private int _endBonusesToWin;
        private int _endBonusesCount = 0;


        #endregion

        #region Contructor

        public IntetactiveController(MainController mainController, int speedBonusTime, int endBonusesToWin, PlayerBase player)
        {
            this._mainController = mainController;
            this._speedBonusTime = speedBonusTime;
            this._endBonusesToWin = endBonusesToWin;
            this._player = player;

            _singleton = this;
        }

        #endregion

        #region Methods

        public static IntetactiveController GetInstance()
        {
            return _singleton;
        }

        public void AddBonusCommon(string bonusType)
        {
            _mainController.FirePickUpBonusEvent(bonusType);
        }

        public int AddEndBonus()
        {
            Debug.Log("asdf");
            AddBonusCommon("EndBonus");
            _endBonusesCount++;
            if (_endBonusesCount >= _endBonusesToWin)
            {
                _mainController.GameEndVictory();
            }
            return _endBonusesCount;
        }

        public void AddSpeedBonus()
        {
            AddBonusCommon("SpeedBonus");
            _player.AddSpeedBonus(_speedBonusTime);
        }

        public void AddSpeedPenalty()
        {
            AddBonusCommon("SpeedPenalty");
            _player.AddSpeedPenalty(_speedBonusTime);
        }

        #endregion

    }
}
