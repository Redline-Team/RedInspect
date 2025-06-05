using UnityEngine;
using UnityEditor;
using RedLineTeam.RedInspect;

/// <summary>
/// Custom editor for the RedInspectExample component.
/// Provides additional information and guidance in the Inspector.
/// </summary>
[CustomEditor(typeof(RedInspectExample))]
public class RedInspectExampleEditor : Editor
{
    private bool showRequiredFields = true;
    private bool showTagRestrictions = true;
    private bool showLayerRestrictions = true;
    private bool showSceneRestrictions = true;
    private bool showPrefabRestrictions = true;
    private bool showCombinedRestrictions = true;
    private bool showComponentReferences = true;
    private bool showArrayRestrictions = true;
    private bool showNestedComponents = true;
    private bool showScriptableObjects = true;
    private bool showCustomValidation = true;

    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Add custom editor functionality here if needed
        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("This is an example component demonstrating all features of RedInspect.", MessageType.Info);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("RedInspect Features", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox(
            "This component demonstrates all features of RedInspect. " +
            "Try assigning different objects to see the validation in action.",
            MessageType.Info
        );

        EditorGUILayout.Space(5);
        EditorGUILayout.LabelField("Documentation", EditorStyles.boldLabel);
        if (GUILayout.Button("Open Documentation"))
        {
            Application.OpenURL("https://github.com/redline-team/redinspect/wiki");
        }

        EditorGUILayout.Space(5);
        EditorGUILayout.LabelField("Feature Details", EditorStyles.boldLabel);

        // Required Fields
        showRequiredFields = EditorGUILayout.Foldout(showRequiredFields, "Required Fields");
        if (showRequiredFields)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "The [Required] attribute ensures that fields are assigned in the Inspector. " +
                "Unassigned fields will show a warning icon.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Tag Restrictions
        showTagRestrictions = EditorGUILayout.Foldout(showTagRestrictions, "Tag Restrictions");
        if (showTagRestrictions)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "The [Tag] attribute restricts GameObject references to specific tags. " +
                "Objects with incorrect tags will show a warning icon.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Layer Restrictions
        showLayerRestrictions = EditorGUILayout.Foldout(showLayerRestrictions, "Layer Restrictions");
        if (showLayerRestrictions)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "The [Layer] attribute restricts GameObject references to specific layers. " +
                "Objects on incorrect layers will show a warning icon.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Scene Restrictions
        showSceneRestrictions = EditorGUILayout.Foldout(showSceneRestrictions, "Scene Restrictions");
        if (showSceneRestrictions)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "The [Scene] attribute ensures that referenced GameObjects are in specific scenes. " +
                "Objects in incorrect scenes will show a warning icon.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Prefab Restrictions
        showPrefabRestrictions = EditorGUILayout.Foldout(showPrefabRestrictions, "Prefab Restrictions");
        if (showPrefabRestrictions)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "The [Prefab] attribute ensures that referenced GameObjects are prefabs. " +
                "Non-prefab objects will show a warning icon.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Combined Restrictions
        showCombinedRestrictions = EditorGUILayout.Foldout(showCombinedRestrictions, "Combined Restrictions");
        if (showCombinedRestrictions)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "You can combine multiple attributes to create more specific restrictions. " +
                "For example, [Required] + [Tag] ensures both assignment and correct tag.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Component References
        showComponentReferences = EditorGUILayout.Foldout(showComponentReferences, "Component References");
        if (showComponentReferences)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "You can use RedInspect attributes with component references. " +
                "The validation will check both the component and its GameObject.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Array Restrictions
        showArrayRestrictions = EditorGUILayout.Foldout(showArrayRestrictions, "Array Restrictions");
        if (showArrayRestrictions)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "RedInspect attributes work with arrays and lists. " +
                "Each element in the array will be validated individually.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Nested Components
        showNestedComponents = EditorGUILayout.Foldout(showNestedComponents, "Nested Components");
        if (showNestedComponents)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "RedInspect works with nested components and custom types. " +
                "Validation is applied recursively to all fields.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Scriptable Objects
        showScriptableObjects = EditorGUILayout.Foldout(showScriptableObjects, "Scriptable Objects");
        if (showScriptableObjects)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "RedInspect attributes work with ScriptableObjects. " +
                "This is useful for validating project settings and configurations.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }

        // Custom Validation
        showCustomValidation = EditorGUILayout.Foldout(showCustomValidation, "Custom Validation");
        if (showCustomValidation)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox(
                "You can create custom validators by inheriting from PropertyValidator. " +
                "This example ensures GameObjects have a Rigidbody component.",
                MessageType.Info
            );
            EditorGUI.indentLevel--;
        }
    }
} 