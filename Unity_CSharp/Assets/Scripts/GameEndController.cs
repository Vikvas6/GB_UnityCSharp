using static UnityEngine.Debug;
using static UnityEngine.Application;


namespace GeekbrainsUnityCSharp
{
    public class GameEndController
    {
        #region Methods

        public void EndGame()
        {
            Log("EndGame");
            Quit();
        }

        #endregion
    }
}
