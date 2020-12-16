using UnityEditor;
using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    public class CreationWindow : EditorWindow
    {
        public static GameObject ObjectToCreate;
        public Transform StartPosition;
        public string NameObject = "New object";
        public bool RandomColor = true;
        public bool CreateCenterObject = true;
        public float Size = 1;
        public int Offset = 10;

        private void OnGUI()
        {
            GUILayout.Label("Main settings", EditorStyles.boldLabel);
            ObjectToCreate = EditorGUILayout.ObjectField("Objects to create", ObjectToCreate, typeof(GameObject), true) as GameObject;
            NameObject = EditorGUILayout.TextField("Objects Names prefix", NameObject);
            RandomColor = EditorGUILayout.Toggle("Random color", RandomColor);
            Size = EditorGUILayout.Slider("Objects size", Size, 0.01f, 25.0f);
            Offset = EditorGUILayout.IntSlider("Objects offset", Offset, 1, 100);
            CreateCenterObject = EditorGUILayout.Toggle("Create center?", CreateCenterObject);

            var button = GUILayout.Button("Create objects");
            if (button)
            {
                if (ObjectToCreate)
                {
                    Transform root = new GameObject("root").transform;
                    if (CreateCenterObject)
                    {
                        MyCreateObject(0, 0, "(center)", root);
                    }
                    MyCreateObject(Offset, Offset, "(1)", root);
                    MyCreateObject(Offset, -Offset, "(2)", root);
                    MyCreateObject(-Offset, Offset, "(3)", root);
                    MyCreateObject(-Offset, -Offset, "(4)", root);
                }
            }
        }

        private void MyCreateObject(float x, float z, string suffix, Transform root)
        {
            var pos = new Vector3(x, 0, z);
            GameObject gameObject = Instantiate(ObjectToCreate, pos, Quaternion.identity);
            gameObject.transform.localScale = new Vector3(Size, Size, Size);
            gameObject.name = NameObject + " " + suffix;
            gameObject.transform.parent = root;
            var renderer = gameObject.GetComponent<Renderer>();
            if (renderer && RandomColor)
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }
}
