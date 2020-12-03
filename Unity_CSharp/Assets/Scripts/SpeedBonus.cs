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
                _playerBonuses.AddSpeedBonus();
                DisplayBonus($"Вы ускорены!");
            }
            else
            {
                _playerBonuses.AddSpeedPenalty();
                DisplayBonus($"Вы замедлены =(");
            }
        }

        #endregion
    }
}
