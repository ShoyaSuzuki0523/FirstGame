using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInventory : MonoBehaviour
{
    private ItemDataBase idb = null;
    public List<Item> inventory = new List<Item>();
    
    // Start is called before the first frame update
    void Start()
    {
        idb = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addItem(int itemId){
        inventory.Add(idb.getItem(itemId));
    }
}
