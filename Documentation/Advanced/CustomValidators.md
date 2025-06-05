# Custom Validators

RedInspect allows you to create custom validators to extend its functionality beyond the built-in attributes.

## Creating a Custom Validator

To create a custom validator, inherit from the `PropertyValidator` class:

```csharp
public class CustomValidator : PropertyValidator
{
    public override void ValidateProperty(SerializedProperty property)
    {
        // Your validation logic here
        if (!IsValid(property))
        {
            // Show error or warning
            EditorGUILayout.HelpBox("Validation failed!", MessageType.Error);
        }
    }
    
    private bool IsValid(SerializedProperty property)
    {
        // Your validation logic here
        return true;
    }
}
```

## Example: Component Type Validator

Here's an example of a validator that ensures a GameObject has a specific component:

```csharp
public class ComponentTypeValidator : PropertyValidator
{
    private Type requiredComponentType;
    
    public ComponentTypeValidator(Type componentType)
    {
        requiredComponentType = componentType;
    }
    
    public override void ValidateProperty(SerializedProperty property)
    {
        if (property.propertyType != SerializedPropertyType.ObjectReference)
            return;
            
        GameObject go = property.objectReferenceValue as GameObject;
        if (go == null)
            return;
            
        if (!go.GetComponent(requiredComponentType))
        {
            EditorGUILayout.HelpBox(
                $"GameObject must have a {requiredComponentType.Name} component!",
                MessageType.Error
            );
        }
    }
}
```

## Using Custom Validators

Apply your custom validator using the `[Validate]` attribute:

```csharp
public class MyComponent : MonoBehaviour
{
    [Validate(typeof(ComponentTypeValidator), typeof(Rigidbody))]
    public GameObject physicsObject;
}
```

## Best Practices

1. Keep validators focused on a single responsibility
2. Provide clear error messages
3. Consider performance implications
4. Handle edge cases gracefully
5. Document your custom validators

## Common Use Cases

### Component Validation
```csharp
[Validate(typeof(ComponentTypeValidator), typeof(Animator))]
public GameObject animatedObject;
```

### Value Range Validation
```csharp
[Validate(typeof(RangeValidator), 0f, 100f)]
public float health;
```

### Reference Validation
```csharp
[Validate(typeof(ReferenceValidator), "Assets/Prefabs")]
public GameObject prefab;
```

## Next Steps
- Learn about [Extending RedInspect](Extending.md)
- Check out [Best Practices](BestPractices.md)
- Read the [API Documentation](../API/README.md) 