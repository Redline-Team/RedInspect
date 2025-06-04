# Advanced Topics

This section covers advanced features and techniques for extending RedInspect's functionality.

## Table of Contents

<details>
<summary>Overview</summary>

### What are Advanced Topics?
Advanced Topics cover:
- Custom property drawers
- Advanced validation
- Performance optimization
- Extension systems
- Advanced debugging
- Custom inspectors

### Key Benefits
- Extended functionality
- Better performance
- Custom solutions
- Advanced debugging
</details>

<details>
<summary>Custom Property Drawers</summary>

### Creating Custom Drawers
```csharp
[CustomPropertyDrawer(typeof(CustomAttribute))]
public class CustomPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Get the custom attribute
        var customAttribute = attribute as CustomAttribute;
        
        // Draw the property
        EditorGUI.BeginProperty(position, label, property);
        
        // Custom drawing logic
        position = EditorGUI.PrefixLabel(position, label);
        
        // Draw the property value
        EditorGUI.PropertyField(position, property, GUIContent.none);
        
        EditorGUI.EndProperty();
    }
}
```

### Advanced Property Drawing
```csharp
[CustomPropertyDrawer(typeof(AdvancedAttribute))]
public class AdvancedPropertyDrawer : PropertyDrawer
{
    private const float SPACING = 5f;
    private const float BUTTON_WIDTH = 60f;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Calculate total height
        float height = EditorGUIUtility.singleLineHeight;
        
        // Add height for additional elements
        if (property.isExpanded)
        {
            height += EditorGUIUtility.singleLineHeight + SPACING;
        }
        
        return height;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        // Draw the main property
        Rect propertyRect = new Rect(position.x, position.y, position.width - BUTTON_WIDTH - SPACING, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(propertyRect, property, label);
        
        // Draw additional button
        Rect buttonRect = new Rect(position.x + position.width - BUTTON_WIDTH, position.y, BUTTON_WIDTH, EditorGUIUtility.singleLineHeight);
        if (GUI.Button(buttonRect, "Advanced"))
        {
            property.isExpanded = !property.isExpanded;
        }
        
        // Draw expanded content
        if (property.isExpanded)
        {
            Rect expandedRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + SPACING, position.width, EditorGUIUtility.singleLineHeight);
            DrawExpandedContent(expandedRect, property);
        }
        
        EditorGUI.EndProperty();
    }

    private void DrawExpandedContent(Rect position, SerializedProperty property)
    {
        // Draw additional property content
        EditorGUI.LabelField(position, "Advanced Settings");
    }
}
```
</details>

<details>
<summary>Advanced Validation</summary>

### Custom Validation Rules
```csharp
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class CustomValidationAttribute : PropertyAttribute
{
    public string Message { get; private set; }
    public ValidationType Type { get; private set; }

    public CustomValidationAttribute(string message, ValidationType type)
    {
        Message = message;
        Type = type;
    }
}

public enum ValidationType
{
    Required,
    Range,
    Pattern,
    Custom
}

[CustomPropertyDrawer(typeof(CustomValidationAttribute))]
public class CustomValidationDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var validationAttribute = attribute as CustomValidationAttribute;
        
        EditorGUI.BeginProperty(position, label, property);
        
        // Draw the property
        EditorGUI.PropertyField(position, property, label);
        
        // Validate the property
        if (!ValidateProperty(property, validationAttribute))
        {
            // Draw validation error
            Rect errorRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.HelpBox(errorRect, validationAttribute.Message, MessageType.Error);
        }
        
        EditorGUI.EndProperty();
    }

    private bool ValidateProperty(SerializedProperty property, CustomValidationAttribute attribute)
    {
        switch (attribute.Type)
        {
            case ValidationType.Required:
                return ValidateRequired(property);
            case ValidationType.Range:
                return ValidateRange(property);
            case ValidationType.Pattern:
                return ValidatePattern(property);
            case ValidationType.Custom:
                return ValidateCustom(property);
            default:
                return true;
        }
    }

    private bool ValidateRequired(SerializedProperty property)
    {
        switch (property.propertyType)
        {
            case SerializedPropertyType.String:
                return !string.IsNullOrEmpty(property.stringValue);
            case SerializedPropertyType.ObjectReference:
                return property.objectReferenceValue != null;
            default:
                return true;
        }
    }

    private bool ValidateRange(SerializedProperty property)
    {
        // Implement range validation
        return true;
    }

    private bool ValidatePattern(SerializedProperty property)
    {
        // Implement pattern validation
        return true;
    }

    private bool ValidateCustom(SerializedProperty property)
    {
        // Implement custom validation
        return true;
    }
}
```
</details>

<details>
<summary>Performance Optimization</summary>

### Caching
```csharp
[RedInspect]
public class OptimizedInspector : Editor
{
    private Dictionary<string, GUIStyle> styleCache;
    private Dictionary<string, Texture2D> iconCache;
    private Dictionary<string, bool> validationCache;

    private void InitializeCaches()
    {
        styleCache = new Dictionary<string, GUIStyle>();
        iconCache = new Dictionary<string, Texture2D>();
        validationCache = new Dictionary<string, bool>();
    }

    private GUIStyle GetStyle(string key)
    {
        if (!styleCache.TryGetValue(key, out var style))
        {
            style = CreateStyle(key);
            styleCache[key] = style;
        }
        return style;
    }

    private Texture2D GetIcon(string key)
    {
        if (!iconCache.TryGetValue(key, out var icon))
        {
            icon = LoadIcon(key);
            iconCache[key] = icon;
        }
        return icon;
    }

    private bool ValidateProperty(string key, SerializedProperty property)
    {
        if (!validationCache.TryGetValue(key, out var isValid))
        {
            isValid = PerformValidation(property);
            validationCache[key] = isValid;
        }
        return isValid;
    }
}
```

### Layout Optimization
```csharp
[RedInspect]
public class OptimizedLayout : Editor
{
    private Rect[] layoutRects;
    private bool[] layoutStates;

    private void InitializeLayout()
    {
        layoutRects = new Rect[10];
        layoutStates = new bool[10];
    }

    public override void OnInspectorGUI()
    {
        // Cache layout calculations
        if (Event.current.type == EventType.Layout)
        {
            CalculateLayout();
        }

        // Use cached layout
        DrawLayout();
    }

    private void CalculateLayout()
    {
        // Calculate and cache layout rectangles
        for (int i = 0; i < layoutRects.Length; i++)
        {
            layoutRects[i] = GUILayoutUtility.GetRect(0, EditorGUIUtility.singleLineHeight);
        }
    }

    private void DrawLayout()
    {
        // Use cached rectangles
        for (int i = 0; i < layoutRects.Length; i++)
        {
            if (layoutStates[i])
            {
                GUI.Box(layoutRects[i], "Section " + i);
            }
        }
    }
}
```
</details>

<details>
<summary>Extension Systems</summary>

### Custom Extensions
```csharp
public interface IRedInspectExtension
{
    void OnInspectorGUI(Editor editor);
    void OnValidate(Editor editor);
    void OnSceneGUI(Editor editor);
}

[RedInspect]
public class ExtendedInspector : Editor
{
    private List<IRedInspectExtension> extensions;

    private void InitializeExtensions()
    {
        extensions = new List<IRedInspectExtension>();
        
        // Load extensions
        var extensionTypes = TypeCache.GetTypesDerivedFrom<IRedInspectExtension>();
        foreach (var type in extensionTypes)
        {
            if (!type.IsAbstract && !type.IsInterface)
            {
                var extension = Activator.CreateInstance(type) as IRedInspectExtension;
                if (extension != null)
                {
                    extensions.Add(extension);
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        // Draw base inspector
        base.OnInspectorGUI();
        
        // Draw extensions
        foreach (var extension in extensions)
        {
            extension.OnInspectorGUI(this);
        }
    }

    public override void OnValidate()
    {
        base.OnValidate();
        
        // Validate extensions
        foreach (var extension in extensions)
        {
            extension.OnValidate(this);
        }
    }

    public override void OnSceneGUI()
    {
        base.OnSceneGUI();
        
        // Draw scene GUI extensions
        foreach (var extension in extensions)
        {
            extension.OnSceneGUI(this);
        }
    }
}
```

### Extension Management
```csharp
public class ExtensionManager
{
    private static ExtensionManager instance;
    public static ExtensionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ExtensionManager();
            }
            return instance;
        }
    }

    private Dictionary<string, IRedInspectExtension> loadedExtensions;
    private List<string> enabledExtensions;

    private ExtensionManager()
    {
        loadedExtensions = new Dictionary<string, IRedInspectExtension>();
        enabledExtensions = new List<string>();
        LoadExtensions();
    }

    private void LoadExtensions()
    {
        // Load extension assemblies
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            try
            {
                var extensionTypes = assembly.GetTypes()
                    .Where(t => typeof(IRedInspectExtension).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface);
                
                foreach (var type in extensionTypes)
                {
                    var extension = Activator.CreateInstance(type) as IRedInspectExtension;
                    if (extension != null)
                    {
                        loadedExtensions[type.FullName] = extension;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load extensions from assembly {assembly.FullName}: {e.Message}");
            }
        }
    }

    public void EnableExtension(string extensionName)
    {
        if (loadedExtensions.ContainsKey(extensionName) && !enabledExtensions.Contains(extensionName))
        {
            enabledExtensions.Add(extensionName);
        }
    }

    public void DisableExtension(string extensionName)
    {
        enabledExtensions.Remove(extensionName);
    }

    public IEnumerable<IRedInspectExtension> GetEnabledExtensions()
    {
        return enabledExtensions
            .Where(name => loadedExtensions.ContainsKey(name))
            .Select(name => loadedExtensions[name]);
    }
}
```
</details>

<details>
<summary>Advanced Debugging</summary>

### Debug Visualization
```csharp
[RedInspect]
public class DebugInspector : Editor
{
    private bool showDebugInfo;
    private Dictionary<string, object> debugValues;
    private List<string> debugLog;

    private void InitializeDebug()
    {
        debugValues = new Dictionary<string, object>();
        debugLog = new List<string>();
    }

    public override void OnInspectorGUI()
    {
        // Draw debug toggle
        showDebugInfo = EditorGUILayout.Toggle("Show Debug Info", showDebugInfo);
        
        if (showDebugInfo)
        {
            DrawDebugInfo();
        }
    }

    private void DrawDebugInfo()
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        
        // Draw debug values
        EditorGUILayout.LabelField("Debug Values", EditorStyles.boldLabel);
        foreach (var kvp in debugValues)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(kvp.Key);
            EditorGUILayout.LabelField(kvp.Value?.ToString() ?? "null");
            EditorGUILayout.EndHorizontal();
        }
        
        // Draw debug log
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Debug Log", EditorStyles.boldLabel);
        foreach (var log in debugLog)
        {
            EditorGUILayout.LabelField(log, EditorStyles.miniLabel);
        }
        
        EditorGUILayout.EndVertical();
    }

    public void LogDebug(string message)
    {
        debugLog.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
        if (debugLog.Count > 100)
        {
            debugLog.RemoveAt(0);
        }
    }

    public void SetDebugValue(string key, object value)
    {
        debugValues[key] = value;
    }
}
```

### Performance Profiling
```csharp
[RedInspect]
public class ProfiledInspector : Editor
{
    private Dictionary<string, float> profileTimes;
    private Dictionary<string, int> profileCounts;

    private void InitializeProfiling()
    {
        profileTimes = new Dictionary<string, float>();
        profileCounts = new Dictionary<string, int>();
    }

    public override void OnInspectorGUI()
    {
        // Draw profiling toggle
        if (EditorGUILayout.Toggle("Show Profiling", false))
        {
            DrawProfilingInfo();
        }
    }

    private void DrawProfilingInfo()
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        
        EditorGUILayout.LabelField("Profiling Information", EditorStyles.boldLabel);
        
        foreach (var kvp in profileTimes)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(kvp.Key);
            EditorGUILayout.LabelField($"{kvp.Value:F3}ms ({profileCounts[kvp.Key]} calls)");
            EditorGUILayout.EndHorizontal();
        }
        
        EditorGUILayout.EndVertical();
    }

    private void ProfileOperation(string operation, Action action)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        
        if (!profileTimes.ContainsKey(operation))
        {
            profileTimes[operation] = 0;
            profileCounts[operation] = 0;
        }
        
        profileTimes[operation] += stopwatch.ElapsedMilliseconds;
        profileCounts[operation]++;
    }
}
```
</details>

## Best Practices

1. **Performance**
   - Cache expensive operations
   - Optimize layout calculations
   - Use object pooling
   - Minimize allocations

2. **Extension Development**
   - Follow interface contracts
   - Handle errors gracefully
   - Document extensions
   - Test thoroughly

3. **Debugging**
   - Use debug visualization
   - Profile performance
   - Log important events
   - Handle edge cases

## Examples

### Custom Inspector with Extensions
```csharp
[RedInspect]
public class AdvancedInspector : Editor
{
    private List<IRedInspectExtension> extensions;
    private DebugInspector debugInspector;
    private ProfiledInspector profiledInspector;

    private void OnEnable()
    {
        InitializeExtensions();
        InitializeDebug();
        InitializeProfiling();
    }

    public override void OnInspectorGUI()
    {
        // Profile the entire inspector
        ProfileOperation("OnInspectorGUI", () =>
        {
            // Draw base inspector
            base.OnInspectorGUI();
            
            // Draw extensions
            foreach (var extension in extensions)
            {
                ProfileOperation($"Extension: {extension.GetType().Name}", () =>
                {
                    extension.OnInspectorGUI(this);
                });
            }
            
            // Draw debug info
            debugInspector.OnInspectorGUI();
            
            // Draw profiling info
            profiledInspector.OnInspectorGUI();
        });
    }
}
```

### Advanced Validation System
```csharp
[RedInspect]
public class ValidationInspector : Editor
{
    private List<IValidationRule> validationRules;
    private Dictionary<string, ValidationResult> validationResults;

    private void InitializeValidation()
    {
        validationRules = new List<IValidationRule>();
        validationResults = new Dictionary<string, ValidationResult>();
        
        // Load validation rules
        var ruleTypes = TypeCache.GetTypesDerivedFrom<IValidationRule>();
        foreach (var type in ruleTypes)
        {
            if (!type.IsAbstract && !type.IsInterface)
            {
                var rule = Activator.CreateInstance(type) as IValidationRule;
                if (rule != null)
                {
                    validationRules.Add(rule);
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        // Draw base inspector
        base.OnInspectorGUI();
        
        // Validate properties
        ValidateProperties();
        
        // Draw validation results
        DrawValidationResults();
    }

    private void ValidateProperties()
    {
        var serializedObject = this.serializedObject;
        var iterator = serializedObject.GetIterator();
        
        while (iterator.Next(true))
        {
            foreach (var rule in validationRules)
            {
                var result = rule.Validate(iterator);
                validationResults[iterator.propertyPath] = result;
            }
        }
    }

    private void DrawValidationResults()
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        
        EditorGUILayout.LabelField("Validation Results", EditorStyles.boldLabel);
        
        foreach (var kvp in validationResults)
        {
            if (!kvp.Value.IsValid)
            {
                EditorGUILayout.HelpBox(kvp.Value.Message, MessageType.Error);
            }
        }
        
        EditorGUILayout.EndVertical();
    }
}
```

## Troubleshooting

<details>
<summary>Common Issues</summary>

### Performance Issues
- Check for expensive operations
- Verify caching
- Monitor memory usage
- Profile critical paths

### Extension Problems
- Verify interface implementation
- Check extension loading
- Handle errors properly
- Test thoroughly

### Debug Issues
- Check debug visualization
- Verify logging
- Monitor profiling
- Handle edge cases
</details>

## API Reference

For detailed API documentation, see the [API Reference](../API/README.md#advanced).

## Related Features

- [Customization](../Customization/README.md)
- [Validation](../Features/Validation.md)
- [Debugging](../Features/Debug.md) 