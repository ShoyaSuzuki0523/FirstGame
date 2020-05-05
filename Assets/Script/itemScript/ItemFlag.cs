using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ItemFlag : MonoBehaviour
{
    private KeyConfig kc;
    private bool isNear;
    private ItemDataBase idb = null;
    private GameObject game_guide_object = null;
	private GameObject Jimaku_object = null;
	private JimakuScript js;
    private string text;

    public Item item;
   
    void Start()
    {
        kc = GameObject.FindGameObjectWithTag("KeyConfig").GetComponent<KeyConfig>();
        isNear = false;
        idb = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
        game_guide_object = GameObject.FindGameObjectWithTag("GameGuide");
		Jimaku_object = GameObject.FindGameObjectWithTag("Jimaku");
		js = Jimaku_object.GetComponent<JimakuScript> ();
    }

    async void Update() {
        if (Input.GetKeyDown(kc.action) && isNear) {
            //データベースにアイテムを登録
            idb.setItem(item);
            //テキストを表示
            Text game_guide_text = game_guide_object.GetComponent<Text> ();
			game_guide_text.text = "";
			js.JimakuText($"\"{item.name}\"を入手した。");
			gameObject.SetActive (false);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            isNear = true;
            Text game_guide_text = game_guide_object.GetComponent<Text> ();
            game_guide_text.text = "拾う";
        }
    }
 
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            isNear = false;
            Text game_guide_text = game_guide_object.GetComponent<Text> ();
            game_guide_text.text = "";
        }
    }
}
