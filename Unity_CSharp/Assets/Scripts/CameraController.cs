using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    public sealed class CameraController : MonoBehaviour
    {
        public Player Player;
        
        private Vector3 _offset;

        // https://gist.github.com/ftvs/5822103
        // How long the object should shake for.
        public float shakeDuration = 0f;

        // Amplitude of the shake. A larger value shakes the camera harder.
        public float shakeAmount = 0.2f;
        public float decreaseFactor = 1.0f;

        #region UnityMethods

        private void Start()
        {
            _offset = transform.position - Player.transform.position;
            Player.GetComponent<BonusHolder>().PickUpBonusEvent += Shake;
        }

        private void LateUpdate()
        {
            var notShakedPos = Player.transform.position + _offset;

            if (shakeDuration > 0)
            {
                transform.localPosition = notShakedPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                transform.localPosition = notShakedPos;
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
