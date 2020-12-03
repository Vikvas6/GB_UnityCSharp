using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    public class PlayerBall : Player
    {

        #region Contructor

        public PlayerBall(float speed) : base(speed)
        {
        }

        #endregion

        #region UnityMethods

        private void FixedUpdate()
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