using UnityEngine;
using UnityEditor;

namespace RedLineTeam.RedInspect
{
    [CustomPropertyDrawer(typeof(MinMaxAttribute))]
    public class MinMaxDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            MinMaxAttribute minMax = attribute as MinMaxAttribute;
            
            if (property.propertyType == SerializedPropertyType.Float)
            {
                EditorGUI.BeginProperty(position, label, property);
                
                // Draw the property
                EditorGUI.PropertyField(position, property, label);
                
                // Validate the value
                float value = property.floatValue;
                if (value < minMax.Min || value > minMax.Max)
                {
                    Rect warningRect = position;
                    warningRect.y += EditorGUIUtility.singleLineHeight;
                    warningRect.height = EditorGUIUtility.singleLineHeight;
                    
                    EditorGUI.HelpBox(warningRect, minMax.Message, MessageType.Warning);
                    
                    // Clamp the value
                    property.floatValue = Mathf.Clamp(value, minMax.Min, minMax.Max);
                }
                
                EditorGUI.EndProperty();
            }
            else if (property.propertyType == SerializedPropertyType.Integer)
            {
                EditorGUI.BeginProperty(position, label, property);
                
                // Draw the property
                EditorGUI.PropertyField(position, property, label);
                
                // Validate the value
                int value = property.intValue;
                if (value < minMax.Min || value > minMax.Max)
                {
                    Rect warningRect = position;
                    warningRect.y += EditorGUIUtility.singleLineHeight;
                    warningRect.height = EditorGUIUtility.singleLineHeight;
                    
                    EditorGUI.HelpBox(warningRect, minMax.Message, MessageType.Warning);
                    
                    // Clamp the value
                    property.intValue = Mathf.Clamp(value, (int)minMax.Min, (int)minMax.Max);
                }
                
                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
                EditorGUI.HelpBox(position, "MinMax attribute can only be used on float or integer fields.", MessageType.Error);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            MinMaxAttribute minMax = attribute as MinMaxAttribute;
            float value = property.propertyType == SerializedPropertyType.Float ? property.floatValue : property.intValue;
            
            if (value < minMax.Min || value > minMax.Max)
            {
                return EditorGUIUtility.singleLineHeight * 2;
            }
            
            return EditorGUIUtility.singleLineHeight;
        }
    }
} 