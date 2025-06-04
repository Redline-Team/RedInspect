# Validation System

RedInspect provides a comprehensive validation system to ensure your components are properly configured. This guide covers all validation features and how to use them effectively.

## Table of Contents

<details>
<summary>Required Components</summary>

### Overview
The `RequireComponent` attribute ensures that specific components are present on the GameObject. RedInspect enhances this with visual feedback and automatic fixes.

### Usage
```csharp
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    // Your code here
}
```

### Features
- Visual indicator for missing components
- One-click component addition
- Support for multiple required components
- Automatic dependency management
</details>

<details>
<summary>Field Validation</summary>

### Overview
The `Required` attribute ensures that fields are not null and meet specific criteria.

### Usage
```csharp
public class GameManager : MonoBehaviour
{
    [Required("Player prefab is required")]
    public GameObject playerPrefab;
    
    [Required("UI Manager is required")]
    public UIManager uiManager;
}
```

### Features
- Custom error messages
- Visual feedback in inspector
- Support for all Unity object types
- Automatic validation on play
</details>

<details>
<summary>Tag Validation</summary>

### Overview
The `Tag` attribute ensures that GameObjects have the correct tag.

### Usage
```csharp
public class EnemySpawner : MonoBehaviour
{
    [Tag("Player")]
    public GameObject player;
    
    [Tag("Enemy")]
    public GameObject enemyPrefab;
}
```

### Features
- One-click tag fixing
- Support for multiple tags
- Custom validation messages
- Visual feedback in inspector
</details>

<details>
<summary>Layer Validation</summary>

### Overview
The `Layer` attribute ensures that GameObjects are on the correct layer.

### Usage
```csharp
public class UIManager : MonoBehaviour
{
    [Layer("UI")]
    public GameObject mainMenu;
    
    [Layer("UI")]
    public GameObject hud;
}
```

### Features
- One-click layer fixing
- Support for multiple layers
- Custom validation messages
- Visual feedback in inspector
</details>

<details>
<summary>Scene Validation</summary>

### Overview
The `Scene` attribute ensures that GameObjects are in the correct scene.

### Usage
```csharp
public class LevelManager : MonoBehaviour
{
    [Scene("MainMenu")]
    public GameObject menuUI;
    
    [Scene("Gameplay")]
    public GameObject gameplayUI;
}
```

### Features
- Scene name validation
- Visual feedback in inspector
- Support for multiple scenes
- Custom validation messages
</details>

<details>
<summary>Prefab Validation</summary>

### Overview
The `Prefab` attribute ensures that GameObjects are either prefab instances or not.

### Usage
```csharp
public class PrefabManager : MonoBehaviour
{
    [Prefab(true)]
    public GameObject playerPrefab;
    
    [Prefab(false)]
    public GameObject runtimeObject;
}
```

### Features
- Prefab instance validation
- One-click prefab conversion
- Custom validation messages
- Visual feedback in inspector
</details>

## Best Practices

1. **Use Specific Validation**
   - Choose the most specific validation attribute for your needs
   - Combine attributes when necessary
   - Provide clear error messages

2. **Performance Considerations**
   - Validation runs in the editor only
   - No runtime performance impact
   - Use validation sparingly for complex scenes

3. **Error Handling**
   - Always provide meaningful error messages
   - Use validation to prevent common mistakes
   - Consider using multiple validation types

## Examples

### Complex Validation
```csharp
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Required("Player camera is required")]
    [Tag("MainCamera")]
    [Layer("Player")]
    public Camera playerCamera;
    
    [Required("Player UI is required")]
    [Layer("UI")]
    [Scene("Gameplay")]
    public GameObject playerUI;
}
```

### Automatic Fixes
```csharp
public class EnemyManager : MonoBehaviour
{
    [Tag("Enemy")]
    [Layer("Enemy")]
    public GameObject enemyPrefab;
    
    private void OnValidate()
    {
        // Automatic fixes will be applied in the inspector
        if (enemyPrefab != null)
        {
            enemyPrefab.tag = "Enemy";
            enemyPrefab.layer = LayerMask.NameToLayer("Enemy");
        }
    }
}
```

## Troubleshooting

<details>
<summary>Common Issues</summary>

### Validation Not Working
- Ensure the attribute is properly applied
- Check for compilation errors
- Verify the component is attached to a GameObject

### Automatic Fixes Not Working
- Check if the object is locked
- Verify you have the necessary permissions
- Ensure the object is not a prefab instance

### Performance Issues
- Reduce the number of validations
- Use more specific validation types
- Consider using validation only in development
</details>

## API Reference

For detailed API documentation, see the [API Reference](../API/README.md#validation). 