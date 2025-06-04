# Tag Attribute

The `Tag` attribute enforces that a GameObject must have a specific tag, providing validation and automatic fixes.

## Usage

```csharp
[Tag("Player")]
public GameObject playerObject;
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| Tag | string | Required tag name |

## Supported Types

- GameObject
- Component references (Transform, MonoBehaviour, etc.)

## Examples

### Basic Usage
```csharp
public class GameManager : MonoBehaviour
{
    [Tag("Player")]
    public GameObject player;
    
    [Tag("Enemy")]
    public Transform[] enemySpawnPoints;
}
```

### With Components
```csharp
public class CombatSystem : MonoBehaviour
{
    [Tag("Player")]
    public PlayerController playerController;
    
    [Tag("Enemy")]
    public EnemyController[] enemies;
}
```

### Multiple Tags
```csharp
public class TagValidator : MonoBehaviour
{
    [Tag("Player")]
    [Tag("Alive")]
    public GameObject activePlayer;
    
    [Tag("Enemy")]
    [Tag("Boss")]
    public GameObject bossEnemy;
}
```

## Automatic Fixes

The inspector provides automatic fixes for tag validation:

1. For incorrect tags:
   - "Fix Tag" button to set the correct tag
   - Supports undo/redo

2. For missing tags:
   - "Add Tag" button to add the required tag
   - "Create Tag" button if the tag doesn't exist

## Best Practices

1. **Tag Names**
   - Use consistent naming
   - Follow Unity conventions
   - Document tag usage

2. **Validation**
   - Check tag existence
   - Handle tag changes
   - Consider performance

3. **Organization**
   - Group related tags
   - Use tag categories
   - Maintain tag list

## Troubleshooting

### Common Issues

1. **Missing Tags**
   - Check tag existence
   - Verify tag spelling
   - Check tag case

2. **Validation Errors**
   - Check tag requirements
   - Verify object hierarchy
   - Test tag changes

3. **Automatic Fixes**
   - Check tag permissions
   - Verify tag creation
   - Test undo/redo

## Related

- [Required Attribute](Required.md)
- [Layer Attribute](Layer.md)
- [Scene Attribute](Scene.md)
- [Prefab Attribute](Prefab.md) 