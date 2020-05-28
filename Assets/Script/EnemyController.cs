﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
 
    public Transform goal;          //目的地となるオブジェクトのトランスフォーム格納用
    private NavMeshAgent agent;     //エージェントとなるオブジェクトのNavMeshAgent格納用 
 
	// Use this for initialization
	void Start () {
        //エージェントのNaveMeshAgentを取得する
        agent = GetComponent<NavMeshAgent>();
        //目的地となる座標を設定する
        //agent.destination = goal.position;
    }

    void Update(){
        agent.destination = goal.position;
    }

    void OnCollisionEnter(Collision collision){
        Debug.Log("タッチ！");
        SceneManager.LoadScene ("GameOver");
    }
}
