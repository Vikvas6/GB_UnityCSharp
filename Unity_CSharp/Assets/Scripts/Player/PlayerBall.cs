using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    public class PlayerBall : PlayerBase
    {

        #region Contructor

        public PlayerBall(float speed) : base(speed)
        {
        }

        #endregion

        #region IUpdatable

        public override void UpdateTick()
        {
            try
            {
                Move();
            }
            catch (OutOfMazeException e)
            {
                Time.timeScale = 0.0f;
                _text.text = e.Message;
            }
        }

        #endregion


    }

}