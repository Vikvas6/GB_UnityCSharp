using UnityEngine;


namespace GeekbrainsUnityCSharp
{

    public class SpeedBonus : GoodBonus
    {

        #region Fields

        [SerializeField] private bool _speedUp = true;

        #endregion

        #region Constructor

        public SpeedBonus()
        {
            _speedUp = true;
        }

        public SpeedBonus(bool speedUp)
        {
            _speedUp = speedUp;
        }

        #endregion

        #region Methods

        protected override void Interact()
        {
            if (_speedUp)
            {
                _intetactiveController.AddSpeedBonus();
                DisplayBonus($"Вы ускорены!");
            }
            else
            {
                _intetactiveController.AddSpeedPenalty();
                DisplayBonus($"Вы замедлены =(");
            }
        }

        public override string GetBonusType()
        {
            if (_speedUp)
            {
                return "SpeedBonus";
            }
            else
            {
                return "SpeedPenalty";
            }
        }

        #endregion
    }
}
