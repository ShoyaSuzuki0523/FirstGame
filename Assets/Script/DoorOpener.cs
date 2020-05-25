using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DoorOpener : MonoBehaviour
{
    private KeyConfig kc;
    private bool isNear;
    private bool isOpen = false;
    private Animator animator;
    private GameObject game_guide_object = null;
    public GameObject go;

    void Start()
    {
        isNear = false;
        animator = go.GetComponent<Animator>();
        game_guide_object = GameObject.FindGameObjectWithTag("GameGuide");
        kc = GameObject.FindGameObjectWithTag("KeyConfig").GetComponent<KeyConfig>();
    }

    void Update() {
        if (Input.GetKeyDown(kc.action) && isNear) {
            animator.SetBool("OPEN", !animator.GetBool("OPEN"));
            isOpen = !isOpen;
            if(game_guide_object != null){
                Text game_guide_text = game_guide_object.GetComponent<Text> ();
                game_guide_text.text = state(isOpen);
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            isNear = true;
            if(game_guide_object != null){
                Text game_guide_text = game_guide_object.GetComponent<Text> ();
                game_guide_text.text = state(isOpen);
            }
        }
    }
 
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            isNear = false;
            if(game_guide_object != null){
                Text game_guide_text = game_guide_object.GetComponent<Text> ();
                game_guide_text.text = "";
            }
        }
    }
    string state(bool isOpen){
        if(isOpen){
            return "閉める";
        }else{
            return "開ける";
        }
    }
}
