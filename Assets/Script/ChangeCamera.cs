using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
  private Camera Camera = null;
  private AudioListener al = null;

  void Start(){
    Camera = transform.parent.gameObject.GetComponent<Camera>();
    al = transform.parent.gameObject.GetComponent<AudioListener>();
  }

  void OnTriggerEnter(Collider other){
    if(other.CompareTag("Player")){
      GameObject[] otherCameras = GameObject.FindGameObjectsWithTag("GameCamera");
      foreach(GameObject camera in otherCameras){
        camera.GetComponent<Camera>().enabled = false;
        camera.GetComponent<AudioListener>().enabled = false;
      }
      Camera.enabled = true;
      al.enabled = true;
    }
  }

  void OnTriggerStay(Collider other){
    if(other.CompareTag("Player")){
      Camera.enabled = true;
      al.enabled = true;
    }
  }

  void OnTriggerExit(Collider other){
    if(other.CompareTag("Player")){
      Camera.enabled = false;
      al.enabled = false;
    }
  }
}
