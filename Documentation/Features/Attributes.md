# Attributes

RedInspect provides a comprehensive set of attributes to enhance your Unity components with validation, styling, and advanced features.

## Table of Contents

<details>
<summary>Overview</summary>

### What are Attributes?
Attributes in RedInspect provide:
- Field validation
- Component requirements
- Visual customization
- Debug information
- Advanced features

### Key Benefits
- Type-safe validation
- Automatic fixes
- Visual feedback
- Enhanced debugging
- Better organization
</details>

<details>
<summary>Validation Attributes</summary>

### Required
```csharp
[Required("This field is required")]
public GameObject targetObject;
```
Enforces that a field must have a value.

**Properties:**
- `Message`: Custom error message to display

**Supported Types:**
- Object references
- Strings
- Arrays/Lists
- Custom types

**Example:**
```csharp
public class MyComponent : MonoBehaviour
{
    [Required("Player object is required")]
    public GameObject playerObject;
    
    [Required("Name cannot be empty")]
    public string playerName;
    
    [Required("At least one item is required")]
    public List<Item> inventory;
}
```

### MinMax
```csharp
[MinMax(0f, 100f)]
public float health;
```
Enforces a numeric value to be within a specified range.

**Properties:**
- `Min`: Minimum allowed value
- `Max`: Maximum allowed value

**Supported Types:**
- float
- int
- Vector2
- Vector3
- Vector4

**Example:**
```csharp
public class Stats : MonoBehaviour
{
    [MinMax(0f, 100f)]
    public float health;
    
    [MinMax(0, 100)]
    public int level;
    
    [MinMax(0f, 1f)]
    public Vector2 normalizedPosition;
}
```

### Tag
```csharp
[Tag("Player")]
public GameObject playerObject;
```
Enforces that a GameObject must have a specific tag.

**Properties:**
- `Tag`: Required tag name

**Supported Types:**
- GameObject
- Component references

**Example:**
```csharp
public class GameManager : MonoBehaviour
{
    [Tag("Player")]
    public GameObject player;
    
    [Tag("Enemy")]
    public Transform[] enemySpawnPoints;
}
```

### Layer
```csharp
[Layer("UI")]
public GameObject uiElement;
```
Enforces that a GameObject must be on a specific layer.

**Properties:**
- `Layer`: Required layer name

**Supported Types:**
- GameObject
- Component references

**Example:**
```csharp
public class UIManager : MonoBehaviour
{
    [Layer("UI")]
    public Canvas mainCanvas;
    
    [Layer("UI")]
    public GameObject[] uiElements;
}
```

### Scene
```csharp
[Scene("MainMenu")]
public GameObject menuObject;
```
Enforces that a GameObject must be in a specific scene.

**Properties:**
- `Scene`: Required scene name

**Supported Types:**
- GameObject
- Component references

**Example:**
```csharp
public class SceneManager : MonoBehaviour
{
    [Scene("MainMenu")]
    public GameObject menuUI;
    
    [Scene("Gameplay")]
    public GameObject player;
}
```

### Prefab
```csharp
[Prefab]
public GameObject prefabInstance;
```
Enforces that a GameObject must be a prefab instance.

**Properties:**
- `Required`: Whether the object must be a prefab (default: true)

**Supported Types:**
- GameObject
- Component references

**Example:**
```csharp
public class PrefabManager : MonoBehaviour
{
    [Prefab]
    public GameObject[] prefabInstances;
    
    [Prefab(Required = false)]
    public GameObject optionalPrefab;
}
```
</details>

<details>
<summary>Component Attributes</summary>

### RedInspect
```csharp
[RedInspect]
public class MyComponent : MonoBehaviour
```
Enables RedInspect features for a component.

**Properties:**
- `ShowHeader`: Whether to show the component header (default: true)
- `ShowValidation`: Whether to show validation section (default: true)
- `ShowDebug`: Whether to show debug section (default: false)
- `ShowHistory`: Whether to show history section (default: true)
- `ShowPresets`: Whether to show presets section (default: true)

**Example:**
```csharp
[RedInspect(ShowDebug = true)]
public class DebugComponent : MonoBehaviour
{
    // Component implementation
}
```

### RequireComponent
```csharp
[RequireComponent(typeof(Rigidbody))]
public class PhysicsObject : MonoBehaviour
```
Enforces that a component requires other components to be present.

**Properties:**
- `ComponentType`: Type of required component

**Example:**
```csharp
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PhysicsObject : MonoBehaviour
{
    // Component implementation
}
```
</details>

<details>
<summary>Debug Attributes</summary>

### Debug
```csharp
[Debug]
public float debugValue;
```
Enables debug visualization for a field.

**Properties:**
- `Label`: Custom label for debug display
- `Format`: Format string for value display
- `Color`: Color for debug visualization

**Supported Types:**
- All serializable types

**Example:**
```csharp
public class DebugComponent : MonoBehaviour
{
    [Debug(Label = "Player Health", Color = "red")]
    public float health;
    
    [Debug(Format = "F2")]
    public Vector3 position;
}
```

### DebugRange
```csharp
[DebugRange(0f, 100f)]
public float debugValue;
```
Enables debug visualization with range limits.

**Properties:**
- `Min`: Minimum value
- `Max`: Maximum value
- `Color`: Color for debug visualization

**Supported Types:**
- float
- int
- Vector2
- Vector3
- Vector4

**Example:**
```csharp
public class DebugComponent : MonoBehaviour
{
    [DebugRange(0f, 100f, Color = "green")]
    public float health;
    
    [DebugRange(0f, 1f)]
    public Vector2 normalizedPosition;
}
```
</details>

<details>
<summary>Custom Attributes</summary>

### Custom Validation
```csharp
[CustomValidation(typeof(MyValidator))]
public class MyComponent : MonoBehaviour
```
Enables custom validation for a component.

**Properties:**
- `ValidatorType`: Type of validator to use
- `Message`: Custom validation message

**Example:**
```csharp
[CustomValidation(typeof(HealthValidator))]
public class HealthComponent : MonoBehaviour
{
    public float health;
    public float maxHealth;
}

public class HealthValidator : IValidator
{
    public ValidationResult Validate(Component component)
    {
        var health = component as HealthComponent;
        if (health.health > health.maxHealth)
        {
            return new ValidationResult
            {
                IsValid = false,
                Message = "Health cannot exceed max health"
            };
        }
        return ValidationResult.Valid;
    }
}
```
</details>

## Best Practices

1. **Validation Attributes**
   - Use appropriate validation types
   - Provide clear error messages
   - Combine multiple validations
   - Handle edge cases

2. **Component Attributes**
   - Use RequireComponent for dependencies
   - Enable debug features when needed
   - Document custom attributes
   - Test thoroughly

3. **Debug Attributes**
   - Use meaningful labels
   - Choose appropriate colors
   - Format values clearly
   - Group related debug info

## Examples

### Complex Validation
```csharp
[RedInspect]
public class PlayerComponent : MonoBehaviour
{
    [Required("Player object is required")]
    [Tag("Player")]
    [Layer("Player")]
    public GameObject playerObject;
    
    [Required("Name cannot be empty")]
    [MinMax(1, 50)]
    public string playerName;
    
    [MinMax(0f, 100f)]
    [Debug(Label = "Health", Color = "red")]
    public float health;
    
    [MinMax(0f, 100f)]
    [Debug(Label = "Stamina", Color = "green")]
    public float stamina;
}
```

### Debug Visualization
```csharp
[RedInspect(ShowDebug = true)]
public class DebugComponent : MonoBehaviour
{
    [Debug(Label = "Position", Format = "F2")]
    public Vector3 position;
    
    [Debug(Label = "Rotation", Format = "F1")]
    public Vector3 rotation;
    
    [DebugRange(0f, 1f, Color = "blue")]
    public float normalizedValue;
}
```

## Troubleshooting

<details>
<summary>Common Issues</summary>

### Validation Issues
- Check attribute parameters
- Verify supported types
- Handle null values
- Test edge cases

### Debug Issues
- Check debug settings
- Verify color values
- Format values properly
- Group debug info

### Custom Issues
- Verify validator implementation
- Check attribute usage
- Handle errors properly
- Test thoroughly
</details>

## API Reference

For detailed API documentation, see the [API Reference](../API/README.md#attributes).

## Related Features

- [Validation](../Features/Validation.md)
- [Debugging](../Features/Debug.md)
- [Customization](../Customization/README.md) 