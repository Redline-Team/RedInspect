# Required Attribute

The `Required` attribute enforces that a field must have a value, providing validation and automatic fixes.

## Usage

```csharp
[Required("This field is required")]
public GameObject targetObject;
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| Message | string | Custom error message to display when validation fails |

## Supported Types

- Object references (GameObject, Component, etc.)
- Strings
- Arrays/Lists
- Custom serializable types

## Examples

### Basic Usage
```csharp
public class MyComponent : MonoBehaviour
{
    [Required("Player object is required")]
    public GameObject playerObject;
    
    [Required("Name cannot be empty")]
    public string playerName;
}
```

### With Collections
```csharp
public class Inventory : MonoBehaviour
{
    [Required("At least one item is required")]
    public List<Item> items;
    
    [Required("Equipment slots cannot be empty")]
    public EquipmentSlot[] equipmentSlots;
}
```

### With Custom Types
```csharp
[System.Serializable]
public class PlayerStats
{
    public string name;
    public int level;
    public float health;
}

public class Player : MonoBehaviour
{
    [Required("Player stats are required")]
    public PlayerStats stats;
}
```

## Automatic Fixes

The inspector provides automatic fixes for required fields:

1. For missing components:
   - "Add Component" button to add the required component
   - Supports undo/redo

2. For empty references:
   - "Find in Scene" button to locate valid objects
   - "Create New" button to create a new instance

## Best Practices

1. **Error Messages**
   - Be specific about what is required
   - Explain why it's required
   - Provide guidance on how to fix

2. **Type Safety**
   - Use with appropriate types
   - Consider null checks
   - Handle edge cases

3. **Performance**
   - Avoid deep validation
   - Cache validation results
   - Use appropriate collections

## Troubleshooting

### Common Issues

1. **Missing References**
   - Check if the object exists in the scene
   - Verify the object is not destroyed
   - Ensure proper initialization

2. **Validation Errors**
   - Check error messages
   - Verify field types
   - Test edge cases

3. **Automatic Fixes**
   - Check component dependencies
   - Verify scene hierarchy
   - Test undo/redo

## Related

- [Tag Attribute](Tag.md)
- [Layer Attribute](Layer.md)
- [Scene Attribute](Scene.md)
- [Prefab Attribute](Prefab.md) 