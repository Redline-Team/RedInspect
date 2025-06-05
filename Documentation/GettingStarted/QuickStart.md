# Quick Start Guide

This guide will help you get started with RedInspect quickly. We'll cover the most common use cases and features.

## Basic Usage

1. Add the `[Required]` attribute to fields that must be assigned:
```csharp
public class MyComponent : MonoBehaviour
{
    [Required]
    public Transform target;
}
```

2. Use the `[Tag]` attribute to restrict GameObject references to specific tags:
```csharp
[Tag("Player")]
public GameObject playerObject;
```

3. Use the `[Layer]` attribute to restrict GameObject references to specific layers:
```csharp
[Layer("Enemy")]
public GameObject enemyObject;
```

## Common Scenarios

### Required References
```csharp
public class PlayerController : MonoBehaviour
{
    [Required]
    public Transform cameraTarget;
    
    [Required]
    public Rigidbody body;
}
```

### Tag-based References
```csharp
public class GameManager : MonoBehaviour
{
    [Tag("Player")]
    public GameObject player;
    
    [Tag("Enemy")]
    public GameObject[] enemies;
}
```

### Layer-based References
```csharp
public class CollisionHandler : MonoBehaviour
{
    [Layer("Ground")]
    public GameObject ground;
    
    [Layer("Obstacle")]
    public GameObject[] obstacles;
}
```

## Next Steps
- Check out [Basic Usage](BasicUsage.md) for more detailed examples
- Learn about [Customization](Customization/Icons.md) options
- Explore [Advanced Features](Advanced/CustomValidators.md) 