using UnityEditor;
using UnityEngine;


namespace GeekbrainsUnityCSharp
{
    [CustomEditor(typeof(ObjectsCreator))]
    public class ObjectsCreatorExt : UnityEditor.Editor
    {
        private bool _isPressButtonOk;

        public override void OnInspectorGUI()
        {
            ObjectsCreator targetOC = (ObjectsCreator)target;

            targetOC.ObjectToCreate = EditorGUILayout.ObjectField("Objects to create", targetOC.ObjectToCreate, typeof(GameObject), true) as GameObject;
            targetOC.NameObject = EditorGUILayout.TextField("Name Prefix", targetOC.NameObject);
            targetOC.RandomColor = EditorGUILayout.Toggle("Random Color", targetOC.RandomColor);
            targetOC.Size = EditorGUILayout.Slider("Size", targetOC.Size, 0.01f, 25.0f);
            targetOC.Offset = EditorGUILayout.IntSlider("Offset", targetOC.Offset, 1, 100);

            var isPressButton = GUILayout.Button("Create objects", EditorStyles.miniButtonLeft);

            _isPressButtonOk = GUILayout.Toggle(_isPressButtonOk, "Show options for the main object");

            if (isPressButton)
            {
                targetOC.CreateObjs();
                _isPressButtonOk = true;
            }

            if (_isPressButtonOk)
            {
                targetOC.Test = EditorGUILayout.Slider(targetOC.Test, 10, 50);
                EditorGUILayout.HelpBox("The button was pressed", MessageType.Warning);

                var isPressAddButton = GUILayout.Button("Add", EditorStyles.miniButtonLeft);
                var isPressRemoveButton = GUILayout.Button("Remove", EditorStyles.miniButtonLeft);
                if (isPressAddButton)
                {
                    targetOC.AddComponent();
                }
                if (isPressRemoveButton)
                {
                    targetOC.RemoveComponent();
                }
            }
        }
    }
}