# API Reference

This document provides a comprehensive reference for all RedInspect APIs.

## Table of Contents

<details>
<summary>Overview</summary>

### What is the API Reference?
The API Reference covers:
- Core APIs
- Extension APIs
- Validation APIs
- Debug APIs
- Utility APIs

### Key Benefits
- Complete documentation
- Usage examples
- Best practices
- Troubleshooting
</details>

<details>
<summary>Core APIs</summary>

### RedInspect Attribute
```csharp
[AttributeUsage(AttributeTargets.Class)]
public class RedInspectAttribute : Attribute
{
    public bool ShowHeader { get; set; } = true;
    public bool ShowValidation { get; set; } = true;
    public bool ShowDebug { get; set; } = false;
    public bool ShowHistory { get; set; } = true;
    public bool ShowPresets { get; set; } = true;
}
```

### Inspector Base
```csharp
[RedInspect]
public class RedInspectEditor : Editor
{
    protected virtual void OnEnable();
    protected virtual void OnDisable();
    public override void OnInspectorGUI();
    protected virtual void DrawHeader();
    protected virtual void DrawValidation();
    protected virtual void DrawDebug();
    protected virtual void DrawHistory();
    protected virtual void DrawPresets();
}
```
</details>

<details>
<summary>Validation APIs</summary>

### Validation Attributes
```csharp
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class RequiredAttribute : PropertyAttribute
{
    public string Message { get; }
    public RequiredAttribute(string message = "This field is required");
}

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class MinMaxAttribute : PropertyAttribute
{
    public float Min { get; }
    public float Max { get; }
    public MinMaxAttribute(float min, float max);
}

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class TagAttribute : PropertyAttribute
{
    public string Tag { get; }
    public TagAttribute(string tag);
}

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class LayerAttribute : PropertyAttribute
{
    public string Layer { get; }
    public LayerAttribute(string layer);
}
```

### Validation System
```csharp
public interface IValidationRule
{
    ValidationResult Validate(SerializedProperty property);
}

public class ValidationResult
{
    public bool IsValid { get; }
    public string Message { get; }
    public MessageType MessageType { get; }
}

public class ValidationSystem
{
    public static ValidationSystem Instance { get; }
    public void RegisterRule(IValidationRule rule);
    public void UnregisterRule(IValidationRule rule);
    public ValidationResult Validate(SerializedProperty property);
}
```
</details>

<details>
<summary>History APIs</summary>

### Component State
```csharp
public class ComponentState
{
    public string ComponentType { get; }
    public Dictionary<string, object> Values { get; }
    public DateTime Timestamp { get; }
}

public class ComponentStateHistory
{
    public void SaveState(Component component);
    public void RestoreState(Component component, ComponentState state);
    public void ClearHistory();
    public IEnumerable<ComponentState> GetHistory();
}
```
</details>

<details>
<summary>Preset APIs</summary>

### Preset System
```csharp
public class PresetSystem
{
    public static PresetSystem Instance { get; }
    public void SavePreset(string name, Component component);
    public void LoadPreset(string name, Component component);
    public void DeletePreset(string name);
    public IEnumerable<string> GetPresetNames();
}
```
</details>

<details>
<summary>Debug APIs</summary>

### Debug System
```csharp
public class DebugSystem
{
    public static DebugSystem Instance { get; }
    public void Log(string message);
    public void LogWarning(string message);
    public void LogError(string message);
    public void ClearLog();
    public IEnumerable<string> GetLog();
}

public class Profiler
{
    public static Profiler Instance { get; }
    public void BeginSample(string name);
    public void EndSample();
    public void Reset();
    public Dictionary<string, float> GetResults();
}
```
</details>

<details>
<summary>Extension APIs</summary>

### Extension System
```csharp
public interface IRedInspectExtension
{
    void OnInspectorGUI(Editor editor);
    void OnValidate(Editor editor);
    void OnSceneGUI(Editor editor);
}

public class ExtensionManager
{
    public static ExtensionManager Instance { get; }
    public void RegisterExtension(IRedInspectExtension extension);
    public void UnregisterExtension(IRedInspectExtension extension);
    public IEnumerable<IRedInspectExtension> GetExtensions();
}
```
</details>

<details>
<summary>Utility APIs</summary>

### Editor Utilities
```csharp
public static class EditorUtils
{
    public static void DrawHeader(string title, GUIStyle style);
    public static void DrawBox(string content, GUIStyle style);
    public static void DrawButton(string label, Action onClick);
    public static void DrawToggle(string label, bool value, Action<bool> onValueChanged);
}

public static class ValidationUtils
{
    public static bool ValidateRequired(SerializedProperty property);
    public static bool ValidateMinMax(SerializedProperty property, float min, float max);
    public static bool ValidateTag(SerializedProperty property, string tag);
    public static bool ValidateLayer(SerializedProperty property, string layer);
}
```
</details>

## Usage Examples

### Basic Inspector
```csharp
[RedInspect]
public class MyInspector : RedInspectEditor
{
    protected override void OnInspectorGUI()
    {
        // Draw header
        DrawHeader();
        
        // Draw validation
        DrawValidation();
        
        // Draw default inspector
        base.OnInspectorGUI();
    }
}
```

### Custom Validation
```csharp
public class CustomValidationRule : IValidationRule
{
    public ValidationResult Validate(SerializedProperty property)
    {
        // Custom validation logic
        if (!ValidateRequired(property))
        {
            return new ValidationResult
            {
                IsValid = false,
                Message = "This field is required",
                MessageType = MessageType.Error
            };
        }
        
        return new ValidationResult
        {
            IsValid = true,
            Message = "Valid",
            MessageType = MessageType.Info
        };
    }
}
```

### Custom Extension
```csharp
public class CustomExtension : IRedInspectExtension
{
    public void OnInspectorGUI(Editor editor)
    {
        // Draw custom GUI
        EditorGUILayout.LabelField("Custom Extension");
    }
    
    public void OnValidate(Editor editor)
    {
        // Custom validation
    }
    
    public void OnSceneGUI(Editor editor)
    {
        // Custom scene GUI
    }
}
```

## Best Practices

1. **API Usage**
   - Use appropriate APIs
   - Follow naming conventions
   - Handle errors properly
   - Document custom code

2. **Performance**
   - Cache expensive operations
   - Minimize allocations
   - Use appropriate data structures
   - Profile critical paths

3. **Extension Development**
   - Follow interface contracts
   - Handle errors gracefully
   - Document extensions
   - Test thoroughly

## Troubleshooting

<details>
<summary>Common Issues</summary>

### API Issues
- Check API versions
- Verify parameters
- Handle exceptions
- Check documentation

### Performance Issues
- Profile operations
- Check memory usage
- Optimize critical paths
- Use appropriate APIs

### Extension Issues
- Verify interfaces
- Check registration
- Handle errors
- Test thoroughly
</details>

## Related Documentation

- [Features](../Features/README.md)
- [Customization](../Customization/README.md)
- [Advanced Topics](../Advanced/README.md) 