# Troubleshooting

This guide covers common issues and their solutions when using RedInspect.

## Common Issues

### Required Fields Not Showing

**Issue**: Required field indicators are not appearing in the Inspector.

**Solutions**:
1. Check if the field is marked with `[Required]`
2. Verify that the field is public or has `[SerializeField]`
3. Ensure the field type is supported
4. Check if the component is properly initialized

### Tag Validation Not Working

**Issue**: Tag validation is not restricting GameObject references.

**Solutions**:
1. Verify the tag exists in the project
2. Check if the tag is spelled correctly
3. Ensure the GameObject has the correct tag
4. Check if the field type is GameObject or Component

### Layer Validation Not Working

**Issue**: Layer validation is not restricting GameObject references.

**Solutions**:
1. Verify the layer exists in the project
2. Check if the layer is spelled correctly
3. Ensure the GameObject is on the correct layer
4. Check if the field type is GameObject or Component

### Scene Validation Not Working

**Issue**: Scene validation is not restricting GameObject references.

**Solutions**:
1. Verify the scene exists in the project
2. Check if the scene name is spelled correctly
3. Ensure the GameObject is in the correct scene
4. Check if the field type is GameObject or Component

### Prefab Validation Not Working

**Issue**: Prefab validation is not restricting GameObject references.

**Solutions**:
1. Verify the GameObject is a prefab
2. Check if the prefab is properly saved
3. Ensure the field type is GameObject or Component
4. Check if the prefab is in the project

## Editor Issues

### Inspector Not Updating

**Issue**: The Inspector is not updating when values change.

**Solutions**:
1. Force the Inspector to refresh:
   - Select a different object
   - Select the object again
2. Check if the component is properly serialized
3. Verify that the field is marked as serializable
4. Try restarting Unity

### Validation Errors Not Showing

**Issue**: Validation errors are not appearing in the Inspector.

**Solutions**:
1. Check if the validation is properly implemented
2. Verify that the error message is set
3. Ensure the validation is being called
4. Check if the component is properly initialized

### Custom Validators Not Working

**Issue**: Custom validators are not being applied.

**Solutions**:
1. Check if the validator is properly implemented
2. Verify that the validator is registered
3. Ensure the validator is being called
4. Check if the component is properly initialized

## Performance Issues

### Slow Inspector

**Issue**: The Inspector is slow to update.

**Solutions**:
1. Reduce the number of validations
2. Cache validation results
3. Use appropriate validation scopes
4. Profile the validation performance
5. Consider using editor-only validation

### High Memory Usage

**Issue**: RedInspect is using too much memory.

**Solutions**:
1. Reduce the number of validations
2. Cache validation results
3. Use appropriate validation scopes
4. Profile the memory usage
5. Consider using editor-only validation

## Best Practices

1. Keep validations focused and specific
2. Use appropriate validation scopes
3. Cache validation results when possible
4. Profile performance regularly
5. Test in different Unity versions

## Getting Help

If you're still having issues:

1. Check the [API Documentation](API/README.md)
2. Look for similar issues on GitHub
3. Create a new issue on GitHub
4. Contact the development team
5. Check the Unity forums

## Next Steps
- Read the [API Documentation](API/README.md)
- Check out [Best Practices](Advanced/BestPractices.md)
- Learn about [Custom Validators](Advanced/CustomValidators.md) 