using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Linq;

public class ItemSelect : MonoBehaviour
{
    private KeyConfig kc;
    private ItemDataBase idb = null;
    private List<Item> il;
    private GameObject ItemList;
    private Text ItemName;
    private Text ItemDesc;
    [SerializeField] private int itemIndex = 0;
    private int itemLength = 0;
    // Start is called before the first frame update
    void Start()
    {
        kc = GameObject.FindGameObjectWithTag("KeyConfig").GetComponent<KeyConfig>();
        idb = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
        ItemName = GameObject.FindGameObjectWithTag("ItemName").GetComponent<Text>();
        ItemDesc = GameObject.FindGameObjectWithTag("ItemDesc").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(kc.forward) && itemIndex > 0){
            itemIndex -= 1;
            ItemName.text = $"{il[itemIndex].name}";
            ItemDesc.text = $"{il[itemIndex].desc}";
            for(int i = 0; i < itemLength; i++){
                ItemList.transform.GetChild(i).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.39f);
            }
            ItemList.transform.GetChild(itemIndex).GetComponent<Image>().color = new Color(1.0f, 0.92f, 0.016f, 0.39f);
         }

        if(Input.GetKeyDown(kc.back) && itemIndex < itemLength - 1){
            itemIndex += 1;
            ItemName.text = $"{il[itemIndex].name}";
            ItemDesc.text = $"{il[itemIndex].desc}";
            for(int i = 0; i < itemLength; i++){
                ItemList.transform.GetChild(i).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.39f);
            }
            ItemList.transform.GetChild(itemIndex).GetComponent<Image>().color = new Color(1f, 0.92f, 0.016f, 0.39f);
        }

        // if(Input.GetKeyDown(kc.right)){
            
        // }

        // if(Input.GetKeyDown(kc.left)){
            
        // }
    }

    public void OnEnable(){
        if (idb != null){
            il = idb.getItemList();
            itemLength = idb.getItemCount();
            ItemList = GameObject.FindGameObjectWithTag("ItemList");
        }
    }

    public void OnDisable(){
        itemIndex = 0;
        ItemName.text = "";
        ItemDesc.text = "";
    }
}
