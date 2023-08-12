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
        if (pos.x >= 0 && pos.y >= 0) return 1;
        else if (pos.x < 0 && pos.y >= 0) return 2;
        else if(pos.x < 0 && pos.y < 0) return 3;
        else return 4;
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

            timeText.text = duration.ToString();
        }

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
            StartEvent("nightEvent");
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
        else if (eventName.Equals("nightEvent"))
        {
            duration = 30;
        }
        stopping = false;
    }
}
