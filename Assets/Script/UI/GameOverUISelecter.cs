using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameOverUISelecter : MonoBehaviour
{
    private KeyConfig kc;
    private int index = 0;
    private int length = 2;
    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        kc = GameObject.FindGameObjectWithTag("KeyConfig").GetComponent<KeyConfig>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(kc.forward) && index >= 0){
            if(first == true){
                first = false;
            }else{
                index -= 1;
            }
            foreach(Transform child in transform){
                child.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
            }
            transform.GetChild(index).GetComponent<Text>().color = new Color(1.0f, 0.92f, 0.016f, 1f);
        }

        if(Input.GetKeyDown(kc.back) && index < length - 1){
            if(first == true){
                first = false;
            }else{
                index += 1;
            }
            foreach(Transform child in transform){
                child.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
            }
            transform.GetChild(index).GetComponent<Text>().color = new Color(1.0f, 0.92f, 0.016f, 1f);
        }

        if(Input.GetKeyDown(kc.action) && !first){
            switch(index){
                case 0:
                    SceneManager.LoadScene ("SampleScene");
                    break;
                case 1:
                    break;
            }
        }

        // if(Input.GetKeyDown(kc.right)){
            
        // }

        // if(Input.GetKeyDown(kc.left)){
            
        // }
    }

    void selectDown(){

    }

    void selectUp(){

    }
}
