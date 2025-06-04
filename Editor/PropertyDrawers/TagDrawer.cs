using UnityEngine;
using UnityEditor;

namespace RedLineTeam.RedInspect
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            TagAttribute tagAttribute = attribute as TagAttribute;
            
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.BeginProperty(position, label, property);
                
                // Draw the property
                EditorGUI.PropertyField(position, property, label);
                
                // Validate the tag
                if (property.objectReferenceValue != null)
                {
                    GameObject go = property.objectReferenceValue as GameObject;
                    if (go != null && go.tag != tagAttribute.RequiredTag)
                    {
                        Rect warningRect = position;
                        warningRect.y += EditorGUIUtility.singleLineHeight;
                        warningRect.height = EditorGUIUtility.singleLineHeight;
                        
                        EditorGUI.HelpBox(warningRect, tagAttribute.Message, MessageType.Warning);
                    }
                }
                
                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
                EditorGUI.HelpBox(position, "Tag attribute can only be used on GameObject references.", MessageType.Error);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            TagAttribute tagAttribute = attribute as TagAttribute;
            
            if (property.propertyType == SerializedPropertyType.ObjectReference && 
                property.objectReferenceValue != null)
            {
                GameObject go = property.objectReferenceValue as GameObject;
                if (go != null && go.tag != tagAttribute.RequiredTag)
                {
                    return EditorGUIUtility.singleLineHeight * 2;
                }
            }
            
            return EditorGUIUtility.singleLineHeight;
        }
    }
} 