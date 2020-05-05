using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    private KeyConfig kc;
    private CharaMover cm;
    private GameObject BGColor;
    private GameObject MainPanel;

    // Start is called before the first frame update
    void Start()
    {
        BGColor = GameObject.FindGameObjectWithTag("BGColor");
        MainPanel = GameObject.FindGameObjectWithTag("MainPanel");
        cm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharaMover>();
        kc = GameObject.FindGameObjectWithTag("KeyConfig").GetComponent<KeyConfig>();
        BGColor.SetActive (false);
        MainPanel.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(kc.menu)){
            cm.enabled = !cm.enabled;
            BGColor.SetActive (!BGColor.activeSelf);
            MainPanel.SetActive (!MainPanel.activeSelf);
        }
    }

    // public void MenuToggle(bool bl){
    //     if(bl){
    //         cm.enabled = true;
    //         BGColor.SetActive (false);
    //         MainPanel.SetActive (false);
    //     }else{
    //         //cm.enabled = false;
    //         BGColor.SetActive (true);
    //         MainPanel.SetActive (true);
    //     }
    // }
}
