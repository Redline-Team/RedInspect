using UnityEngine;
using System.Collections.Generic;
using System;

namespace RedLineTeam.RedInspect
{
    [Serializable]
    public class ComponentState
    {
        public string ComponentType;
        public Dictionary<string, object> PropertyValues = new Dictionary<string, object>();
        public DateTime Timestamp;

        public ComponentState(Component component)
        {
            ComponentType = component.GetType().FullName;
            Timestamp = DateTime.Now;
            
            var properties = component.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var prop in properties)
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    try
                    {
                        PropertyValues[prop.Name] = prop.GetValue(component);
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning($"Failed to save property {prop.Name}: {e.Message}");
                    }
                }
            }
        }

        public void ApplyTo(Component component)
        {
            if (component.GetType().FullName != ComponentType)
            {
                Debug.LogError($"Cannot apply state: Component type mismatch. Expected {ComponentType}, got {component.GetType().FullName}");
                return;
            }

            var properties = component.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var prop in properties)
            {
                if (prop.CanRead && prop.CanWrite && PropertyValues.ContainsKey(prop.Name))
                {
                    try
                    {
                        prop.SetValue(component, PropertyValues[prop.Name]);
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning($"Failed to restore property {prop.Name}: {e.Message}");
                    }
                }
            }
        }
    }

    public class ComponentStateHistory
    {
        private const int MaxHistorySize = 10;
        private List<ComponentState> states = new List<ComponentState>();

        public void SaveState(Component component)
        {
            var newState = new ComponentState(component);
            states.Add(newState);

            // Keep only the last MaxHistorySize states
            while (states.Count > MaxHistorySize)
            {
                states.RemoveAt(0);
            }
        }

        public bool HasHistory => states.Count > 0;

        public ComponentState GetLatestState()
        {
            return states.Count > 0 ? states[states.Count - 1] : null;
        }

        public void RestoreLatestState(Component component)
        {
            if (states.Count > 0)
            {
                states[states.Count - 1].ApplyTo(component);
            }
        }

        public void ClearHistory()
        {
            states.Clear();
        }
    }
} 