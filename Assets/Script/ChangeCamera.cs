using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
  public Camera Camera;

  void OnTriggerEnter(Collider other){
    if(other.CompareTag("Player")){
      GameObject[] otherCameras = GameObject.FindGameObjectsWithTag("GameCamera");
      foreach(GameObject camera in otherCameras){
        camera.GetComponent<Camera>().enabled = false;
      }
      Camera.enabled = true;
    }
  }

  void OnTriggerStay(Collider other){
    Camera.enabled = true;
  }

  void OnTriggerExit(Collider other){
    if(other.CompareTag("Player")){
      Camera.enabled = false;
    }
  }
}
