using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    public class SaveLoadController : IUpdatable
    {

        private InteractiveObject[] _interactiveObjects;
        private PlayerBase _player;
        private GameObject _endBonusPrefab;
        private GameObject _speedBonusPrefab;
        private GameObject _speedPenaltyPrefab;
        private SaveDataRepo _repo;

        public SaveLoadController(InteractiveObject[] interactiveObjects, PlayerBase player, GameObject endBonusPrefab, GameObject speedBonusPrefab, GameObject speedPenaltyPrefab)
        {
            this._interactiveObjects = interactiveObjects;
            this._player = player;
            this._endBonusPrefab = endBonusPrefab;
            this._speedBonusPrefab = speedBonusPrefab;
            this._speedPenaltyPrefab = speedPenaltyPrefab;
            this._repo = new SaveDataRepo();
        }

        public void UpdateTick()
        {

            if (Input.GetKeyDown(KeyCode.F5))
            {
                _repo.Save(_player, _interactiveObjects);
            }

            if (Input.GetKeyDown(KeyCode.F6))
            {
                _repo.Load(_player, _interactiveObjects, _endBonusPrefab, _speedBonusPrefab, _speedPenaltyPrefab);
            }
        }

    }
}