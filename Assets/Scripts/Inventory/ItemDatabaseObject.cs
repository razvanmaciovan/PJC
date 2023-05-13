using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "ScriptableObjects/Inventory/ItemDatabaseObject")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemScriptableObject[] TotalItems;
    public Dictionary<ItemScriptableObject, int> GetId = new();
    public Dictionary<int, ItemScriptableObject> GetItem = new();
    public void OnBeforeSerialize()
    {
        GetId = new Dictionary<ItemScriptableObject, int>();
        GetItem = new Dictionary<int, ItemScriptableObject>();
        for (int i = 0; i < TotalItems.Length; i++)
        {
            GetId.Add(TotalItems[i],i);
            GetItem.Add(i,TotalItems[i]);
        }
    }

    public void OnAfterDeserialize()
    {
        if (GetId.Count == 0 && GetItem.Count == 0)
        {
            for (int i = 0; i < TotalItems.Length; i++)
            {
                GetId.Add(TotalItems[i],i);
                GetItem.Add(i,TotalItems[i]);
            }
        }
    }
}