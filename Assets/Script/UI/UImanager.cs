using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    private KeyConfig kc;
    private CharaMover cm;
    private EnemyController ec;
    private UnityEngine.AI.NavMeshAgent ecnma;
    private GameObject Enemy;
    private GameObject BGColor;
    private GameObject MainPanel;

    // Start is called before the first frame update
    void Start()
    {
        BGColor = GameObject.FindGameObjectWithTag("BGColor");
        MainPanel = GameObject.FindGameObjectWithTag("MainPanel");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        cm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharaMover>();
        ec = Enemy.GetComponent<EnemyController>();
        ecnma = Enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
        kc = GameObject.FindGameObjectWithTag("KeyConfig").GetComponent<KeyConfig>();
        BGColor.SetActive (false);
        MainPanel.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(kc.menu)){
            cm.enabled = !cm.enabled;
            ec.enabled = !ec.enabled;
            ecnma.enabled = !ecnma.enabled;
            BGColor.SetActive (!BGColor.activeSelf);
            MainPanel.SetActive (!MainPanel.activeSelf);
        }
    }
}
