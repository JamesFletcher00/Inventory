using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string itemID;
    public int itemCount;
    public Sprite itemIcon;
}

public static class ScriptableObjectExtension{
    public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
    {
        if (scriptableObject == null)
        {
            Debug.LogError($"ScriptableObject was null. returning default {typeof(T)} object.");
            return (T)ScriptableObject.CreateInstance(typeof(T));
        }
        T instance = UnityEngine.Object.Instantiate(scriptableObject);
        instance.name = scriptableObject.name;
        return instance;
    }
}
