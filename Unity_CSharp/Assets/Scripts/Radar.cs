using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GeekbrainsUnityCSharp
{

    public sealed class Radar : MonoBehaviour
    {
        private Transform _player;
        private readonly float _mapScare = 4;
        public static List<RadarObject> RadObjects = new List<RadarObject>();

        private void Start()
        {
            _player = Camera.main.transform;
        }

        private void Update()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }

        public static void RegisterRadarObject(GameObject o, Image i)
        {
            Image image = Instantiate(i);
            RadObjects.Add(new RadarObject { Owner = o, Icon = image });
        }

        public static void RemoveRadarObject(GameObject o)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (RadarObject t in RadObjects)
            {
                if (t.Owner == o)
                {
                    Destroy(t.Icon);
                    continue;
                }
                newList.Add(t);
            }
            RadObjects.RemoveRange(0, RadObjects.Count);
            RadObjects.AddRange(newList);
        }

        private void DrawRadarDots()
        {
            foreach (RadarObject radObject in RadObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position - _player.position);
                float distToObject = Vector3.Distance(_player.position, radObject.Owner.transform.position) * _mapScare;
                float deltaY = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - _player.eulerAngles.y;
                radarPos.x = distToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
                radarPos.z = distToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);
                radObject.Icon.transform.SetParent(transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + transform.position;
            }
        }
    }

    public sealed class RadarObject
    {
        public Image Icon;
        public GameObject Owner;
    }
}