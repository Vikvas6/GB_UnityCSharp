using UnityEditor;


namespace GeekbrainsUnityCSharp
{
    public class MenuItems
    {
        [MenuItem("MyMenu/Create Corner Objects")]
        private static void MainMenuOption()
        {
            EditorWindow.GetWindow(typeof(CreationWindow), false, "Create some objects");
        }
    }
}