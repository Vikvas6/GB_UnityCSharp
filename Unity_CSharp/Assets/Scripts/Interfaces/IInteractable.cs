namespace GeekbrainsUnityCSharp
{

    public interface IInteractable : IAction
    {
        bool IsInteractable { get; }
    }
}
