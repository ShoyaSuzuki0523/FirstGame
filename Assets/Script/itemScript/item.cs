using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item 
{
    public int id;
    public string name;
    public string desc;
    public ItemType type;
   
    public enum ItemType
    {
        Key,
        Document,
    }

	public Item(int i, string n, string d, ItemType t)
    {
        id = i;
        name = n;
        desc = d;
        type = t;
    }

}