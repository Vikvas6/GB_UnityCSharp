using static UnityEngine.Debug;
using static UnityEngine.Application;


namespace GeekbrainsUnityCSharp
{
    public class GameEndController
    {

        #region Fields

        private int _endBonusesToWin;
        private int _endBonusesCount = 0;

        #endregion

        #region Constructor

        public GameEndController(int endBonusesToWin)
        {
            this._endBonusesToWin = endBonusesToWin;
        }

        #endregion

        #region Methods

        public void EndGame()
        {
            Log("EndGame");
            Quit();
        }

        public (bool isVictory, int endBonusesCount) AddEndBonus()
        {
            _endBonusesCount++;
            if (_endBonusesCount >= _endBonusesToWin)
            {
                return (true, _endBonusesCount);
            }
            return (false, _endBonusesCount);
        }

        #endregion
    }
}
