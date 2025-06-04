# Visual Styling

RedInspect provides extensive customization options for the inspector's visual appearance. This guide covers all styling features and how to use them effectively.

## Table of Contents

<details>
<summary>Overview</summary>

### What is Visual Styling?
Visual Styling allows you to:
- Customize inspector appearance
- Define custom colors
- Modify layout and spacing
- Add custom icons
- Create consistent themes

### Key Benefits
- Consistent visual language
- Better user experience
- Improved readability
- Professional appearance
</details>

<details>
<summary>Colors</summary>

### Default Colors
```csharp
// Header color
private Color headerColor = new Color(0.8f, 0.2f, 0.2f);

// Section color
private Color sectionColor = new Color(0.2f, 0.2f, 0.2f);

// Warning color
private Color warningColor = new Color(0.8f, 0.6f, 0.2f);

// Error color
private Color errorColor = new Color(0.8f, 0.2f, 0.2f);

// Success color
private Color successColor = new Color(0.2f, 0.8f, 0.2f);
```

### Custom Colors
```csharp
[RedInspect]
public class CustomInspector : Editor
{
    private void InitializeStyles()
    {
        // Define custom colors
        var customHeaderColor = new Color(0.2f, 0.6f, 0.8f);
        var customSectionColor = new Color(0.3f, 0.3f, 0.3f);
        
        // Apply to styles
        headerStyle.normal.textColor = customHeaderColor;
        sectionHeaderStyle.normal.textColor = customSectionColor;
    }
}
```
</details>

<details>
<summary>Styles</summary>

### Default Styles
```csharp
// Header style
headerStyle = new GUIStyle(EditorStyles.boldLabel)
{
    normal = { textColor = headerColor },
    fontSize = 16,
    margin = new RectOffset(0, 0, 10, 10),
    alignment = TextAnchor.MiddleCenter
};

// Box style
boxStyle = new GUIStyle(EditorStyles.helpBox)
{
    padding = new RectOffset(10, 10, 10, 10),
    margin = new RectOffset(0, 0, 10, 10)
};

// Button style
buttonStyle = new GUIStyle(GUI.skin.button)
{
    normal = { textColor = Color.white },
    hover = { textColor = Color.white },
    active = { textColor = Color.white }
};
```

### Custom Styles
```csharp
[RedInspect]
public class CustomInspector : Editor
{
    private GUIStyle customButtonStyle;
    private GUIStyle customLabelStyle;

    private void InitializeStyles()
    {
        // Custom button style
        customButtonStyle = new GUIStyle(EditorStyles.miniButton)
        {
            normal = { textColor = Color.cyan },
            hover = { textColor = Color.yellow },
            active = { textColor = Color.green },
            padding = new RectOffset(10, 10, 5, 5),
            margin = new RectOffset(5, 5, 5, 5)
        };

        // Custom label style
        customLabelStyle = new GUIStyle(EditorStyles.label)
        {
            normal = { textColor = Color.white },
            fontStyle = FontStyle.Bold,
            fontSize = 12,
            padding = new RectOffset(5, 5, 5, 5)
        };
    }
}
```
</details>

<details>
<summary>Icons</summary>

### Default Icons
```csharp
// Load Unity's built-in icons
warningIcon = EditorGUIUtility.Load("icons/console.warnicon.png") as Texture2D;
errorIcon = EditorGUIUtility.Load("icons/console.erroricon.png") as Texture2D;
successIcon = EditorGUIUtility.Load("icons/console.infoicon.png") as Texture2D;
settingsIcon = EditorGUIUtility.Load("icons/settings.png") as Texture2D;
```

### Custom Icons
```csharp
[RedInspect]
public class CustomInspector : Editor
{
    private Texture2D customIcon;

    private void InitializeStyles()
    {
        // Load custom icon
        customIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Editor/Icons/custom.png");
        
        // Apply to style
        var style = new GUIStyle(EditorStyles.label);
        style.normal.background = customIcon;
    }
}
```
</details>

<details>
<summary>Layout</summary>

### Default Layout
```csharp
public override void OnInspectorGUI()
{
    // Header
    EditorGUILayout.BeginHorizontal();
    GUILayout.FlexibleSpace();
    EditorGUILayout.LabelField("Red Inspector", headerStyle);
    GUILayout.FlexibleSpace();
    EditorGUILayout.EndHorizontal();

    // Main content
    EditorGUILayout.BeginVertical(boxStyle);
    // ... content ...
    EditorGUILayout.EndVertical();
}
```

### Custom Layout
```csharp
[RedInspect]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        // Custom header with icon
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("", customIcon), GUILayout.Width(20));
        EditorGUILayout.LabelField("Custom Inspector", customHeaderStyle);
        EditorGUILayout.EndHorizontal();

        // Custom content layout
        EditorGUILayout.BeginVertical(customBoxStyle);
        EditorGUILayout.Space(10);
        
        // Sections with custom styling
        DrawCustomSection("Properties", DrawProperties);
        DrawCustomSection("Settings", DrawSettings);
        
        EditorGUILayout.EndVertical();
    }

    private void DrawCustomSection(string title, Action drawContent)
    {
        EditorGUILayout.BeginVertical(customSectionStyle);
        EditorGUILayout.LabelField(title, customSectionHeaderStyle);
        drawContent?.Invoke();
        EditorGUILayout.EndVertical();
    }
}
```
</details>

## Best Practices

1. **Color Usage**
   - Use consistent color schemes
   - Ensure good contrast
   - Consider color blindness
   - Use colors purposefully

2. **Style Management**
   - Create reusable styles
   - Maintain consistency
   - Consider performance
   - Document style usage

3. **Layout Design**
   - Keep it organized
   - Use proper spacing
   - Consider different screen sizes
   - Maintain hierarchy

## Examples

### Theme System
```csharp
[RedInspect]
public class ThemeManager : Editor
{
    private Dictionary<string, Theme> themes;

    private void InitializeThemes()
    {
        themes = new Dictionary<string, Theme>
        {
            ["Default"] = new Theme
            {
                HeaderColor = new Color(0.8f, 0.2f, 0.2f),
                SectionColor = new Color(0.2f, 0.2f, 0.2f),
                TextColor = Color.white
            },
            ["Dark"] = new Theme
            {
                HeaderColor = new Color(0.2f, 0.2f, 0.2f),
                SectionColor = new Color(0.1f, 0.1f, 0.1f),
                TextColor = new Color(0.8f, 0.8f, 0.8f)
            },
            ["Light"] = new Theme
            {
                HeaderColor = new Color(0.8f, 0.8f, 0.8f),
                SectionColor = new Color(0.9f, 0.9f, 0.9f),
                TextColor = Color.black
            }
        };
    }

    public void ApplyTheme(string themeName)
    {
        if (themes.TryGetValue(themeName, out var theme))
        {
            ApplyThemeColors(theme);
            ApplyThemeStyles(theme);
        }
    }
}
```

### Custom Inspector
```csharp
[RedInspect]
public class CustomInspector : Editor
{
    private GUIStyle customStyle;
    private Texture2D customIcon;

    private void InitializeStyles()
    {
        // Load custom icon
        customIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Editor/Icons/custom.png");

        // Create custom style
        customStyle = new GUIStyle(EditorStyles.helpBox)
        {
            normal = { textColor = Color.white },
            hover = { textColor = Color.yellow },
            active = { textColor = Color.green },
            padding = new RectOffset(10, 10, 10, 10),
            margin = new RectOffset(5, 5, 5, 5)
        };
    }

    public override void OnInspectorGUI()
    {
        // Draw custom header
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("", customIcon), GUILayout.Width(20));
        EditorGUILayout.LabelField("Custom Inspector", customStyle);
        EditorGUILayout.EndHorizontal();

        // Draw custom content
        EditorGUILayout.BeginVertical(customStyle);
        // ... custom content ...
        EditorGUILayout.EndVertical();
    }
}
```

## Troubleshooting

<details>
<summary>Common Issues</summary>

### Style Issues
- Check style initialization
- Verify color values
- Ensure proper margins
- Check for conflicts

### Icon Problems
- Verify icon paths
- Check icon formats
- Ensure proper loading
- Handle missing icons

### Layout Problems
- Check spacing
- Verify alignment
- Ensure proper nesting
- Handle different sizes
</details>

## API Reference

For detailed API documentation, see the [API Reference](../API/README.md#styling).

## Related Features

- [Icons](Icons.md)
- [Colors](Colors.md)
- [Advanced Topics](../Advanced/README.md) 