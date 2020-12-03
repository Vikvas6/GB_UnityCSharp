using UnityEngine;
using UnityEngine.UI;

namespace GeekbrainsUnityCSharp
{

    public sealed class DisplayBonuses
    {

        #region Fields

        private Text _text;

        #endregion

        #region Constructor

        public DisplayBonuses()
        {
            _text = Object.FindObjectOfType<Text>();
        }

        #endregion

        #region Methods

        public void Display(string value)
        {
            _text.text = $"{value}";
        }

        #endregion

    }
}
