# Basic Usage

This guide covers the basic usage of RedInspect attributes and features in detail.

## Required Fields

The `[Required]` attribute ensures that fields are assigned in the Unity Inspector:

```csharp
public class PlayerController : MonoBehaviour
{
    [Required]
    public Transform cameraTarget;
    
    [Required]
    public Rigidbody body;
    
    [Required]
    public Animator animator;
}
```

## Tag Restrictions

The `[Tag]` attribute restricts GameObject references to specific tags:

```csharp
public class GameManager : MonoBehaviour
{
    [Tag("Player")]
    public GameObject player;
    
    [Tag("Enemy")]
    public GameObject[] enemies;
    
    [Tag("Pickup")]
    public GameObject[] pickups;
}
```

## Layer Restrictions

The `[Layer]` attribute restricts GameObject references to specific layers:

```csharp
public class CollisionHandler : MonoBehaviour
{
    [Layer("Ground")]
    public GameObject ground;
    
    [Layer("Obstacle")]
    public GameObject[] obstacles;
    
    [Layer("Trigger")]
    public GameObject[] triggers;
}
```

## Scene References

The `[Scene]` attribute ensures that referenced GameObjects are in specific scenes:

```csharp
public class LevelManager : MonoBehaviour
{
    [Scene("MainMenu")]
    public GameObject mainMenu;
    
    [Scene("Gameplay")]
    public GameObject gameplay;
}
```

## Prefab References

The `[Prefab]` attribute ensures that referenced GameObjects are prefabs:

```csharp
public class Spawner : MonoBehaviour
{
    [Prefab]
    public GameObject enemyPrefab;
    
    [Prefab]
    public GameObject[] itemPrefabs;
}
```

## Combining Attributes

You can combine multiple attributes to create more specific restrictions:

```csharp
public class GameController : MonoBehaviour
{
    [Required]
    [Tag("Player")]
    public GameObject player;
    
    [Required]
    [Layer("Enemy")]
    public GameObject[] enemies;
    
    [Required]
    [Prefab]
    public GameObject[] spawnablePrefabs;
}
```

## Best Practices

1. Use `[Required]` for essential references that must be assigned
2. Use `[Tag]` and `[Layer]` to prevent incorrect assignments
3. Use `[Scene]` to ensure proper scene organization
4. Use `[Prefab]` to prevent runtime GameObject references
5. Combine attributes when you need multiple restrictions

## Next Steps
- Learn about [Customization](Customization/Icons.md) options
- Explore [Advanced Features](Advanced/CustomValidators.md)
- Check out [Best Practices](Advanced/BestPractices.md) 