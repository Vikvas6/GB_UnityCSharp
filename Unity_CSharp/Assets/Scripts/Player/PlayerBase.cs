using UnityEngine;
using UnityEngine.UI;


namespace GeekbrainsUnityCSharp
{
    public abstract class PlayerBase : MonoBehaviour, IUpdatable
    {

        #region Fields

        public float Speed = 3.0f;

        protected Text _text;

        private Rigidbody _rigidbody;

        #endregion

        #region Contructor

        public PlayerBase(float speed)
        {
            this.Speed = speed;
        }

        #endregion

        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _text = FindObjectOfType<Text>();
        }

        #endregion

        #region Methods

        public abstract void UpdateTick();

        public void AddSpeedBonus(float timer)
        {
            DoubleSpeed();
            Invoke(nameof(DecreaseSpeed), timer);
        }

        public void AddSpeedPenalty(float timer)
        {
            DecreaseSpeed();
            Invoke(nameof(DoubleSpeed), timer);
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidbody.AddForce(movement * Speed);


            var x = _rigidbody.position.x;
            var y = _rigidbody.position.y;
            var z = _rigidbody.position.z;

            var is_x_ok = x > 11.0 && x < 22.0;
            var is_y_ok = y > 7.0 && y < 8.0;
            var is_z_ok = z > 12.0 && z < 23.0;

            if (!is_x_ok || !is_y_ok || !is_z_ok)
            {
                throw new OutOfMazeException(_rigidbody.position);
            }
        }

        #endregion

        #region PrivateMethods

        private void DoubleSpeed()
        {
            Speed *= 2;
        }

        private void DecreaseSpeed()
        {
            Speed /= 2;
        }

        #endregion

    }

}