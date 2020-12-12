using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace GeekbrainsUnityCSharp
{

    public sealed class SaveDataRepo
    {
        private readonly IMyData​<StateData> _data​;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;
        public SaveDataRepo() {
            _data = new JSONSaver<StateData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }
        public void Save(PlayerBase player, InteractiveObject[] bonuses)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var bonusesToSave = new BonusSerializable[bonuses.Length];
            for (int i=0; i<bonuses.Length; i++)
            {
                var bonusToSave = new BonusSerializable();
                bonusToSave.instanceID = bonuses[i].GetInstanceID();
                bonusToSave.position = bonuses[i].transform.position;
                bonusToSave.type = bonuses[i].GetBonusType();
                bonusesToSave[i] = bonusToSave;
            }

            var savePlayer = new StateData
            {
                Position = player.transform.position,
                Name = "Player1",
                Bonuses = bonusesToSave
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerBase player, InteractiveObject[] bonuses, GameObject endBonusPrefab, GameObject speedBonusPrefab, GameObject speedPenaltyPrefab)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                return;
            }
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.name = newPlayer.Name;

            Debug.Log(newPlayer);

            List<int> bonusesIds = new List<int>();
            foreach (var bonus in bonuses)
            {
                bonusesIds.Add(bonus.GetInstanceID());
            }

            foreach (var bonusToLoad in newPlayer.Bonuses)
            {
                if (!bonusesIds.Contains(bonusToLoad.instanceID))
                {
                    if (bonusToLoad.type == "EndBonus")
                    {
                        var go = GameObject.Instantiate(endBonusPrefab);
                        go.GetComponent<EndBonus>().SetIntetactiveController(IntetactiveController.GetInstance());
                        go.transform.position = bonusToLoad.position;
                    }
                    else if (bonusToLoad.type == "SpeedBonus")
                    {
                        var go = GameObject.Instantiate(speedBonusPrefab);
                        go.GetComponent<SpeedBonus>().SetIntetactiveController(IntetactiveController.GetInstance());
                        go.transform.position = bonusToLoad.position;
                    }
                    else if (bonusToLoad.type == "SpeedPenalty")
                    {
                        var go = GameObject.Instantiate(speedPenaltyPrefab);
                        go.GetComponent<SpeedBonus>().SetIntetactiveController(IntetactiveController.GetInstance());
                        go.transform.position = bonusToLoad.position;
                    } else
                    {
                        Debug.Log(bonusToLoad.type);
                    }
                }
            }
        }
    }
}