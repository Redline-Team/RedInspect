# Best Practices

This guide covers best practices for using RedInspect effectively in your Unity projects.

## Attribute Usage

### Required Fields
```csharp
// Good: Clear and specific
[Required]
public Transform playerCamera;

// Bad: Too generic
[Required]
public GameObject obj;
```

### Tag Restrictions
```csharp
// Good: Specific tag
[Tag("Player")]
public GameObject player;

// Bad: Generic tag
[Tag("Untagged")]
public GameObject obj;
```

### Layer Restrictions
```csharp
// Good: Specific layer
[Layer("Enemy")]
public GameObject enemy;

// Bad: Default layer
[Layer("Default")]
public GameObject obj;
```

## Performance Considerations

1. Avoid excessive validation in Update methods
2. Cache validation results when possible
3. Use appropriate validation scopes
4. Consider validation frequency
5. Profile validation performance

## Code Organization

### Component Structure
```csharp
public class PlayerController : MonoBehaviour
{
    // Required references
    [Required]
    public Transform cameraTarget;
    
    // Tag-based references
    [Tag("Enemy")]
    public GameObject[] enemies;
    
    // Layer-based references
    [Layer("Ground")]
    public GameObject ground;
    
    // Prefab references
    [Prefab]
    public GameObject[] spawnablePrefabs;
}
```

### Validation Groups
```csharp
public class GameManager : MonoBehaviour
{
    [Header("Player References")]
    [Required]
    public Transform player;
    
    [Header("Enemy References")]
    [Tag("Enemy")]
    public GameObject[] enemies;
    
    [Header("Environment References")]
    [Layer("Ground")]
    public GameObject ground;
}
```

## Error Handling

1. Provide clear error messages
2. Use appropriate message types
3. Handle edge cases gracefully
4. Log validation errors
5. Consider recovery options

## Editor Integration

### Custom Windows
```csharp
public class RedInspectWindow : EditorWindow
{
    [MenuItem("Window/RedInspect/Validation")]
    public static void ShowWindow()
    {
        GetWindow<RedInspectWindow>("RedInspect Validation");
    }
    
    private void OnGUI()
    {
        // Add validation controls
    }
}
```

### Custom Inspectors
```csharp
[CustomEditor(typeof(MyComponent))]
public class MyComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw default inspector
        DrawDefaultInspector();
        
        // Add custom validation
        ValidateComponent();
    }
    
    private void ValidateComponent()
    {
        // Add validation logic
    }
}
```

## Testing

1. Test validation in different scenarios
2. Verify error messages
3. Check performance impact
4. Test edge cases
5. Validate in different Unity versions

## Documentation

1. Document custom validators
2. Explain validation rules
3. Provide usage examples
4. Include troubleshooting guides
5. Keep documentation up to date

## Common Pitfalls

1. Over-validating fields
2. Missing error handling
3. Poor performance
4. Unclear error messages
5. Inconsistent validation

## Next Steps
- Learn about [Custom Validators](CustomValidators.md)
- Explore [Extending RedInspect](Extending.md)
- Read the [API Documentation](../API/README.md) 