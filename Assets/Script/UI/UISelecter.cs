using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Linq;

public class UISelecter : MonoBehaviour
{
    private KeyConfig kc;
    private ItemDataBase idb = null;
    private List<Item> il;
    private GameObject ItemList;
    private Text ItemName;
    private Text ItemDesc;
    private int index = 0;
    private int length = 0;
    private bool first = true;
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
        if(Input.GetKeyDown(kc.forward) && index > 0){
            if(first == true){
                first = false;
            }else{
                index -= 1;
            }
            select(index);
        }

        if(Input.GetKeyDown(kc.back) && index < length - 1){
            if(first == true){
                first = false;
            }else{
                index += 1;
            }
            select(index);
        }

        // if(Input.GetKeyDown(kc.right)){
            
        // }

        // if(Input.GetKeyDown(kc.left)){
            
        // }
    }

    void select(int index){
        ItemName.text = $"{il[index].name}";
        ItemDesc.text = $"{il[index].desc}";
        for(int i = 0; i < length; i++){
            ItemList.transform.GetChild(i).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.39f);
        }
        ItemList.transform.GetChild(index).GetComponent<Image>().color = new Color(1f, 0.92f, 0.016f, 0.39f);
    }

    public void OnEnable(){
        if (idb != null){
            first = true;
            il = idb.getItemList();
            length = idb.getItemCount();
            ItemList = GameObject.FindGameObjectWithTag("ItemList");
        }
    }

    public void OnDisable(){
        first = true;
        index = 0;
        ItemName.text = "";
        ItemDesc.text = "";
    }
}
