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

	public int text_speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        Jimaku_text = GetComponent<Text>();
		CharaMover = GameObject.FindGameObjectWithTag("Player").GetComponent<CharaMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && !isRunning){
			Jimaku_text.text = "";
		}
    }

    async public void JimakuText(string contents){
		isRunning = true;

        foreach(var t in contents){
            Jimaku_text.text += t;
			await Task.Delay(text_speed);
        }
		Jimaku_text.text += "▼";

		isRunning = false;
    }
}
