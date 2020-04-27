using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour
{
//リスト化をして下のvoid Start内でリストに値を追加、値は適当です  
public List<Item> items = new List<Item>();

   void Start()
    {
        items.Add(new Item(0,"サンプル鍵","これはテスト用の鍵です。",Item.ItemType.Key));
        items.Add(new Item(1,"サンプル資料","これはテスト用の資料です。",Item.ItemType.Document));
    }
}