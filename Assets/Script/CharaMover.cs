using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMover : MonoBehaviour
{
  private Animator animator;
  // Start is called before the first frame update
  void Start()
  {
      animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKey(KeyCode.W)){
      transform.position += transform.forward * 0.03f;
      animator.SetBool("isWalking", true);

      if(Input.GetKey(KeyCode.LeftShift)){
        transform.position += transform.forward * 0.04f;
        animator.SetBool("isRunning", true);
      }else{
        animator.SetBool("isRunning", false);
      }
    }else{
      animator.SetBool("isWalking", false);
      animator.SetBool("isRunning", false);
    }

    if(Input.GetKey(KeyCode.S)){
      transform.position += transform.forward * -0.01f;
      animator.SetBool("isBacking", true);
    }else{
      animator.SetBool("isBacking", false);
    }

    if(Input.GetKey(KeyCode.D)){
      transform.Rotate(0,3,0);
    }

    if(Input.GetKey(KeyCode.A)){
      transform.Rotate(0, -3, 0);
    }
  }
}
