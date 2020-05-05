using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
 
public class ItemUI : MonoBehaviour {
 
    //　アイテム情報のスロットプレハブ
    public GameObject slot;
    //プレハブ内のアイテム名テキスト
    private Text text;
    //　アイテムデータベース
    private ItemDataBase idb;

    //test
    //private List<Item> items = new List<Item>();

    void Start(){
        idb = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();

        //test
        // items.Add(new Item(0,"サンプル鍵","これはテスト用の鍵です。",Item.ItemType.Key));
        // items.Add(new Item(1,"サンプル資料","これはテスト用の資料です。",Item.ItemType.Document));
    }
 
    //　アクティブになった時
    void OnEnable() {
        //　アイテムデータベースに登録されているアイテム用のスロットを全作成
        CreateSlot(idb.getItemList());

        //test
        // CreateSlot(items);
    }

    void OnDisable(){
		for( int i=0; i < transform.childCount; ++i ){
			GameObject.Destroy( transform.GetChild( i ).gameObject );
		}
    }
    
    //　アイテムスロットの作成
    public void CreateSlot(List<Item> itemList) {
 
        int i = 0;
 
        foreach (var item in itemList) {
            //　スロットのインスタンス化
            var instanceSlot = Instantiate<GameObject>(slot, transform);

            //  アイテムスロット内のテキストを編集
            text = instanceSlot.transform.GetChild(0).gameObject.GetComponent<Text>();
            text.text = item.name;

            //　スロットゲームオブジェクトの名前を設定
            instanceSlot.name = "ItemSlot" + i++;
            //　Scaleを設定しないと0になるので設定
            instanceSlot.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}