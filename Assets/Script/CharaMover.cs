using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMover : MonoBehaviour
{
	private Animator animator;
	private KeyConfig kc;
	private bool stopping = false;
	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		kc = GameObject.FindGameObjectWithTag("KeyConfig").GetComponent<KeyConfig>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(Input.GetKey(kc.forward)){
		transform.position += transform.forward * 0.03f;
		animator.SetBool("isWalking", true);

		if(Input.GetKey(kc.run)){
			transform.position += transform.forward * 0.04f;
			animator.SetBool("isRunning", true);
		}else{
			animator.SetBool("isRunning", false);
		}
		}else{
		animator.SetBool("isWalking", false);
		animator.SetBool("isRunning", false);
		}

		if(Input.GetKey(kc.back)){
		transform.position += transform.forward * -0.01f;
		animator.SetBool("isBacking", true);
		}else{
		animator.SetBool("isBacking", false);
		}

		if(Input.GetKey(kc.left)){
		transform.Rotate(0,3,0);
		}

		if(Input.GetKey(kc.right)){
		transform.Rotate(0, -3, 0);
		}
	}

	public void OnDisable(){
		animator.SetBool("isWalking", false);
		animator.SetBool("isRunning", false);
		animator.SetBool("isBacking", false);
	}
}
