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
            StartEvent("night");
        }
        else if (eventName.Equals("night"))
        {
            StartEvent("choosePlay");
        }
        else if (eventName.Equals("choosePlay")){
            int choosing = Choose();
            Debug.Log("Player has choose " + choosing.ToString());
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
        setCircle(0);
        string[] clearItems = { "", "", "", "" };
        setMassege(clearItems);

        if (eventName.Equals("day"))
        {
            duration = 05;
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
