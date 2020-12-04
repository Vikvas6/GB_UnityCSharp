using UnityEngine;

namespace GeekbrainsUnityCSharp
{
    public class InitializerController
    {

        #region Fields

        #endregion

        #region Contructor

        public InitializerController(MainController mainController, PlayerBase player, Camera camera, InteractiveObject[] interactiveObjects)
        {
            mainController.AddUpdatable(new CameraController(mainController, player.transform, camera.transform));

            var intetactiveController = new IntetactiveController(mainController, 15, 5, player);
            for (int i = 0; i < interactiveObjects.Length; i++)
            {
                interactiveObjects[i].SetIntetactiveController(intetactiveController);
            }
        }

        #endregion

    }
}