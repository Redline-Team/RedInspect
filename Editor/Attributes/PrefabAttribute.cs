using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to validate that a GameObject reference is a prefab instance.
    /// </summary>
    public class PrefabAttribute : PropertyAttribute
    {
        public bool MustBePrefabInstance { get; private set; }
        public string Message { get; private set; }

        public PrefabAttribute(bool mustBePrefabInstance = true, string message = null)
        {
            MustBePrefabInstance = mustBePrefabInstance;
            Message = message ?? (mustBePrefabInstance ? 
                "GameObject must be a prefab instance" : 
                "GameObject must not be a prefab instance");
        }
    }
} 