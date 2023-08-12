using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{

    public int duration;
    public string status;

    private bool stopping = false;
    private int GAME_DURATION = 10;

    // Start is called before the first frame update
    void Start()
    {
        duration = GAME_DURATION;
        status = "day";
        StartCoroutine(startTimer());    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startTimer()
    {
        while (true)
        {
            if (!stopping) duration -= 1;

            if(duration <= 0)
            {
                if (status.Equals("day")) status = "night";
                else status = "day";
                duration = GAME_DURATION;
            }


            yield return new WaitForSeconds(1);
        }

    }
}
