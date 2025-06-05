# Development Setup

This guide covers how to set up the RedInspect development environment.

## Prerequisites

- Unity 2021.3 or later
- Visual Studio 2019 or later
- Git
- .NET Standard 2.1 SDK

## Repository Setup

1. Clone the repository:
```bash
git clone https://github.com/redline-team/redinspect.git
cd redinspect
```

2. Open the project in Unity:
   - Launch Unity Hub
   - Click "Add"
   - Select the cloned repository folder
   - Choose Unity 2021.3 or later
   - Click "Open"

## Project Structure

```
redinspect/
├── Assets/
│   └── RedInspect/
│       ├── Core/
│       │   ├── Attributes/
│       │   ├── Drawers/
│       │   └── Validators/
│       ├── Editor/
│       │   ├── Windows/
│       │   └── Extensions/
│       └── Tests/
│           ├── Editor/
│           └── Runtime/
├── Documentation/
│   ├── API/
│   ├── Features/
│   └── Guides/
└── Packages/
    └── manifest.json
```

## Development Workflow

1. Create a new branch for your feature:
```bash
git checkout -b feature/your-feature-name
```

2. Make your changes

3. Run tests:
   - Open the Test Runner window (Window > General > Test Runner)
   - Run all tests

4. Create a pull request:
   - Push your branch
   - Create a pull request on GitHub
   - Wait for review

## Testing

### Running Tests

1. Open the Test Runner window:
   - Window > General > Test Runner

2. Run tests:
   - Click "Run All" to run all tests
   - Click "Run Selected" to run specific tests

### Writing Tests

```csharp
[TestFixture]
public class RequiredAttributeTests
{
    [Test]
    public void RequiredAttribute_ValidField_NoError()
    {
        // Arrange
        var go = new GameObject();
        var component = go.AddComponent<TestComponent>();
        component.requiredField = new GameObject();
        
        // Act
        var validation = new RequiredAttributeValidator();
        var result = validation.Validate(component.requiredField);
        
        // Assert
        Assert.IsTrue(result.IsValid);
    }
}
```

## Building

1. Update version in `package.json`:
```json
{
  "name": "dev.redline-team.redinspect",
  "version": "1.0.0",
  "displayName": "RedInspect",
  "description": "Unity Inspector validation and enhancement tool",
  "unity": "2021.3"
}
```

2. Build the package:
   - Open the Package Manager window
   - Select the package
   - Click "Export"

## Documentation

1. Update documentation in the `Documentation` folder
2. Follow the existing documentation structure
3. Include code examples
4. Add screenshots when relevant
5. Keep documentation up to date

## Code Style

1. Follow Unity's coding conventions
2. Use XML documentation comments
3. Keep methods focused and small
4. Use meaningful variable names
5. Add comments for complex logic

## Next Steps
- Read the [API Documentation](../API/README.md)
- Check out [Best Practices](../Advanced/BestPractices.md)
- Learn about [Custom Validators](../Advanced/CustomValidators.md) 