using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to mark a field as required. Fields marked with this attribute will be validated in the inspector.
    /// </summary>
    public class RequiredAttribute : PropertyAttribute
    {
        public string Message { get; private set; }

        public RequiredAttribute(string message = "This field is required!")
        {
            Message = message;
        }
    }
} 