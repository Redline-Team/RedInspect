# Installation

## Requirements
- Unity 2021.3 or later
- .NET Standard 2.1 compatible project

## Package Installation

### Via Package Manager
1. Open the Package Manager window in Unity (Window > Package Manager)
2. Click the "+" button in the top-left corner
3. Select "Add package from git URL..."
4. Enter the following URL:
   ```
   https://github.com/redline-team/redinspect.git
   ```
5. Click "Add"

### Via manifest.json
Add the following line to your project's `manifest.json` file:
```json
{
  "dependencies": {
    "dev.redline-team.redinspect": "https://github.com/redline-team/redinspect.git"
  }
}
```

## Verification
After installation, you can verify that RedInspect is properly installed by:
1. Opening any MonoBehaviour script
2. Adding the `[Required]` attribute to a field
3. Checking if the inspector shows the required field indicator

If you see the required field indicator in the Unity Inspector, RedInspect has been successfully installed. 