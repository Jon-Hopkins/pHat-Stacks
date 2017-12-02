using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImer : MonoBehaviour {

    public Text timeText;

    float seconds;
    float minutes;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimerUI();
        //Debug.Log();
	}

    void TimerUI()
    {
        seconds += Time.deltaTime;

        timeText.text = (int) minutes + ":" + (int) seconds;
        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }

        
    }
}
