using UnityEngine;
using UnityEditor;

namespace RedLineTeam.RedInspect
{
    [CustomPropertyDrawer(typeof(LayerAttribute))]
    public class LayerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LayerAttribute layerAttribute = attribute as LayerAttribute;
            
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.BeginProperty(position, label, property);
                
                // Draw the property
                EditorGUI.PropertyField(position, property, label);
                
                // Validate the layer
                if (property.objectReferenceValue != null)
                {
                    GameObject go = property.objectReferenceValue as GameObject;
                    if (go != null && go.layer != layerAttribute.RequiredLayer)
                    {
                        Rect warningRect = position;
                        warningRect.y += EditorGUIUtility.singleLineHeight;
                        warningRect.height = EditorGUIUtility.singleLineHeight;
                        
                        EditorGUI.HelpBox(warningRect, layerAttribute.Message, MessageType.Warning);
                    }
                }
                
                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
                EditorGUI.HelpBox(position, "Layer attribute can only be used on GameObject references.", MessageType.Error);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            LayerAttribute layerAttribute = attribute as LayerAttribute;
            
            if (property.propertyType == SerializedPropertyType.ObjectReference && 
                property.objectReferenceValue != null)
            {
                GameObject go = property.objectReferenceValue as GameObject;
                if (go != null && go.layer != layerAttribute.RequiredLayer)
                {
                    return EditorGUIUtility.singleLineHeight * 2;
                }
            }
            
            return EditorGUIUtility.singleLineHeight;
        }
    }
} 