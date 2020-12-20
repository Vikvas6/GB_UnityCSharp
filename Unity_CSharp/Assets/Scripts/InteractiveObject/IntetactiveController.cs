using UnityEngine;

namespace GeekbrainsUnityCSharp
{
    public class IntetactiveController
    {

        #region Fields

        private MainController _mainController;
        private static IntetactiveController _singleton;

        private int _speedBonusTime;


        #endregion

        #region Contructor

        public IntetactiveController(MainController mainController, int speedBonusTime, int endBonusesToWin)
        {
            this._mainController = mainController;
            this._speedBonusTime = speedBonusTime;

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
            AddBonusCommon("EndBonus");            
            return _mainController.AddEndBonus();
        }

        public void AddSpeedBonus()
        {
            AddBonusCommon("SpeedBonus");
            _mainController.AddSpeedBonus(_speedBonusTime);
        }

        public void AddSpeedPenalty()
        {
            AddBonusCommon("SpeedPenalty");
            _mainController.AddSpeedPenalty(_speedBonusTime);
        }

        #endregion

    }
}
