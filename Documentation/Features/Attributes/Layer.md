# Layer Attribute

The `Layer` attribute enforces that a GameObject must be on a specific layer, providing validation and automatic fixes.

## Usage

```csharp
[Layer("UI")]
public GameObject uiElement;
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| Layer | string | Required layer name |

## Supported Types

- GameObject
- Component references (Transform, MonoBehaviour, etc.)

## Examples

### Basic Usage
```csharp
public class UIManager : MonoBehaviour
{
    [Layer("UI")]
    public Canvas mainCanvas;
    
    [Layer("UI")]
    public GameObject[] uiElements;
}
```

### With Components
```csharp
public class PhysicsManager : MonoBehaviour
{
    [Layer("Player")]
    public PlayerController player;
    
    [Layer("Enemy")]
    public EnemyController[] enemies;
}
```

### Multiple Layers
```csharp
public class LayerValidator : MonoBehaviour
{
    [Layer("Player")]
    [Layer("Interactable")]
    public GameObject playerInteractable;
    
    [Layer("Enemy")]
    [Layer("Destructible")]
    public GameObject destructibleEnemy;
}
```

## Automatic Fixes

The inspector provides automatic fixes for layer validation:

1. For incorrect layers:
   - "Fix Layer" button to set the correct layer
   - Supports undo/redo

2. For missing layers:
   - "Add Layer" button to add the required layer
   - "Create Layer" button if the layer doesn't exist

## Best Practices

1. **Layer Names**
   - Use consistent naming
   - Follow Unity conventions
   - Document layer usage

2. **Validation**
   - Check layer existence
   - Handle layer changes
   - Consider performance

3. **Organization**
   - Group related layers
   - Use layer categories
   - Maintain layer list

## Troubleshooting

### Common Issues

1. **Missing Layers**
   - Check layer existence
   - Verify layer spelling
   - Check layer case

2. **Validation Errors**
   - Check layer requirements
   - Verify object hierarchy
   - Test layer changes

3. **Automatic Fixes**
   - Check layer permissions
   - Verify layer creation
   - Test undo/redo

## Related

- [Required Attribute](Required.md)
- [Tag Attribute](Tag.md)
- [Scene Attribute](Scene.md)
- [Prefab Attribute](Prefab.md) 