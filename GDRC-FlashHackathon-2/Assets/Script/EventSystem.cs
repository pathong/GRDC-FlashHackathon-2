using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public GameObject circle, player;
    public string currentState;

    public int duration;
    public string status;
    public TMP_Text timeText;

    private bool stopping = false;
    private int eventStartTime;

    // Start is called before the first frame update
    void Start()
    {
        duration = 0;
        stopping = true;
        StartCoroutine(startTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Choose()
    {
        Vector3 pos = player.transform.position - circle.transform.position;
        if (pos.x >= 0 && pos.y >= 0) return 2;
        else if (pos.x < 0 && pos.y >= 0) return 3;
        else if(pos.x < 0 && pos.y < 0) return 4;
        else return 1;
    }
    private IEnumerator startTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (stopping) continue;

            duration -= 1;
            if (duration <= 0)
            {
                stopping = true;
                EndEvent(currentState);
            }

            timeText.text = "state : " + duration.ToString();
        }

    }

    private void PlayMinigame()
    {

    }

    private void EndEvent(string eventName)
    {
        if (eventName.Equals("day"))
        {
            StartEvent("chooseBuff");
        }
        else if (eventName.Equals("chooseBuff"))
        {
            int choosing = Choose();
            Debug.Log("Player has choose " +  choosing.ToString());
            StartEvent("dayEvent");
        }
        else if (eventName.Equals("dayEvent"))
        {
            StartEvent("night");
        }
        else if (eventName.Equals("night"))
        {
            StartEvent("choosePlay");
        }
        else if (eventName.Equals("choosePlay")){
            int choosing = Choose();
            if (choosing <= 2) StartEvent("day");
            else StartEvent("chooseNightPlay");
        }
        else if (eventName.Equals("chooseNightPlay"))
        {
            int choosing = Choose();
            Debug.Log("Player has choose " + choosing.ToString());
            StartEvent("nightEvent");
        }
        else if (eventName.Equals("nightEvent"))
        {
            StartEvent("day");
        }
    }
    private void StartEvent(string eventName)
    {
        currentState = eventName;
        if(eventName.Equals("day"))
        {
            duration = 30;
        }
        else if (eventName.Equals("chooseBuff"))
        {
            duration = 15;
        }
        else if (eventName.Equals("dayEvent"))
        {
            duration = 60;
        }
        else if (eventName.Equals("night"))
        {
            duration = 30;
        }
        else if (eventName.Equals("choosePlay"))
        {
            duration = 10;
        }
        else if (eventName.Equals("chooseNightPlay")){
            duration = 15;
        }
        else if (eventName.Equals("nightEvent"))
        {
            duration = 90;
        }
        stopping = false;
    }
}
