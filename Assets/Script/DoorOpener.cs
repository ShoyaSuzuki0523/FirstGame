using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DoorOpener : MonoBehaviour
{
    private bool isNear;
    private Animator animator;
    public GameObject go;

    public GameObject game_guide_object = null;

    void Start()
    {
        isNear = false;
        animator = go.GetComponent<Animator>();
        game_guide_object = GameObject.FindGameObjectWithTag("GameGuide");
    }

    void Update() {
        if (Input.GetKeyDown("space") && isNear) {
            animator.SetBool("OPEN", !animator.GetBool("OPEN"));
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            isNear = true;
            Text game_guide_text = game_guide_object.GetComponent<Text> ();
            game_guide_text.text = "OPEN";
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
