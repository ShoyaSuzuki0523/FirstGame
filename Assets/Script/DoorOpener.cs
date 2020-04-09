using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DoorOpener : MonoBehaviour
{
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
    }

    void Update() {
        if (Input.GetKeyDown("space") && isNear) {
            animator.SetBool("OPEN", !animator.GetBool("OPEN"));
            isOpen = !isOpen;
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
            return "閉める";
        }else{
            return "開ける";
        }
    }
}
