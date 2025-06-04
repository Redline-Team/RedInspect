using UnityEngine;
using System;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Enhanced version of Unity's RequireComponent attribute with additional validation and dependency checking.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RequireComponentAttribute : PropertyAttribute
    {
        public Type[] RequiredTypes { get; private set; }
        public bool AllowMissing { get; private set; }
        public string Message { get; private set; }

        public RequireComponentAttribute(Type requiredType, bool allowMissing = false, string message = null)
        {
            RequiredTypes = new[] { requiredType };
            AllowMissing = allowMissing;
            Message = message;
        }

        public RequireComponentAttribute(Type[] requiredTypes, bool allowMissing = false, string message = null)
        {
            RequiredTypes = requiredTypes;
            AllowMissing = allowMissing;
            Message = message;
        }
    }
} 