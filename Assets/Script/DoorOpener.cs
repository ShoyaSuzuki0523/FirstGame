using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private bool isNear;
    private Animator animator;
    public GameObject go;

    void Start()
    {
        isNear = false;
        animator = go.GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown("space") && isNear) {
            animator.SetBool("OPEN", !animator.GetBool("OPEN"));
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            isNear = true;
        }
    }
 
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            isNear = false;
        }
    }
}
