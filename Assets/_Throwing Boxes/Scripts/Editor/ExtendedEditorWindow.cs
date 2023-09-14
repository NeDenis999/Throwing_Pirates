using UnityEditor;
using UnityEngine;

namespace Throwing_Boxes.Editor
{
    public class ExtendedEditorWindow : EditorWindow
    {
        protected SerializedObject _serializedObject;
        protected SerializedProperty _currentProperty;

        protected void DrawProperties(SerializedProperty prop, bool isDrawChildren)
        {
            string lastPropPath = string.Empty;

            Debug.Log(prop);
            
            if (prop == null)
                return;
                
            foreach (SerializedProperty p in prop)
            {
                if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
                {
                    EditorGUILayout.BeginHorizontal();
                    p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
                    EditorGUILayout.EndHorizontal();

                    if (p.isExpanded)
                    {
                        EditorGUI.indentLevel++;
                        DrawProperties(p, isDrawChildren);
                        EditorGUI.indentLevel--;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(lastPropPath) && p.propertyPath.Contains(lastPropPath)) { continue;}
                    lastPropPath = p.propertyPath;
                    EditorGUILayout.PropertyField(p, isDrawChildren);
                }
            }
        }
    }
}