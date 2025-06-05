using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to validate that a GameObject is in a specific scene.
    /// </summary>
    public class SceneAttribute : PropertyAttribute
    {
        public string RequiredScene { get; private set; }
        public string Message { get; private set; }

        public SceneAttribute(string requiredScene, string message = null)
        {
            RequiredScene = requiredScene;
            Message = message ?? $"GameObject must be in the scene '{requiredScene}'!";
        }
    }
} 