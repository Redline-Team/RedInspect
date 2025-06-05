using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to mark a method as a custom validator.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class ValidateAttribute : PropertyAttribute
    {
        public string Message { get; private set; }

        public ValidateAttribute(string message = "Validation failed!")
        {
            Message = message;
        }
    }
} 