using UnityEngine;
using UnityEngine.UI;


namespace GeekbrainsUnityCSharp
{

    public sealed class MakeRadarObject : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Image _ico = null;

        #endregion

        #region UnityMethods

        private void OnValidate()
        {
            //_ico = Resources.Load<Image>($"images/{_icoName}.jpg");
            //print(_ico);
        }

        private void OnDisable()
        {
            Radar.RemoveRadarObject(gameObject);
        }

        private void OnEnable()
        {
            Radar.RegisterRadarObject(gameObject, _ico);
        }

        #endregion

    }
}