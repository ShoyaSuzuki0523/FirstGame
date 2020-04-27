using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item 
{
    public int itemID;
    public string itemName;
    public string itemDesc;
    public ItemType itemType;
   
    public enum ItemType
    {
        Key,
        Document,
    }

	public Item(int id, string name, string desc, ItemType type)
    {
        itemID = id;
        itemName = name;
        itemDesc = desc;
        itemType = type;
    }

}