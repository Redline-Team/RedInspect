using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to validate that a GameObject has a specific tag.
    /// </summary>
    public class TagAttribute : PropertyAttribute
    {
        public string RequiredTag { get; private set; }
        public string Message { get; private set; }

        public TagAttribute(string requiredTag, string message = null)
        {
            RequiredTag = requiredTag;
            Message = message ?? $"GameObject must have the tag '{requiredTag}'";
        }
    }
} 