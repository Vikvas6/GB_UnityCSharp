using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    public class ObjectsCreator : MonoBehaviour
    {
        public GameObject ObjectToCreate;
        public float Size = 1;
        public bool RandomColor = true;
        public string NameObject = "Object Name";
        public int Offset = 10;

        public float Test;

        private void Start()
        {
            CreateObjs();

        }

        public void CreateObjs()
        {
            Transform root = new GameObject("root").transform;
            CreateObj(ObjectToCreate, Size, RandomColor, NameObject, Offset, Offset, "(1)", root);
            CreateObj(ObjectToCreate, Size, RandomColor, NameObject, Offset, -Offset, "(2)", root);
            CreateObj(ObjectToCreate, Size, RandomColor, NameObject, -Offset, Offset, "(3)", root);
            CreateObj(ObjectToCreate, Size, RandomColor, NameObject, -Offset, -Offset, "(4)", root);
        }

        public static void CreateObj(GameObject objectToCreate, float size, bool randomColor, string name, float x, float z, string suffix, Transform root)
        {
            var pos = new Vector3(x, 0, z);
            GameObject gameObject = Instantiate(objectToCreate, pos, Quaternion.identity);
            gameObject.transform.localScale = new Vector3(size, size, size);
            gameObject.name = name + " " + suffix;
            gameObject.transform.parent = root;
            var renderer = gameObject.GetComponent<Renderer>();
            if (renderer && randomColor)
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        public void AddComponent()
        {
            gameObject.AddComponent<Rigidbody>();
            gameObject.AddComponent<MeshRenderer>();
            gameObject.AddComponent<BoxCollider>();
        }

        public void RemoveComponent()
        {
            DestroyImmediate(GetComponent<Rigidbody>());
            DestroyImmediate(GetComponent<MeshRenderer>());
            DestroyImmediate(GetComponent<BoxCollider>());
        }
    }
}