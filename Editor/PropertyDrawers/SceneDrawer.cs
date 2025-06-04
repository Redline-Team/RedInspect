using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace RedLineTeam.RedInspect
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class SceneDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SceneAttribute sceneAttribute = attribute as SceneAttribute;
            
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.BeginProperty(position, label, property);
                
                // Draw the property
                EditorGUI.PropertyField(position, property, label);
                
                // Validate the scene
                if (property.objectReferenceValue != null)
                {
                    GameObject go = property.objectReferenceValue as GameObject;
                    if (go != null)
                    {
                        var scene = go.scene;
                        if (scene.name != sceneAttribute.RequiredScene)
                        {
                            Rect warningRect = position;
                            warningRect.y += EditorGUIUtility.singleLineHeight;
                            warningRect.height = EditorGUIUtility.singleLineHeight;
                            
                            EditorGUI.HelpBox(warningRect, sceneAttribute.Message, MessageType.Warning);
                            
                            // Add a button to open the correct scene
                            Rect buttonRect = warningRect;
                            buttonRect.y += EditorGUIUtility.singleLineHeight;
                            if (GUI.Button(buttonRect, "Open Required Scene"))
                            {
                                var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(
                                    "Assets/Scenes/" + sceneAttribute.RequiredScene + ".unity");
                                if (sceneAsset != null)
                                {
                                    EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(sceneAsset));
                                }
                                else
                                {
                                    Debug.LogError($"Scene '{sceneAttribute.RequiredScene}' not found!");
                                }
                            }
                        }
                    }
                }
                
                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
                EditorGUI.HelpBox(position, "Scene attribute can only be used on GameObject references.", MessageType.Error);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SceneAttribute sceneAttribute = attribute as SceneAttribute;
            
            if (property.propertyType == SerializedPropertyType.ObjectReference && 
                property.objectReferenceValue != null)
            {
                GameObject go = property.objectReferenceValue as GameObject;
                if (go != null && go.scene.name != sceneAttribute.RequiredScene)
                {
                    return EditorGUIUtility.singleLineHeight * 3; // Extra height for the button
                }
            }
            
            return EditorGUIUtility.singleLineHeight;
        }
    }
} 