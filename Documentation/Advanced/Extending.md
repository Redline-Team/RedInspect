# Extending RedInspect

RedInspect is designed to be extensible, allowing you to add custom functionality and integrate it with your own systems.

## Custom Attributes

You can create custom attributes that work with RedInspect's validation system:

```csharp
[AttributeUsage(AttributeTargets.Field)]
public class CustomValidationAttribute : PropertyAttribute
{
    public string message;
    
    public CustomValidationAttribute(string message = null)
    {
        this.message = message;
    }
}
```

## Custom Property Drawers

Create custom property drawers to enhance the Unity Inspector:

```csharp
[CustomPropertyDrawer(typeof(CustomValidationAttribute))]
public class CustomValidationDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Draw the default property
        EditorGUI.PropertyField(position, property, label);
        
        // Get the attribute
        var attr = attribute as CustomValidationAttribute;
        
        // Perform validation
        if (!IsValid(property))
        {
            // Show error message
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.HelpBox(position, attr.message ?? "Validation failed!", MessageType.Error);
        }
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var attr = attribute as CustomValidationAttribute;
        float height = EditorGUIUtility.singleLineHeight;
        
        if (!IsValid(property))
        {
            height += EditorGUIUtility.singleLineHeight * 2;
        }
        
        return height;
    }
    
    private bool IsValid(SerializedProperty property)
    {
        // Your validation logic here
        return true;
    }
}
```

## Integration with Other Systems

### Custom Validation System

```csharp
public class CustomValidationSystem
{
    public static void ValidateAll()
    {
        // Find all components with custom validation
        var components = Object.FindObjectsOfType<MonoBehaviour>();
        foreach (var component in components)
        {
            ValidateComponent(component);
        }
    }
    
    private static void ValidateComponent(MonoBehaviour component)
    {
        // Get all fields with custom validation
        var fields = component.GetType().GetFields(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
        );
        
        foreach (var field in fields)
        {
            var attributes = field.GetCustomAttributes(typeof(CustomValidationAttribute), true);
            foreach (var attribute in attributes)
            {
                // Perform validation
                ValidateField(component, field, attribute as CustomValidationAttribute);
            }
        }
    }
}
```

### Editor Extensions

```csharp
public class RedInspectEditorExtension : EditorWindow
{
    [MenuItem("Window/RedInspect/Validation")]
    public static void ShowWindow()
    {
        GetWindow<RedInspectEditorExtension>("RedInspect Validation");
    }
    
    private void OnGUI()
    {
        if (GUILayout.Button("Validate All"))
        {
            CustomValidationSystem.ValidateAll();
        }
    }
}
```

## Best Practices

1. Follow Unity's naming conventions
2. Use proper attribute usage flags
3. Handle serialization properly
4. Consider editor-only code
5. Document your extensions

## Common Extension Points

### Custom Validation Rules
```csharp
[CustomValidation]
public class CustomValidationRule : IValidationRule
{
    public bool Validate(object value)
    {
        // Your validation logic here
        return true;
    }
}
```

### Custom Property Modifiers
```csharp
[CustomPropertyModifier]
public class CustomPropertyModifier : IPropertyModifier
{
    public void ModifyProperty(SerializedProperty property)
    {
        // Your modification logic here
    }
}
```

## Next Steps
- Learn about [Custom Validators](CustomValidators.md)
- Check out [Best Practices](BestPractices.md)
- Read the [API Documentation](../API/README.md) 