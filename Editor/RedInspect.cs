using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RedLineTeam.RedInspect;

[CustomEditor(typeof(MonoBehaviour), true)]
public class RedInspect : Editor
{
    private bool showAdvancedSettings = false;
    private bool showDebugVisualization = false;
    private bool showPresets = false;
    private bool showHistory = false;
    private string searchText = "";
    private Dictionary<string, bool> foldouts = new Dictionary<string, bool>();
    private Vector2 scrollPosition;
    private List<PropertyInfo> searchableProperties;
    private Dictionary<string, object> presetValues = new Dictionary<string, object>();
    private ComponentStateHistory stateHistory = new ComponentStateHistory();
    
    // Colors
    private Color headerColor = new Color(0.8f, 0.2f, 0.2f);
    private Color sectionColor = new Color(0.2f, 0.2f, 0.2f);
    private Color warningColor = new Color(0.8f, 0.6f, 0.2f);
    private Color errorColor = new Color(0.8f, 0.2f, 0.2f);
    private Color successColor = new Color(0.2f, 0.8f, 0.2f);
    private Color validationColor = new Color(0.2f, 0.6f, 0.8f);
    private Color historyColor = new Color(0.6f, 0.4f, 0.8f);
    private Color debugColor = new Color(0.4f, 0.8f, 0.6f);
    
    // Styles
    private GUIStyle headerStyle;
    private GUIStyle boxStyle;
    private GUIStyle buttonStyle;
    private GUIStyle searchStyle;
    private GUIStyle warningStyle;
    private GUIStyle errorStyle;
    private GUIStyle successStyle;
    private GUIStyle sectionHeaderStyle;
    private GUIStyle foldoutStyle;
    private GUIStyle iconButtonStyle;
    private GUIStyle validationButtonStyle;
    private GUIStyle historyButtonStyle;
    private GUIStyle debugButtonStyle;
    
    // Icons
    private Texture2D warningIcon;
    private Texture2D errorIcon;
    private Texture2D successIcon;
    private Texture2D settingsIcon;
    private Texture2D debugIcon;
    private Texture2D historyIcon;
    private Texture2D presetIcon;
    private Texture2D searchIcon;
    private Texture2D infoIcon;
    private Texture2D componentIcon;

    private void InitializeStyles()
    {
        // Load icons
        warningIcon = EditorGUIUtility.Load("icons/console.warnicon.png") as Texture2D;
        errorIcon = EditorGUIUtility.Load("icons/console.erroricon.png") as Texture2D;
        successIcon = EditorGUIUtility.Load("icons/console.infoicon.png") as Texture2D;
        settingsIcon = EditorGUIUtility.Load("icons/settings.png") as Texture2D;
        debugIcon = EditorGUIUtility.Load("icons/debug.png") as Texture2D;
        historyIcon = EditorGUIUtility.Load("icons/history.png") as Texture2D;
        presetIcon = EditorGUIUtility.Load("icons/preset.png") as Texture2D;
        searchIcon = EditorGUIUtility.Load("icons/search.png") as Texture2D;
        infoIcon = EditorGUIUtility.Load("icons/info.png") as Texture2D;
        componentIcon = EditorGUIUtility.Load("icons/component.png") as Texture2D;

        if (headerStyle == null)
        {
            headerStyle = new GUIStyle(EditorStyles.boldLabel);
            headerStyle.normal.textColor = headerColor;
            headerStyle.fontSize = 16;
            headerStyle.margin = new RectOffset(0, 0, 10, 10);
            headerStyle.alignment = TextAnchor.MiddleCenter;
        }

        if (boxStyle == null)
        {
            boxStyle = new GUIStyle(EditorStyles.helpBox);
            boxStyle.padding = new RectOffset(10, 10, 10, 10);
            boxStyle.margin = new RectOffset(0, 0, 10, 10);
            boxStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/box.png") as Texture2D;
        }

        if (buttonStyle == null)
        {
            buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = Color.white;
            buttonStyle.hover.textColor = Color.white;
            buttonStyle.active.textColor = Color.white;
            buttonStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/button.png") as Texture2D;
            buttonStyle.hover.background = EditorGUIUtility.Load("builtin skins/darkskin/images/button hover.png") as Texture2D;
            buttonStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/button active.png") as Texture2D;
            buttonStyle.padding = new RectOffset(10, 10, 5, 5);
        }

        if (validationButtonStyle == null)
        {
            validationButtonStyle = new GUIStyle(buttonStyle);
            validationButtonStyle.normal.textColor = validationColor;
            validationButtonStyle.hover.textColor = validationColor;
            validationButtonStyle.active.textColor = validationColor;
        }

        if (historyButtonStyle == null)
        {
            historyButtonStyle = new GUIStyle(buttonStyle);
            historyButtonStyle.normal.textColor = historyColor;
            historyButtonStyle.hover.textColor = historyColor;
            historyButtonStyle.active.textColor = historyColor;
        }

        if (debugButtonStyle == null)
        {
            debugButtonStyle = new GUIStyle(buttonStyle);
            debugButtonStyle.normal.textColor = debugColor;
            debugButtonStyle.hover.textColor = debugColor;
            debugButtonStyle.active.textColor = debugColor;
        }

        if (searchStyle == null)
        {
            searchStyle = new GUIStyle(EditorStyles.toolbarSearchField);
            searchStyle.margin = new RectOffset(0, 0, 5, 5);
            searchStyle.fixedHeight = 20;
        }

        if (warningStyle == null)
        {
            warningStyle = new GUIStyle(EditorStyles.helpBox);
            warningStyle.normal.textColor = warningColor;
            warningStyle.padding = new RectOffset(10, 10, 5, 5);
        }

        if (errorStyle == null)
        {
            errorStyle = new GUIStyle(EditorStyles.helpBox);
            errorStyle.normal.textColor = errorColor;
            errorStyle.padding = new RectOffset(10, 10, 5, 5);
        }

        if (successStyle == null)
        {
            successStyle = new GUIStyle(EditorStyles.helpBox);
            successStyle.normal.textColor = successColor;
            successStyle.padding = new RectOffset(10, 10, 5, 5);
        }

        if (sectionHeaderStyle == null)
        {
            sectionHeaderStyle = new GUIStyle(EditorStyles.boldLabel);
            sectionHeaderStyle.normal.textColor = sectionColor;
            sectionHeaderStyle.fontSize = 12;
            sectionHeaderStyle.margin = new RectOffset(0, 0, 5, 5);
        }

        if (foldoutStyle == null)
        {
            foldoutStyle = new GUIStyle(EditorStyles.foldout);
            foldoutStyle.fontStyle = FontStyle.Bold;
            foldoutStyle.margin = new RectOffset(0, 0, 5, 5);
        }

        if (iconButtonStyle == null)
        {
            iconButtonStyle = new GUIStyle(EditorStyles.miniButton);
            iconButtonStyle.padding = new RectOffset(5, 5, 5, 5);
            iconButtonStyle.fixedWidth = 25;
            iconButtonStyle.fixedHeight = 25;
        }
    }

    private void InitializeSearchableProperties()
    {
        if (searchableProperties == null)
        {
            searchableProperties = target.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite)
                .ToList();
        }
    }

    public override void OnInspectorGUI()
    {
        InitializeStyles();
        InitializeSearchableProperties();

        // Draw the default inspector
        DrawDefaultInspector();

        EditorGUILayout.Space(10);

        // Custom Header with icon
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField(new GUIContent("Red Inspector", settingsIcon), headerStyle);
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(5);

        // Search Bar with icon
        EditorGUILayout.BeginHorizontal();
        searchText = EditorGUILayout.TextField(new GUIContent("", searchIcon), searchText, searchStyle);
        if (GUILayout.Button("Clear", EditorStyles.toolbarButton, GUILayout.Width(50)))
        {
            searchText = "";
            GUI.FocusControl(null);
        }
        EditorGUILayout.EndHorizontal();

        // Main Box
        EditorGUILayout.BeginVertical(boxStyle);
        
        // Component Info Section with icon
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField(new GUIContent("Component Information", componentIcon), sectionHeaderStyle);
        DrawComponentInfo();
        EditorGUILayout.EndVertical();
        
        // Validation Section with icon
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField(new GUIContent("Validation", warningIcon), sectionHeaderStyle);
        DrawValidationSection();
        EditorGUILayout.EndVertical();
        
        // Advanced Settings Section with icon
        showAdvancedSettings = EditorGUILayout.Foldout(showAdvancedSettings, new GUIContent("Advanced Settings", settingsIcon), true, foldoutStyle);
        if (showAdvancedSettings)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            DrawAdvancedSettings();
            EditorGUILayout.EndVertical();
        }

        // Debug Visualization Section with icon
        showDebugVisualization = EditorGUILayout.Foldout(showDebugVisualization, new GUIContent("Debug Visualization", debugIcon), true, foldoutStyle);
        if (showDebugVisualization)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            DrawDebugVisualization();
            EditorGUILayout.EndVertical();
        }

        // History Section with icon
        showHistory = EditorGUILayout.Foldout(showHistory, new GUIContent("Component History", historyIcon), true, foldoutStyle);
        if (showHistory)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            DrawHistorySection();
            EditorGUILayout.EndVertical();
        }

        // Presets Section with icon
        showPresets = EditorGUILayout.Foldout(showPresets, new GUIContent("Presets", presetIcon), true, foldoutStyle);
        if (showPresets)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            DrawPresetsSection();
            EditorGUILayout.EndVertical();
        }

        // Custom Actions Section with icon
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField(new GUIContent("Custom Actions", settingsIcon), sectionHeaderStyle);
        DrawCustomActions();
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndVertical();
    }

    private void DrawComponentInfo()
    {
        EditorGUI.indentLevel++;
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("Type", infoIcon), EditorStyles.boldLabel);
        EditorGUILayout.LabelField(target.GetType().Name);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("GameObject", componentIcon), EditorStyles.boldLabel);
        EditorGUILayout.LabelField(target.name);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("Instance ID", infoIcon), EditorStyles.boldLabel);
        EditorGUILayout.LabelField(target.GetInstanceID().ToString());
        EditorGUILayout.EndHorizontal();
        
        EditorGUI.indentLevel--;
    }

    private void DrawValidationSection()
    {
        EditorGUILayout.LabelField(new GUIContent("Validation", warningIcon), sectionHeaderStyle);
        EditorGUI.indentLevel++;

        bool hasErrors = false;
        bool hasWarnings = false;

        // Check for required components
        var requireComponentAttrs = target.GetType().GetCustomAttributes(typeof(RequireComponentAttribute), true);
        foreach (RequireComponentAttribute attr in requireComponentAttrs)
        {
            foreach (var requiredType in attr.RequiredTypes)
            {
                if (!attr.AllowMissing && (target as Component)?.GetComponent(requiredType) == null)
                {
                    hasErrors = true;
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.HelpBox($"Required component '{requiredType.Name}' is missing!", MessageType.Error);
                    if (GUILayout.Button("Add Component", validationButtonStyle, GUILayout.Width(100)))
                    {
                        var component = target as Component;
                        if (component != null)
                        {
                            Undo.AddComponent(component.gameObject, requiredType);
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
        }

        // Check for required fields
        var requiredFields = target.GetType().GetFields()
            .Where(f => f.GetCustomAttributes(typeof(RequiredAttribute), true).Length > 0);

        foreach (var field in requiredFields)
        {
            var value = field.GetValue(target);
            if (value == null)
            {
                hasErrors = true;
                var attr = field.GetCustomAttribute<RequiredAttribute>();
                EditorGUILayout.HelpBox(attr.Message, MessageType.Error);
            }
        }

        // Check for tag requirements
        var tagFields = target.GetType().GetFields()
            .Where(f => f.GetCustomAttributes(typeof(TagAttribute), true).Length > 0);

        foreach (var field in tagFields)
        {
            var value = field.GetValue(target) as GameObject;
            if (value != null)
            {
                var attr = field.GetCustomAttribute<TagAttribute>();
                if (value.tag != attr.RequiredTag)
                {
                    hasWarnings = true;
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.HelpBox(attr.Message, MessageType.Warning);
                    if (GUILayout.Button("Fix Tag", validationButtonStyle, GUILayout.Width(80)))
                    {
                        Undo.RecordObject(value, "Change Tag");
                        value.tag = attr.RequiredTag;
                        EditorUtility.SetDirty(value);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
        }

        // Check for layer requirements
        var layerFields = target.GetType().GetFields()
            .Where(f => f.GetCustomAttributes(typeof(LayerAttribute), true).Length > 0);

        foreach (var field in layerFields)
        {
            var value = field.GetValue(target) as GameObject;
            if (value != null)
            {
                var attr = field.GetCustomAttribute<LayerAttribute>();
                if (value.layer != attr.RequiredLayer)
                {
                    hasWarnings = true;
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.HelpBox(attr.Message, MessageType.Warning);
                    if (GUILayout.Button("Fix Layer", validationButtonStyle, GUILayout.Width(80)))
                    {
                        Undo.RecordObject(value, "Change Layer");
                        value.layer = attr.RequiredLayer;
                        EditorUtility.SetDirty(value);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
        }

        // Check for scene requirements
        var sceneFields = target.GetType().GetFields()
            .Where(f => f.GetCustomAttributes(typeof(SceneAttribute), true).Length > 0);

        foreach (var field in sceneFields)
        {
            var value = field.GetValue(target) as GameObject;
            if (value != null)
            {
                var attr = field.GetCustomAttribute<SceneAttribute>();
                if (value.scene.name != attr.RequiredScene)
                {
                    hasWarnings = true;
                    EditorGUILayout.HelpBox(attr.Message, MessageType.Warning);
                }
            }
        }

        // Check for prefab requirements
        var prefabFields = target.GetType().GetFields()
            .Where(f => f.GetCustomAttributes(typeof(PrefabAttribute), true).Length > 0);

        foreach (var field in prefabFields)
        {
            var value = field.GetValue(target) as GameObject;
            if (value != null)
            {
                var attr = field.GetCustomAttribute<PrefabAttribute>();
                bool isPrefabInstance = PrefabUtility.GetPrefabInstanceStatus(value) != PrefabInstanceStatus.NotAPrefab;
                if (isPrefabInstance != attr.MustBePrefabInstance)
                {
                    hasWarnings = true;
                    EditorGUILayout.HelpBox(attr.Message, MessageType.Warning);
                }
            }
        }

        if (!hasErrors && !hasWarnings)
        {
            EditorGUILayout.HelpBox("All validations passed successfully!", MessageType.Info);
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.Space(5);
    }

    private void DrawDebugVisualization()
    {
        EditorGUI.indentLevel++;
        
        EditorGUILayout.LabelField(new GUIContent("Debug Tools", debugIcon), sectionHeaderStyle);
        
        if (GUILayout.Button("Log Component State", debugButtonStyle))
        {
            LogComponentState();
        }
        
        if (GUILayout.Button("Validate References", debugButtonStyle))
        {
            ValidateReferences();
        }
        
        EditorGUI.indentLevel--;
        EditorGUILayout.Space(5);
    }

    private void DrawPresetsSection()
    {
        EditorGUI.indentLevel++;
        
        EditorGUILayout.LabelField("Save/Load Presets", EditorStyles.boldLabel);
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Save Current as Preset"))
        {
            SaveCurrentAsPreset();
        }
        
        if (GUILayout.Button("Load Selected Preset"))
        {
            LoadSelectedPreset();
        }
        EditorGUILayout.EndHorizontal();
        
        EditorGUI.indentLevel--;
        EditorGUILayout.Space(5);
    }

    private void LogComponentState()
    {
        Debug.Log($"=== Component State: {target.GetType().Name} ===");
        foreach (var prop in searchableProperties)
        {
            Debug.Log($"{prop.Name}: {prop.GetValue(target)}");
        }
    }

    private void ValidateReferences()
    {
        var fields = target.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fields)
        {
            if (field.FieldType.IsSubclassOf(typeof(UnityEngine.Object)))
            {
                var value = field.GetValue(target) as UnityEngine.Object;
                if (value == null)
                {
                    Debug.LogWarning($"Missing reference in field: {field.Name}");
                }
            }
        }
    }

    private void SaveCurrentAsPreset()
    {
        presetValues.Clear();
        foreach (var prop in searchableProperties)
        {
            presetValues[prop.Name] = prop.GetValue(target);
        }
        Debug.Log("Preset saved!");
    }

    private void LoadSelectedPreset()
    {
        if (presetValues.Count == 0)
        {
            Debug.LogWarning("No preset saved!");
            return;
        }

        Undo.RecordObject(target, "Load Preset");
        foreach (var kvp in presetValues)
        {
            var prop = searchableProperties.FirstOrDefault(p => p.Name == kvp.Key);
            if (prop != null)
            {
                prop.SetValue(target, kvp.Value);
            }
        }
        EditorUtility.SetDirty(target);
    }

    private void DrawAdvancedSettings()
    {
        EditorGUI.indentLevel++;
        
        // Example of custom property fields
        EditorGUILayout.LabelField("Custom Properties", EditorStyles.boldLabel);
        
        // Add your custom properties here
        EditorGUILayout.ColorField("Custom Color", Color.red);
        EditorGUILayout.Slider("Custom Value", 0.5f, 0f, 1f);
        
        EditorGUI.indentLevel--;
        EditorGUILayout.Space(5);
    }

    private void DrawCustomActions()
    {
        EditorGUILayout.LabelField("Custom Actions", EditorStyles.boldLabel);
        
        // Example buttons with custom styling
        if (GUILayout.Button("Reset Component", buttonStyle))
        {
            // Add reset logic here
            Debug.Log("Reset component");
        }
        
        if (GUILayout.Button("Copy Settings", buttonStyle))
        {
            // Add copy logic here
            Debug.Log("Copy settings");
        }
        
        if (GUILayout.Button("Paste Settings", buttonStyle))
        {
            // Add paste logic here
            Debug.Log("Paste settings");
        }
    }

    private void DrawHistorySection()
    {
        EditorGUI.indentLevel++;
        
        EditorGUILayout.LabelField(new GUIContent("State History", historyIcon), sectionHeaderStyle);
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Save Current State", historyButtonStyle))
        {
            stateHistory.SaveState(target as Component);
            EditorUtility.SetDirty(target);
        }
        
        GUI.enabled = stateHistory.HasHistory;
        if (GUILayout.Button("Restore Last State", historyButtonStyle))
        {
            Undo.RecordObject(target, "Restore Component State");
            stateHistory.RestoreLatestState(target as Component);
            EditorUtility.SetDirty(target);
        }
        GUI.enabled = true;
        
        if (GUILayout.Button("Clear History", historyButtonStyle))
        {
            stateHistory.ClearHistory();
        }
        EditorGUILayout.EndHorizontal();
        
        EditorGUI.indentLevel--;
        EditorGUILayout.Space(5);
    }

    private bool GetFoldout(string key)
    {
        if (!foldouts.ContainsKey(key))
        {
            foldouts[key] = false;
        }
        return foldouts[key];
    }

    private void SetFoldout(string key, bool value)
    {
        foldouts[key] = value;
    }
} 