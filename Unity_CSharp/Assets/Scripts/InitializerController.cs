using UnityEngine;

namespace GeekbrainsUnityCSharp
{
    public class InitializerController
    {

        #region Fields

        #endregion

        #region Contructor

        public InitializerController(MainController mainController, PlayerBase player, Camera camera, InteractiveObject[] interactiveObjects,
                                     GameObject endBonusPrefab, GameObject speedBonusPrefab, GameObject speedPenaltyPrefab)
        {
            mainController.AddUpdatable(new CameraController(mainController, player.transform, camera.transform));

            var intetactiveController = new IntetactiveController(mainController, 15, 5);
            for (int i = 0; i < interactiveObjects.Length; i++)
            {
                interactiveObjects[i].SetIntetactiveController(intetactiveController);
            }

            mainController.AddUpdatable(new SaveLoadController(interactiveObjects, player, endBonusPrefab, speedBonusPrefab, speedPenaltyPrefab));
        }

        #endregion

    }
}