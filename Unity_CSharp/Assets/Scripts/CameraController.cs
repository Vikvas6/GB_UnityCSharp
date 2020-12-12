using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    public sealed class CameraController : IUpdatable
    {

        #region Fields
        
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;

        // https://gist.github.com/ftvs/5822103
        // How long the object should shake for.
        public float shakeDuration = 0f;
        // Amplitude of the shake. A larger value shakes the camera harder.
        public float shakeAmount = 0.2f;
        public float decreaseFactor = 1.0f;

        #endregion

        #region Constructor

        public CameraController(MainController mainController, Transform player, Transform mainCamera)
        {
            this._player = player;
            this._mainCamera = mainCamera;
            this._mainCamera.LookAt(_player);
            _offset = mainCamera.position - player.position;
            mainController.PickUpBonusEvent += Shake;
        }

        #endregion

        #region IUpdatable

        public void UpdateTick()
        {
            var notShakedPos = _player.position + _offset;

            if (shakeDuration > 0)
            {
                _mainCamera.localPosition = notShakedPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                _mainCamera.localPosition = notShakedPos;
            }
        }

        #endregion

        #region Methods

        private void Shake(string bonusType)
        {
            if ("EndBonus".Equals(bonusType))
            {
                shakeDuration = 1.0f;
            }
            else
            {
                shakeDuration = 0.5f;
            }
        }

        #endregion

    }
}
