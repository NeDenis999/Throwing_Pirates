using System;
using Unity.VisualScripting;
using UnityEditor;

namespace Throwing_Boxes.Editor
{
    public class DialogEditorWindow : ExtendedEditorWindow
    {
        public static void Open(Dialog dialog)
        {
            DialogEditorWindow window = GetWindow<DialogEditorWindow>("Game Data Editor");
            window._serializedObject = new SerializedObject(dialog);
        }

        private void OnGUI()
        {
            _currentProperty = _serializedObject.FindProperty("Nodes");
            DrawProperties(_currentProperty, true);
        }
    }
}