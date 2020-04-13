using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ItemFlag : MonoBehaviour
{
    private bool isNear;
    private bool isOpen = false;
    private GameObject game_guide_object = null;
    private string text;

    void Start()
    {
        isNear = false;
        game_guide_object = GameObject.FindGameObjectWithTag("GameGuide");
    }

    async void Update() {
        if (Input.GetKeyDown("space") && isNear) {
            isOpen = true;
            Text game_guide_text = game_guide_object.GetComponent<Text> ();
            text = state(isOpen);
			game_guide_text.text = "";
            foreach(var t in text){
            	game_guide_text.text += t;
				await Task.Delay(50);
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            isNear = true;
            Text game_guide_text = game_guide_object.GetComponent<Text> ();
            game_guide_text.text = state(isOpen);
        }
    }
 
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            isNear = false;
            Text game_guide_text = game_guide_object.GetComponent<Text> ();
            game_guide_text.text = "";
        }
    }
    string state(bool isOpen){
        if(isOpen){
            return "すでに持っている";
        }else{
            return "拾う";
        }
    }
}
