# Prefab Attribute

The `Prefab` attribute enforces that a GameObject must be a prefab instance, providing validation and automatic fixes.

## Usage

```csharp
[Prefab]
public GameObject prefabInstance;
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| Required | bool | Whether the object must be a prefab (default: true) |

## Supported Types

- GameObject
- Component references (Transform, MonoBehaviour, etc.)

## Examples

### Basic Usage
```csharp
public class PrefabManager : MonoBehaviour
{
    [Prefab]
    public GameObject[] prefabInstances;
    
    [Prefab(Required = false)]
    public GameObject optionalPrefab;
}
```

### With Components
```csharp
public class SpawnManager : MonoBehaviour
{
    [Prefab]
    public EnemyController[] enemyPrefabs;
    
    [Prefab]
    public ItemController[] itemPrefabs;
}
```

### Mixed Usage
```csharp
public class PrefabValidator : MonoBehaviour
{
    [Prefab]
    public GameObject requiredPrefab;
    
    [Prefab(Required = false)]
    public GameObject optionalPrefab;
    
    public GameObject nonPrefabObject;
}
```

## Automatic Fixes

The inspector provides automatic fixes for prefab validation:

1. For non-prefab objects:
   - "Create Prefab" button to create a prefab
   - "Convert to Prefab" button to convert the object
   - Supports undo/redo

2. For missing prefabs:
   - "Create New" button to create a new prefab
   - "Find in Project" button to locate existing prefabs

## Best Practices

1. **Prefab Organization**
   - Use consistent naming
   - Follow Unity conventions
   - Document prefab usage

2. **Validation**
   - Check prefab existence
   - Handle prefab changes
   - Consider performance

3. **Organization**
   - Group related prefabs
   - Use prefab categories
   - Maintain prefab list

## Troubleshooting

### Common Issues

1. **Missing Prefabs**
   - Check prefab existence
   - Verify prefab path
   - Check prefab references

2. **Validation Errors**
   - Check prefab requirements
   - Verify object hierarchy
   - Test prefab changes

3. **Automatic Fixes**
   - Check prefab permissions
   - Verify prefab creation
   - Test undo/redo

## Related

- [Required Attribute](Required.md)
- [Tag Attribute](Tag.md)
- [Layer Attribute](Layer.md)
- [Scene Attribute](Scene.md) 