using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to enforce minimum and maximum values for numeric fields.
    /// </summary>
    public class MinMaxAttribute : PropertyAttribute
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public string Message { get; private set; }

        public MinMaxAttribute(float min, float max, string message = null)
        {
            Min = min;
            Max = max;
            Message = message ?? $"Value must be between {min} and {max}";
        }
    }
} 