# Debug Tools

RedInspect provides a comprehensive set of debug tools to help you diagnose and fix issues during development.

## Table of Contents

<details>
<summary>Component State Logging</summary>

### Overview
The Component State Logging tool allows you to:
- Log current component state
- Track property changes
- Debug serialization issues
- Monitor component lifecycle

### Usage
```csharp
[RedInspect]
public class MyComponent : MonoBehaviour
{
    public float health;
    public Vector3 position;
    
    private void OnValidate()
    {
        if (Application.isEditor)
        {
            // Log component state
            LogComponentState();
        }
    }
}
```

### Output Format
```
=== Component State: MyComponent ===
health: 100
position: (0, 0, 0)
=== End Component State ===
```
</details>

<details>
<summary>Reference Validation</summary>

### Overview
The Reference Validation tool helps you:
- Find missing references
- Validate component dependencies
- Check scene hierarchy
- Verify prefab connections

### Usage
```csharp
[RedInspect]
public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public UIManager uiManager;
    
    private void OnValidate()
    {
        if (Application.isEditor)
        {
            // Validate references
            ValidateReferences();
        }
    }
}
```

### Validation Types
- Null reference checks
- Component dependency validation
- Scene hierarchy validation
- Prefab connection verification
</details>

<details>
<summary>Debug Visualization</summary>

### Overview
Debug Visualization provides:
- Visual debugging tools
- Component relationship visualization
- State change tracking
- Performance monitoring

### Usage
```csharp
[RedInspect]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    
    private void OnDrawGizmos()
    {
        if (Application.isEditor)
        {
            // Draw debug visualization
            DrawDebugVisualization();
        }
    }
}
```

### Visualization Types
- Component relationships
- State changes
- Performance metrics
- Debug overlays
</details>

## Best Practices

1. **Debug Logging**
   - Use descriptive log messages
   - Include relevant context
   - Log at appropriate levels
   - Clean up debug code

2. **Reference Validation**
   - Validate early and often
   - Check all dependencies
   - Handle null cases
   - Provide clear feedback

3. **Visualization**
   - Keep visualizations clear
   - Use appropriate colors
   - Include legends
   - Consider performance

## Examples

### Basic Debug Setup
```csharp
[RedInspect]
public class EnemyController : MonoBehaviour
{
    public float health;
    public float attackDamage;
    public Transform target;

    private void OnValidate()
    {
        if (Application.isEditor)
        {
            // Log state
            LogComponentState();
            
            // Validate references
            ValidateReferences();
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isEditor)
        {
            // Draw debug visualization
            DrawDebugVisualization();
        }
    }
}
```

### Advanced Debug Usage
```csharp
[RedInspect]
public class DebugManager : MonoBehaviour
{
    private void OnGUI()
    {
        if (Application.isEditor)
        {
            // Draw debug UI
            DrawDebugUI();
        }
    }

    private void DrawDebugUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 200, 300));
        GUILayout.Label("Debug Tools", EditorStyles.boldLabel);
        
        if (GUILayout.Button("Log All Components"))
        {
            LogAllComponents();
        }
        
        if (GUILayout.Button("Validate Scene"))
        {
            ValidateScene();
        }
        
        if (GUILayout.Button("Show Performance"))
        {
            ShowPerformanceMetrics();
        }
        
        GUILayout.EndArea();
    }
}
```

## Troubleshooting

<details>
<summary>Common Issues</summary>

### Debug Logging Issues
- Check log level settings
- Verify console window
- Ensure proper initialization
- Check for exceptions

### Reference Validation Problems
- Verify component setup
- Check scene hierarchy
- Ensure proper serialization
- Validate prefab connections

### Visualization Issues
- Check Gizmos settings
- Verify camera setup
- Ensure proper scaling
- Check for conflicts
</details>

## API Reference

For detailed API documentation, see the [API Reference](../API/README.md#debug).

## Related Features

- [Component History](History.md)
- [Validation System](Validation.md)
- [Presets](Presets.md) 