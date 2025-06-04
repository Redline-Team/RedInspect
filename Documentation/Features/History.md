# Component History

RedInspect provides a powerful component state history system that allows you to track, save, and restore component states during development.

## Table of Contents

<details>
<summary>Overview</summary>

### What is Component History?
Component History is a feature that allows you to:
- Save the current state of a component
- Restore previous states
- Track changes over time
- Undo/redo component modifications

### Key Benefits
- Quick state restoration
- Development workflow improvement
- Easy comparison between states
- Safe experimentation
</details>

<details>
<summary>Saving States</summary>

### Manual Saving
```csharp
// In the inspector, click "Save Current State" in the History section
// Or use the API:
stateHistory.SaveState(component);
```

### Automatic Saving
```csharp
[RedInspect]
public class MyComponent : MonoBehaviour
{
    private void OnValidate()
    {
        // Automatically save state when values change
        if (Application.isEditor)
        {
            stateHistory.SaveState(this);
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
<summary>Restoring States</summary>

### Manual Restoration
```csharp
// In the inspector, click "Restore Last State" in the History section
// Or use the API:
stateHistory.RestoreLatestState(component);
```

### Selective Restoration
```csharp
// Restore a specific state
stateHistory.RestoreState(component, stateIndex);

// Restore specific properties
stateHistory.RestoreProperties(component, new[] { "health", "speed" });
```

### Undo Support
- All state changes support Unity's undo system
- Changes can be undone/redone
- Maintains editor history
</details>

<details>
<summary>Managing History</summary>

### History Limits
```csharp
// Set maximum history size
stateHistory.MaxHistorySize = 10;

// Clear history
stateHistory.ClearHistory();
```

### History Navigation
```csharp
// Get available states
var states = stateHistory.GetAvailableStates();

// Get current state index
var currentIndex = stateHistory.CurrentStateIndex;

// Check if history exists
if (stateHistory.HasHistory)
{
    // Do something
}
```

### History Persistence
- History is maintained during editor sessions
- States are saved with the scene
- History is cleared when entering play mode
</details>

## Best Practices

1. **State Management**
   - Save states before major changes
   - Use descriptive names for states
   - Regularly clear old history
   - Monitor history size

2. **Performance**
   - Limit history size for complex components
   - Clear history when no longer needed
   - Use selective restoration for large components
   - Consider memory usage

3. **Workflow Integration**
   - Save states before testing
   - Use history for A/B testing
   - Document important states
   - Share states with team members

## Examples

### Basic Usage
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
            // Save state when values change
            stateHistory.SaveState(this);
        }
    }
}
```

### Advanced Usage
```csharp
[RedInspect]
public class GameManager : MonoBehaviour
{
    private ComponentStateHistory stateHistory;

    private void Awake()
    {
        stateHistory = new ComponentStateHistory();
    }

    public void SaveCurrentState()
    {
        stateHistory.SaveState(this);
        Debug.Log($"State saved at {DateTime.Now}");
    }

    public void RestoreLastState()
    {
        if (stateHistory.HasHistory)
        {
            stateHistory.RestoreLatestState(this);
            Debug.Log("State restored");
        }
    }

    public void ClearHistory()
    {
        stateHistory.ClearHistory();
        Debug.Log("History cleared");
    }
}
```

## Troubleshooting

<details>
<summary>Common Issues</summary>

### State Not Saving
- Check if component is serializable
- Verify editor mode
- Ensure proper initialization
- Check for compilation errors

### Restoration Issues
- Verify state exists
- Check component compatibility
- Ensure proper permissions
- Verify undo system

### Performance Problems
- Reduce history size
- Clear unused states
- Use selective restoration
- Monitor memory usage
</details>

## API Reference

For detailed API documentation, see the [API Reference](../API/README.md#history).

## Related Features

- [Debug Tools](Debug.md)
- [Presets](Presets.md)
- [Validation System](Validation.md) 