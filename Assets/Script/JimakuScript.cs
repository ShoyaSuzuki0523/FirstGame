using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;
using UnityEngine.UI;

public class JimakuScript : MonoBehaviour
{
	private Text Jimaku_text;
	private bool isRunning = false;
	private CharaMover CharaMover;
    private GameObject Enemy;
    private EnemyController EnemyController;
    private UnityEngine.AI.NavMeshAgent ecnma;

	public int text_speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        Jimaku_text = GetComponent<Text>();
		CharaMover = GameObject.FindGameObjectWithTag("Player").GetComponent<CharaMover>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyController = Enemy.GetComponent<EnemyController>();
        ecnma = Enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && !isRunning){
			Jimaku_text.text = "";
            CharaMover.enabled = true;
            EnemyController.enabled = true;
            ecnma.enabled = true;
		}
    }

    async public void JimakuText(string contents){
		isRunning = true;

        CharaMover.enabled = false;
        EnemyController.enabled = false;
        ecnma.enabled = false;

        foreach(var t in contents){
            Jimaku_text.text += t;
			await Task.Delay(text_speed);
        }
		Jimaku_text.text += "▼";

		isRunning = false;
    }
}
