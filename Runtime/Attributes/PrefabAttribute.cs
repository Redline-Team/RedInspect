using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to validate that a GameObject is or is not a prefab instance.
    /// </summary>
    public class PrefabAttribute : PropertyAttribute
    {
        public bool MustBePrefabInstance { get; private set; }
        public string Message { get; private set; }

        public PrefabAttribute(bool mustBePrefabInstance, string message = null)
        {
            MustBePrefabInstance = mustBePrefabInstance;
            Message = message ?? (mustBePrefabInstance 
                ? "GameObject must be a prefab instance!" 
                : "GameObject must not be a prefab instance!");
        }
    }
} 