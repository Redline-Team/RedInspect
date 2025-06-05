using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to validate that a GameObject is on a specific layer.
    /// </summary>
    public class LayerAttribute : PropertyAttribute
    {
        public string RequiredLayer { get; private set; }
        public string Message { get; private set; }

        public LayerAttribute(string requiredLayer, string message = null)
        {
            RequiredLayer = requiredLayer;
            Message = message ?? $"GameObject must be on the layer '{requiredLayer}'!";
        }
    }
} 