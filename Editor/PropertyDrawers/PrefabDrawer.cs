using UnityEngine;
using UnityEditor;

namespace RedLineTeam.RedInspect
{
    [CustomPropertyDrawer(typeof(PrefabAttribute))]
    public class PrefabDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            PrefabAttribute prefabAttribute = attribute as PrefabAttribute;
            
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.BeginProperty(position, label, property);
                
                // Draw the property
                EditorGUI.PropertyField(position, property, label);
                
                // Validate the prefab
                if (property.objectReferenceValue != null)
                {
                    GameObject go = property.objectReferenceValue as GameObject;
                    if (go != null)
                    {
                        bool isPrefabInstance = PrefabUtility.GetPrefabInstanceStatus(go) != PrefabInstanceStatus.NotAPrefab;
                        if (isPrefabInstance != prefabAttribute.MustBePrefabInstance)
                        {
                            Rect warningRect = position;
                            warningRect.y += EditorGUIUtility.singleLineHeight;
                            warningRect.height = EditorGUIUtility.singleLineHeight;
                            
                            EditorGUI.HelpBox(warningRect, prefabAttribute.Message, MessageType.Warning);
                            
                            // Add a button to convert to/from prefab
                            Rect buttonRect = warningRect;
                            buttonRect.y += EditorGUIUtility.singleLineHeight;
                            if (GUI.Button(buttonRect, prefabAttribute.MustBePrefabInstance ? 
                                "Convert to Prefab" : "Break Prefab Connection"))
                            {
                                if (prefabAttribute.MustBePrefabInstance)
                                {
                                    // Create a new prefab
                                    string path = EditorUtility.SaveFilePanelInProject(
                                        "Create Prefab",
                                        go.name + ".prefab",
                                        "prefab",
                                        "Please enter a file name to save the prefab to");
                                        
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        PrefabUtility.SaveAsPrefabAsset(go, path);
                                    }
                                }
                                else
                                {
                                    // Break prefab connection
                                    PrefabUtility.UnpackPrefabInstance(go, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
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
                EditorGUI.HelpBox(position, "Prefab attribute can only be used on GameObject references.", MessageType.Error);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            PrefabAttribute prefabAttribute = attribute as PrefabAttribute;
            
            if (property.propertyType == SerializedPropertyType.ObjectReference && 
                property.objectReferenceValue != null)
            {
                GameObject go = property.objectReferenceValue as GameObject;
                if (go != null)
                {
                    bool isPrefabInstance = PrefabUtility.GetPrefabInstanceStatus(go) != PrefabInstanceStatus.NotAPrefab;
                    if (isPrefabInstance != prefabAttribute.MustBePrefabInstance)
                    {
                        return EditorGUIUtility.singleLineHeight * 3; // Extra height for the button
                    }
                }
            }
            
            return EditorGUIUtility.singleLineHeight;
        }
    }
} 