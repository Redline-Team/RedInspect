# Frequently Asked Questions

## General Questions

### What is RedInspect?
RedInspect is a Unity package that enhances the Unity Inspector with validation and customization features. It helps catch common errors early and improves the development workflow.

### Is RedInspect free to use?
Yes, RedInspect is free and open-source under the MIT license.

### Which Unity versions are supported?
RedInspect supports Unity 2021.3 and later versions.

## Installation

### How do I install RedInspect?
You can install RedInspect through the Unity Package Manager:
1. Open the Package Manager window
2. Click the "+" button
3. Select "Add package from git URL..."
4. Enter: `https://github.com/redline-team/redinspect.git`

### Can I install RedInspect via Git?
Yes, you can add it to your project's `manifest.json`:
```json
{
  "dependencies": {
    "dev.redline-team.redinspect": "https://github.com/redline-team/redinspect.git"
  }
}
```

## Usage

### How do I mark a field as required?
Use the `[Required]` attribute:
```csharp
[Required]
public Transform target;
```

### Can I combine multiple attributes?
Yes, you can combine attributes:
```csharp
[Required]
[Tag("Player")]
public GameObject player;
```

### Does RedInspect work with custom components?
Yes, RedInspect works with any MonoBehaviour or ScriptableObject.

## Performance

### Does RedInspect impact runtime performance?
No, RedInspect only runs in the Unity Editor and has no impact on runtime performance.

### Will RedInspect slow down my Inspector?
RedInspect is optimized for performance, but if you notice slowdowns:
1. Reduce the number of validations
2. Use appropriate validation scopes
3. Cache validation results when possible

## Customization

### Can I customize the validation icons?
Yes, you can customize icons through the `RedInspectIcons` asset. See [Icon Customization](Customization/Icons.md) for details.

### Can I change the validation colors?
Yes, you can customize colors through the `RedInspectColors` asset. See [Color Customization](Customization/Colors.md) for details.

## Development

### Can I create custom validators?
Yes, you can create custom validators by inheriting from `PropertyValidator`. See [Custom Validators](Advanced/CustomValidators.md) for details.

### How do I contribute to RedInspect?
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## Troubleshooting

### Why aren't my required fields showing?
Check that:
1. The field is marked with `[Required]`
2. The field is public or has `[SerializeField]`
3. The field type is supported

### Why isn't tag validation working?
Verify that:
1. The tag exists in your project
2. The tag is spelled correctly
3. The GameObject has the correct tag

## Best Practices

### What are the best practices for using RedInspect?
1. Keep validations focused and specific
2. Use appropriate validation scopes
3. Cache validation results when possible
4. Profile performance regularly
5. Test in different Unity versions

### How should I organize my validations?
Group related validations together:
```csharp
[Header("Player References")]
[Required]
public Transform player;

[Header("Enemy References")]
[Tag("Enemy")]
public GameObject[] enemies;
```

## Support

### Where can I get help?
1. Check the [Documentation](README.md)
2. Look for similar issues on GitHub
3. Create a new issue on GitHub
4. Contact the development team

### How do I report a bug?
1. Check if the bug is already reported
2. Create a new issue on GitHub
3. Include steps to reproduce
4. Add screenshots if relevant
5. Specify your Unity version

## Next Steps
- Read the [Installation Guide](GettingStarted/Installation.md)
- Check out [Quick Start](GettingStarted/QuickStart.md)
- Learn about [Basic Usage](GettingStarted/BasicUsage.md)
- Explore [Advanced Features](Advanced/CustomValidators.md) 