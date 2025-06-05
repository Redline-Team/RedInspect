# Color Customization

RedInspect allows you to customize the colors used in the Unity Inspector for various attributes and validations.

## Default Colors

By default, RedInspect uses the following colors:
- Required field indicator: Red (#FF0000)
- Tag validation: Blue (#007AFF)
- Layer validation: Green (#34C759)
- Scene validation: Purple (#AF52DE)
- Prefab validation: Orange (#FF9500)

## Customizing Colors

You can customize these colors by creating a custom color set:

```csharp
[CreateAssetMenu(fileName = "RedInspectColors", menuName = "RedInspect/Colors")]
public class RedInspectColors : ScriptableObject
{
    public Color requiredColor = Color.red;
    public Color tagColor = new Color(0, 0.478f, 1f); // #007AFF
    public Color layerColor = new Color(0.204f, 0.78f, 0.349f); // #34C759
    public Color sceneColor = new Color(0.686f, 0.322f, 0.871f); // #AF52DE
    public Color prefabColor = new Color(1f, 0.584f, 0f); // #FF9500
}
```

## Color Requirements

When customizing colors, follow these guidelines:
1. Ensure good contrast against both light and dark themes
2. Consider color-blind users
3. Keep colors consistent with Unity's visual style
4. Use colors that are easily distinguishable from each other

## Applying Custom Colors

1. Create a new color set asset:
   - Right-click in the Project window
   - Select Create > RedInspect > Colors
   - Name your color set

2. Adjust the colors in the Inspector

3. Configure RedInspect to use your color set:
```csharp
public class RedInspectSettings : MonoBehaviour
{
    [SerializeField]
    private RedInspectColors customColors;
    
    private void Awake()
    {
        RedInspect.Colors = customColors;
    }
}
```

## Color Accessibility

For better accessibility, consider these color combinations:
1. Use high contrast ratios (at least 4.5:1)
2. Avoid relying solely on color to convey information
3. Test your color scheme with color blindness simulators
4. Provide alternative visual indicators (icons, patterns)

## Best Practices

1. Keep colors consistent throughout your project
2. Use colors that match your game's visual style
3. Test colors in both light and dark themes
4. Consider using Unity's built-in color constants
5. Document your color choices for team reference

## Next Steps
- Learn about [Icon Customization](Icons.md)
- Explore [Advanced Features](Advanced/CustomValidators.md)
- Check out [Best Practices](Advanced/BestPractices.md) 