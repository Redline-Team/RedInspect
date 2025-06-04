# Presets

RedInspect provides a powerful preset system that allows you to save and load component configurations quickly and efficiently.

## Table of Contents

<details>
<summary>Overview</summary>

### What are Presets?
Presets are saved configurations that allow you to:
- Save component settings
- Load configurations quickly
- Share settings between components
- Maintain consistent setups

### Key Benefits
- Quick configuration switching
- Consistent component setup
- Easy sharing of settings
- Version control friendly
</details>

<details>
<summary>Saving Presets</summary>

### Manual Saving
```csharp
// In the inspector, click "Save Current as Preset" in the Presets section
// Or use the API:
presetValues.Clear();
foreach (var prop in searchableProperties)
{
    presetValues[prop.Name] = prop.GetValue(target);
}
```

### Automatic Saving
```csharp
[RedInspect]
public class MyComponent : MonoBehaviour
{
    private void OnValidate()
    {
        if (Application.isEditor)
        {
            // Save current values as preset
            SaveCurrentAsPreset();
        }
    }
}
```

### What Gets Saved
- All serialized fields
- Component properties
- Reference values
- Current configuration
</details>

<details>
<summary>Loading Presets</summary>

### Manual Loading
```csharp
// In the inspector, click "Load Selected Preset" in the Presets section
// Or use the API:
if (presetValues.Count > 0)
{
    foreach (var kvp in presetValues)
    {
        var prop = searchableProperties.FirstOrDefault(p => p.Name == kvp.Key);
        if (prop != null)
        {
            prop.SetValue(target, kvp.Value);
        }
    }
}
```

### Selective Loading
```csharp
// Load specific properties
var propertiesToLoad = new[] { "health", "speed" };
foreach (var propName in propertiesToLoad)
{
    if (presetValues.ContainsKey(propName))
    {
        var prop = searchableProperties.FirstOrDefault(p => p.Name == propName);
        if (prop != null)
        {
            prop.SetValue(target, presetValues[propName]);
        }
    }
}
```

### Undo Support
- All preset changes support Unity's undo system
- Changes can be undone/redone
- Maintains editor history
</details>

<details>
<summary>Managing Presets</summary>

### Preset Organization
```csharp
// Create preset categories
var categories = new Dictionary<string, Dictionary<string, object>>();

// Save preset to category
categories["Player"] = new Dictionary<string, object>(presetValues);

// Load preset from category
if (categories.ContainsKey("Player"))
{
    presetValues = new Dictionary<string, object>(categories["Player"]);
}
```

### Preset Validation
```csharp
// Validate preset before loading
private bool ValidatePreset(Dictionary<string, object> preset)
{
    foreach (var kvp in preset)
    {
        var prop = searchableProperties.FirstOrDefault(p => p.Name == kvp.Key);
        if (prop == null || !IsValidValue(prop, kvp.Value))
        {
            return false;
        }
    }
    return true;
}
```

### Preset Persistence
- Presets are saved with the project
- Can be shared between team members
- Supports version control
- Can be exported/imported
</details>

## Best Practices

1. **Preset Management**
   - Use descriptive names
   - Organize by category
   - Validate before loading
   - Document preset purposes

2. **Performance**
   - Limit preset size
   - Use selective loading
   - Cache frequently used presets
   - Clean up unused presets

3. **Workflow Integration**
   - Create presets for common setups
   - Share presets with team
   - Version control presets
   - Document preset usage

## Examples

### Basic Preset Usage
```csharp
[RedInspect]
public class PlayerController : MonoBehaviour
{
    public float health;
    public float speed;
    public Vector3 position;

    private void OnValidate()
    {
        if (Application.isEditor)
        {
            // Save current values as preset
            SaveCurrentAsPreset();
        }
    }
}
```

### Advanced Preset Usage
```csharp
[RedInspect]
public class PresetManager : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, object>> presetCategories;

    private void Awake()
    {
        presetCategories = new Dictionary<string, Dictionary<string, object>>();
    }

    public void SavePreset(string category, string name)
    {
        if (!presetCategories.ContainsKey(category))
        {
            presetCategories[category] = new Dictionary<string, object>();
        }

        var preset = new Dictionary<string, object>();
        foreach (var prop in searchableProperties)
        {
            preset[prop.Name] = prop.GetValue(target);
        }

        presetCategories[category][name] = preset;
        Debug.Log($"Preset saved: {category}/{name}");
    }

    public void LoadPreset(string category, string name)
    {
        if (presetCategories.ContainsKey(category) && 
            presetCategories[category].ContainsKey(name))
        {
            var preset = presetCategories[category][name];
            if (ValidatePreset(preset))
            {
                foreach (var kvp in preset)
                {
                    var prop = searchableProperties.FirstOrDefault(p => p.Name == kvp.Key);
                    if (prop != null)
                    {
                        prop.SetValue(target, kvp.Value);
                    }
                }
                Debug.Log($"Preset loaded: {category}/{name}");
            }
        }
    }
}
```

## Troubleshooting

<details>
<summary>Common Issues</summary>

### Preset Not Saving
- Check serialization
- Verify property access
- Ensure proper initialization
- Check for compilation errors

### Loading Issues
- Verify preset exists
- Check property compatibility
- Ensure proper permissions
- Validate preset data

### Performance Problems
- Reduce preset size
- Use selective loading
- Cache frequently used presets
- Monitor memory usage
</details>

## API Reference

For detailed API documentation, see the [API Reference](../API/README.md#presets).

## Related Features

- [Component History](History.md)
- [Debug Tools](Debug.md)
- [Validation System](Validation.md) 