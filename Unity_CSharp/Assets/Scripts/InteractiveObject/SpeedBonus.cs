using UnityEngine;


namespace GeekbrainsUnityCSharp
{

    public class SpeedBonus : GoodBonus
    {

        #region Fields

        [SerializeField] private bool _speedUp = true;

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

        #endregion
    }
}
