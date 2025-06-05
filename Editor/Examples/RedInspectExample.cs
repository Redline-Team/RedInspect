using UnityEngine;
using RedLineTeam.RedInspect;
using UnityEditor;

/// <summary>
/// Example component demonstrating all features of RedInspect.
/// </summary>
[AddComponentMenu("Redline/RedInspect/Example Component")]
public class RedInspectExample : MonoBehaviour
{
    [Header("Required Fields")]
    [Required("This field is required!")]
    public GameObject requiredObject;

    [Required("This field is required!")]
    public Transform requiredTransform;

    [Required("This field is required!")]
    public Component requiredComponent;

    [Header("Tag Restrictions")]
    [Tag("Player", "Object must have the Player tag!")]
    public GameObject playerObject;

    [Tag("Enemy", "Object must have the Enemy tag!")]
    public GameObject enemyObject;

    [Tag("Untagged", "Object must be untagged!")]
    public GameObject untaggedObject;

    [Header("Layer Restrictions")]
    [Layer("Default", "Object must be on the Default layer!")]
    public GameObject defaultLayerObject;

    [Layer("UI", "Object must be on the UI layer!")]
    public GameObject uiLayerObject;

    [Layer("Water", "Object must be on the Water layer!")]
    public GameObject waterLayerObject;

    [Header("Scene Restrictions")]
    [Scene("MainScene", "Object must be in the MainScene!")]
    public GameObject mainSceneObject;

    [Scene("Level1", "Object must be in Level1!")]
    public GameObject level1Object;

    [Header("Prefab Restrictions")]
    [Prefab(true, "Object must be a prefab instance!")]
    public GameObject prefabInstance;

    [Prefab(false, "Object must not be a prefab instance!")]
    public GameObject nonPrefabObject;

    [Header("Combined Restrictions")]
    [Required("This field is required!")]
    [Tag("Player", "Object must have the Player tag!")]
    public GameObject requiredPlayerObject;

    [Required("This field is required!")]
    [Layer("UI", "Object must be on the UI layer!")]
    public GameObject requiredUIObject;

    [Required("This field is required!")]
    [Prefab(true, "Object must be a prefab instance!")]
    public GameObject requiredPrefabObject;

    [Required("This field is required!")]
    [Tag("Player", "Object must have the Player tag!")]
    [Layer("Default", "Object must be on the Default layer!")]
    public GameObject requiredPlayerDefaultObject;

    [Required("This field is required!")]
    [Tag("Enemy", "Object must have the Enemy tag!")]
    [Prefab(true, "Object must be a prefab instance!")]
    public GameObject requiredEnemyPrefabObject;

    [Header("Component References")]
    [Required("This field is required!")]
    public Rigidbody requiredRigidbody;

    [Required("This field is required!")]
    public Collider requiredCollider;

    [Required("This field is required!")]
    public Renderer requiredRenderer;

    [Header("Array Restrictions")]
    [Required("This field is required!")]
    [Tag("Player", "Objects must have the Player tag!")]
    public GameObject[] playerObjects;

    [Required("This field is required!")]
    [Layer("UI", "Objects must be on the UI layer!")]
    public GameObject[] uiObjects;

    [Required("This field is required!")]
    [Prefab(true, "Objects must be prefab instances!")]
    public GameObject[] prefabObjects;

    [Header("Nested Components")]
    [Required("This field is required!")]
    public NestedComponent nestedComponent;

    [Required("This field is required!")]
    public NestedComponent[] nestedComponents;

    [Header("Scriptable Objects")]
    [Required("This field is required!")]
    public ExampleScriptableObject requiredScriptableObject;

    [Required("This field is required!")]
    public ExampleScriptableObject[] requiredScriptableObjects;

    [Header("Custom Validation")]
    private bool _customValidationHeader; // Dummy field for header

    [Validate("GameObject must have a Rigidbody component!")]
    private bool ValidateRigidbody()
    {
        return requiredObject != null && requiredObject.GetComponent<Rigidbody>() != null;
    }

    [Validate("GameObject must have a Collider component!")]
    private bool ValidateCollider()
    {
        return requiredObject != null && requiredObject.GetComponent<Collider>() != null;
    }
}

/// <summary>
/// Example nested component for demonstrating nested validation.
/// </summary>
[System.Serializable]
public class NestedComponent
{
    [Header("Nested Fields")]
    [Required("This field is required!")]
    [Tag("Player", "Object must have the Player tag!")]
    public GameObject playerObject;

    [Required("This field is required!")]
    [Layer("UI", "Object must be on the UI layer!")]
    public GameObject uiObject;

    [Required("This field is required!")]
    [Prefab(true, "Object must be a prefab instance!")]
    public GameObject prefabObject;
}

/// <summary>
/// Example scriptable object for demonstrating scriptable object validation.
/// </summary>
[CreateAssetMenu(fileName = "ExampleScriptableObject", menuName = "RedInspect/Example Scriptable Object")]
public class ExampleScriptableObject : ScriptableObject
{
    [Header("Scriptable Object Fields")]
    [Required("This field is required!")]
    public GameObject requiredObject;

    [Required("This field is required!")]
    [Tag("Player", "Object must have the Player tag!")]
    public GameObject requiredPlayerObject;

    [Required("This field is required!")]
    [Layer("UI", "Object must be on the UI layer!")]
    public GameObject requiredUIObject;
}
