namespace GeekbrainsUnityCSharp
{
    public class EndBonus : GoodBonus
    {

        #region Methods

        protected override void Interact()
        {
            DisplayBonus($"Найдено ключей: {_intetactiveController.AddEndBonus()}");
        }

        #endregion
    }
}
