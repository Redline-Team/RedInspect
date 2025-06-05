# Icon Customization

RedInspect allows you to customize the icons used in the Unity Inspector for various attributes and validations.

## Default Icons

By default, RedInspect uses the following icons:
- Required field indicator: A red exclamation mark
- Tag validation: A tag icon
- Layer validation: A layer icon
- Scene validation: A scene icon
- Prefab validation: A prefab icon

## Customizing Icons

You can customize these icons by creating a custom icon set:

```csharp
[CreateAssetMenu(fileName = "RedInspectIcons", menuName = "RedInspect/Icons")]
public class RedInspectIcons : ScriptableObject
{
    public Texture2D requiredIcon;
    public Texture2D tagIcon;
    public Texture2D layerIcon;
    public Texture2D sceneIcon;
    public Texture2D prefabIcon;
}
```

## Icon Requirements

When creating custom icons, follow these guidelines:
1. Use PNG format for best quality
2. Keep icon sizes small (32x32 or 64x64 pixels)
3. Use transparent backgrounds
4. Ensure good visibility against both light and dark themes

## Applying Custom Icons

1. Create a new icon set asset:
   - Right-click in the Project window
   - Select Create > RedInspect > Icons
   - Name your icon set

2. Assign your custom icons to the asset

3. Configure RedInspect to use your icon set:
```csharp
public class RedInspectSettings : MonoBehaviour
{
    [SerializeField]
    private RedInspectIcons customIcons;
    
    private void Awake()
    {
        RedInspect.Icons = customIcons;
    }
}
```

## Best Practices

1. Keep icons consistent with Unity's visual style
2. Use clear, recognizable symbols
3. Test icons in both light and dark themes
4. Consider color-blind users when choosing colors
5. Keep file sizes small for better performance

## Next Steps
- Learn about [Color Customization](Colors.md)
- Explore [Advanced Features](Advanced/CustomValidators.md)
- Check out [Best Practices](Advanced/BestPractices.md) 