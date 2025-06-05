using UnityEngine;
using UnityEditor;
using System;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Base class for property validators.
    /// </summary>
    public abstract class PropertyValidator
    {
        public abstract bool Validate(SerializedProperty property);
        public abstract string GetMessage(SerializedProperty property);
    }

    /// <summary>
    /// Validates that a GameObject has a specific component.
    /// </summary>
    public class ComponentValidator : PropertyValidator
    {
        private Type requiredType;
        private string message;

        public ComponentValidator(Type requiredType, string message = null)
        {
            this.requiredType = requiredType;
            this.message = message ?? $"GameObject must have a {requiredType.Name} component!";
        }

        public override bool Validate(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.ObjectReference)
                return true;

            var obj = property.objectReferenceValue as GameObject;
            if (obj == null)
                return false;

            return obj.GetComponent(requiredType) != null;
        }

        public override string GetMessage(SerializedProperty property)
        {
            return message;
        }
    }
} 