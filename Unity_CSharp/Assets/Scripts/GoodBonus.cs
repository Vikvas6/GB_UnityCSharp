using UnityEngine;


namespace GeekbrainsUnityCSharp
{

    public abstract class GoodBonus : InteractiveObject
    {

        #region Fields

        protected BonusHolder _playerBonuses;
        private DisplayBonuses _displayBonuses;

        #endregion

        #region UnityMethods

        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();
            _playerBonuses = GameObject.FindGameObjectWithTag("Player").GetComponent<BonusHolder>();
        }

        #endregion

        #region Methods

        protected void DisplayBonus(string text)
        {
            _displayBonuses.Display(text);
        }

        public new string ToString()
        {
            return $"I am a {nameof(GoodBonus)} class method";
        }

        #endregion

    }
}