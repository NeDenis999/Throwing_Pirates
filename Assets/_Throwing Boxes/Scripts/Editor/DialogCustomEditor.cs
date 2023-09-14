using UnityEditor;
using UnityEngine;

namespace Throwing_Boxes.Editor
{
    [CustomEditor(typeof(Dialog))]
    public class DialogDrawer : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Open Dialog Window"))
            {
                DialogEditorWindow.Open((Dialog)target);
            }
        }
    }
}