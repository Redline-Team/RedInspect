# Scene Attribute

The `Scene` attribute enforces that a GameObject must be in a specific scene, providing validation and automatic fixes.

## Usage

```csharp
[Scene("MainMenu")]
public GameObject menuObject;
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| Scene | string | Required scene name |

## Supported Types

- GameObject
- Component references (Transform, MonoBehaviour, etc.)

## Examples

### Basic Usage
```csharp
public class SceneManager : MonoBehaviour
{
    [Scene("MainMenu")]
    public GameObject menuUI;
    
    [Scene("Gameplay")]
    public GameObject player;
}
```

### With Components
```csharp
public class GameManager : MonoBehaviour
{
    [Scene("MainMenu")]
    public MenuController menuController;
    
    [Scene("Gameplay")]
    public PlayerController playerController;
}
```

### Multiple Scenes
```csharp
public class SceneValidator : MonoBehaviour
{
    [Scene("MainMenu")]
    [Scene("Settings")]
    public GameObject menuSettings;
    
    [Scene("Gameplay")]
    [Scene("Tutorial")]
    public GameObject tutorialPlayer;
}
```

## Automatic Fixes

The inspector provides automatic fixes for scene validation:

1. For incorrect scenes:
   - "Open Scene" button to open the required scene
   - "Move to Scene" button to move the object
   - Supports undo/redo

2. For missing scenes:
   - "Create Scene" button to create the required scene
   - "Add to Build" button to add the scene to build settings

## Best Practices

1. **Scene Names**
   - Use consistent naming
   - Follow Unity conventions
   - Document scene usage

2. **Validation**
   - Check scene existence
   - Handle scene changes
   - Consider performance

3. **Organization**
   - Group related scenes
   - Use scene categories
   - Maintain scene list

## Troubleshooting

### Common Issues

1. **Missing Scenes**
   - Check scene existence
   - Verify scene spelling
   - Check scene case

2. **Validation Errors**
   - Check scene requirements
   - Verify object hierarchy
   - Test scene changes

3. **Automatic Fixes**
   - Check scene permissions
   - Verify scene creation
   - Test undo/redo

## Related

- [Required Attribute](Required.md)
- [Tag Attribute](Tag.md)
- [Layer Attribute](Layer.md)
- [Prefab Attribute](Prefab.md) 