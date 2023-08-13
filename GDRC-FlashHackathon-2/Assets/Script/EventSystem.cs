using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public GameObject circle, player;
    public int duration;
    public string status, currentState;
    public TMP_Text timeText, Q1, Q2, Q3, Q4;
    public Sprite C0, C2, C4;

    private bool stopping = false;
    private int eventStartTime;
    public enum DayEvent
    {
        Question, RunBars, CollectChocolate
    }
    // Start is called before the first frame update
    void Start()
    {
        duration = 0;
        stopping = true;
        StartCoroutine(StartTimer());
        StartEvent("day");
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
    private IEnumerator StartTimer()
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

            timeText.text = currentState + " : " + duration.ToString();
        }

    }

    private void PlayMinigame()
    {

    }

    private void setMassege(string[] msg)
    {
        Q1.text = msg[0];
        Q2.text = msg[1];
        Q3.text = msg[2];
        Q4.text = msg[3];
    }

    private void setCircle(int num)
    {
        if(num == 0)
        {
            circle.GetComponent<SpriteRenderer>().sprite = C0;
        }
        else if(num == 2) 
        {
            circle.GetComponent<SpriteRenderer>().sprite = C2;
        }
        else if (num == 4)
        {
            circle.GetComponent<SpriteRenderer>().sprite = C4;
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
            Loader.Load(Loader.Scene.NightScene);
        }
     
    }
    private void StartEvent(string eventName)
    {
        currentState = eventName;
        setCircle(0);
        string[] clearItems = { "", "", "", "" };
        setMassege(clearItems);

        if (eventName.Equals("day"))
        {
            duration = 60;
        }
        else if (eventName.Equals("chooseBuff"))
        {
            setCircle(2);
            string[] items = { "", "1", "2", "" };
            setMassege( items );
            duration = 15;
        }
        else if (eventName.Equals("dayEvent"))
        {
            Loader.Scene[] events = { Loader.Scene.Question, Loader.Scene.RunBars, Loader.Scene.CollectChocolate };
            int random = 0;//Random.Range(0, events.Length);
            Loader.Load(events[random]);
        }
        stopping = false;
    }
}
