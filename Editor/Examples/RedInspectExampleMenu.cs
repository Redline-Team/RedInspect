using UnityEngine;
using UnityEditor;

/// <summary>
/// Handles menu items for the RedInspect example component.
/// </summary>
public static class RedInspectExampleMenu
{
    [MenuItem("Redline/Modules/RedInspect/Create Example", false, 100)]
    public static void CreateExample()
    {
        // Create a new GameObject
        GameObject go = new GameObject("RedInspect Example");
        
        // Add the example component
        go.AddComponent<RedInspectExample>();
        
        // Select the new GameObject
        Selection.activeGameObject = go;
        
        // Position the camera to look at the new GameObject
        SceneView.lastActiveSceneView?.Frame(new Bounds(go.transform.position, Vector3.one), false);
        
        // Register the creation for undo
        Undo.RegisterCreatedObjectUndo(go, "Create RedInspect Example");

        // Set the text color based on the current theme
        GUI.color = EditorGUIUtility.isProSkin ? Color.white : Color.black;
    }
} 