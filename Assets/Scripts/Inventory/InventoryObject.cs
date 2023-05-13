using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "ScriptableObjects/Inventory/InventoryObject")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    private ItemDatabaseObject _database;
    public List<InventorySlot> Container = new();

    private void OnEnable()
    { 
        _database = Resources.Load<ItemDatabaseObject>("ScriptableObjects/Items/ItemDatabase");
    }
    public void AddItem(ItemScriptableObject item, int amount = 1)
    {
        var slot = Container.FirstOrDefault(t => t.Item == item);
        if (slot is not null)
        {
            slot.AddAmount(amount);
        }
        else
        {
            Container.Add(new InventorySlot(_database.GetId[item],item, amount));
        }
    }

    public void RemoveItem(ItemScriptableObject item)
    {
        var slot = Container.FirstOrDefault(t => t.Item == item);
        if (slot is not null)
        {
            slot.SubtractAmount();
            if (slot.Amount <= 0)
            {
                Container.Remove(slot);
            }
        }
        else
        {
            Debug.LogError($"Cannot remove item with id {item.Id} because it does not exit in inventory");
        }
    }

    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        Container.ForEach(i =>
            i.Item = _database.GetItem[i.Id]);
    }
}

[System.Serializable]
public class InventorySlot
{
    public int Id;
    public ItemScriptableObject Item;
    public int Amount;

    public InventorySlot(int id,ItemScriptableObject item, int amount)
    {
        this.Id = id;
        this.Item = item;
        this.Amount = amount;
    }

    public void AddAmount(int value = 1)
    {
        Amount += value;
    }

    public void SubtractAmount(int value = 1)
    {
        Amount -= value;
    }
}