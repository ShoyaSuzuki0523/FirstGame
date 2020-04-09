using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ItemFlag : MonoBehaviour
{
    private bool isNear;
    private bool isOpen = false;
    private GameObject game_guide_object = null;

    void Start()
    {
        isNear = false;
        game_guide_object = GameObject.FindGameObjectWithTag("GameGuide");
    }

    void Update() {
        if (Input.GetKeyDown("space") && isNear) {
            isOpen = true;
            Text game_guide_text = game_guide_object.GetComponent<Text> ();
            game_guide_text.text = state(isOpen);
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
