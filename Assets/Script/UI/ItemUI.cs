using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
 
public class ItemUI : MonoBehaviour {
    public GameObject slot;
    private Text text;
    private ItemDataBase idb = null;

    void Start(){
        idb = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
    }
 
    void OnEnable() {
        if(idb != null){
            CreateSlot(idb.getItemList());
        }
    }

    void OnDisable(){
		for( int i=0; i < transform.childCount; ++i ){
			GameObject.Destroy( transform.GetChild( i ).gameObject );
		}
    }

    public void CreateSlot(List<Item> itemList) {
 
        int i = 0;
 
        foreach (var item in itemList) {
            var instanceSlot = Instantiate<GameObject>(slot, transform);
            text = instanceSlot.transform.GetChild(0).gameObject.GetComponent<Text>();
            text.text = item.name;
            instanceSlot.name = "ItemSlot" + i++;
            instanceSlot.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}