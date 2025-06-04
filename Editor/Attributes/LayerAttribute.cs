using UnityEngine;

namespace RedLineTeam.RedInspect
{
    /// <summary>
    /// Attribute to validate that a GameObject is on a specific layer.
    /// </summary>
    public class LayerAttribute : PropertyAttribute
    {
        public int RequiredLayer { get; private set; }
        public string Message { get; private set; }

        public LayerAttribute(int requiredLayer, string message = null)
        {
            RequiredLayer = requiredLayer;
            Message = message ?? $"GameObject must be on layer '{LayerMask.LayerToName(requiredLayer)}'";
        }

        public LayerAttribute(string layerName, string message = null)
        {
            RequiredLayer = LayerMask.NameToLayer(layerName);
            Message = message ?? $"GameObject must be on layer '{layerName}'";
        }
    }
} 