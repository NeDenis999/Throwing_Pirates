using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Throwing_Boxes.Editor
{
    [CustomPropertyDrawer(typeof(RandomizeAttribute))]
    public class RandomizeAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 32;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Float)
            {
                EditorGUI.BeginProperty(position, label, property);
                
                Rect labelPosition = new Rect(position.x, position.y, position.width, 16);
                Rect buttonPosition = new Rect(position.x, position.y + labelPosition.height, position.width, 16);
            
                EditorGUI.LabelField(labelPosition, label, new GUIContent(property.floatValue.ToString()));
                if (GUI.Button(buttonPosition, "Ramdomize"))
                {
                    RandomizeAttribute randomizeAttribute = (RandomizeAttribute)attribute;
                    property.floatValue = Random.Range(randomizeAttribute.MinValue, randomizeAttribute.MaxValue);
                
                }
                
                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.LabelField(position, "Use RandomizeAttribute with float");
            }
        }
    }
}