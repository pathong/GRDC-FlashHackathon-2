using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public GameObject circle, player, generater, choice;
    public int duration;
    public string status, currentState;
    public TMP_Text timeText;
    public DialogueSystem dialogueSystem;

    [SerializeField] private StatSO statSO;

    public bool stopping = false, chooseBuff = false;
    private int chooseEvent;

    Loader.Scene[] events = { Loader.Scene.Question, Loader.Scene.RunBars, Loader.Scene.CollectChocolate };

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

        generater.GetComponent<GeneratePlayer>().Generate();
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

            if (stopping)
            {
                timeText.text = "";
                continue;
            }

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
            StartEvent("dayEvent");
        }
        else if (eventName.Equals("dayEvent"))
        {
            circle.SetActive(false);
            Loader.Load(events[chooseEvent]);
        }
     
    }
    private void StartEvent(string eventName)
    {
        currentState = eventName;

        if (eventName.Equals("day"))
        {
            duration = 4;
            if (statSO.isFirstPlay)
            {
                string[] msg = { "ผมเอา100คนมาไว้ในวงกลมใหญ่ยักษ์นี้ และคนสุดท้ายที่ออกจากวงจะได้ 500,000 บาท",
                    "มาดูกันว่า คุณจะอยู่รอดเป็นคนสุดท้ายมั้ย",
                    "ภายในวงกลมนี้ คุณสามารถเดินได้อย่างอิสระ",
                    "กด wasd เพื่อเดิน",
                    "คุณยังสามารถผลักคนอื่นออกนอกวงได้ด้วย",
                    "กด Q เพื่อผลัก แต่ผมมั่นใจว่าพวกเขาต้องไม่ชอบคุณแน่ๆ",
                    "และในชาเลนจ์นี้ เราจะมีกิจกรรมให้คุณทำในทุกๆวัน เตรียมตัวไว้ให้ดี",
                };
                int[] indexs = { 0, 1, 2, 3, 0, 1, 2 };
                dialogueSystem.PlayDialogue(msg, indexs);
                statSO.isFirstPlay = false;
            }

            if (statSO.day > 1)
            {
                string[] msg = { "เนื่องจากคุณสามารถเอาชีวิตรอดได้เมื่อวันก่อน",
                    "ผมจะให้คุณเลือก 1 ใน 2 บัฟพิเศษที่จะช่วยคุณ",
                    "เลือกดีๆหล่ะเพราะมันส่งผลต่อคุณตลอดทั้งเกม"
                };
                int[] indexs = { 0, 1, 2 };
                chooseBuff = true;
                dialogueSystem.PlayDialogue(msg, indexs);

            }
        }
        else if (eventName.Equals("dayEvent"))
        {
            duration = 10;
            chooseEvent = 2;//Random.Range(0, events.Length);
            if (chooseEvent == 0)
            {
                string[] msg = { "เกมต่อไป เราจะให้คุณตอบคำถาม",
                    "คุณจะต้องตอบให้ถูกไม่อย่างนั้นคุณจะถูกคัดออกทันที",
                    "เกมนี้จะมีคนออกอย่างน้อย 5 คน",
                };
                int[] indexs = { 0, 1, 2 };
                dialogueSystem.PlayDialogue(msg, indexs);
            }
            if (chooseEvent == 1)
            {
                string[] msg = { "เกมต่อไป เราจะให้คุณวิ่งรอบวงกลม โดยจะมีpistคอยหมุนท่อนไม้ไปชนคุณ",
                    "คุณจะต้องอยู่รอดภายในเวลาที่กำหนด",
                    "เกมนี้จะมีคนออกอย่างน้อย 5 คน",
                };
                int[] indexs = { 0, 1, 2};
                dialogueSystem.PlayDialogue(msg, indexs);
            }
            if (chooseEvent == 2)
            {
                string[] msg = { "เกมต่อไป จะมัช็อกโกแลต eatable ปรากฎในวงกลม",
                    "สิ่งที่คุณต้องทำก็คือเก็บมันให้ได้มากกว่า 15 ชิ้น",
                    "เกมนี้จะมีคนออกอย่างน้อย 5 คน"
                };
                int[] indexs = { 0, 1, 2};
                dialogueSystem.PlayDialogue(msg, indexs);
            }
        }
        stopping = false;
    }

    public void DialogueEnd()
    {
        if (chooseBuff)
        {
            chooseBuff = false;
            ChooseBuff();
        }
    }

    private void ChooseBuff()
    {
        choice.SetActive(true);
        player.SetActive(false);
    }

    public void ClickButton(int num)
    {
        choice.SetActive(false);
        player.SetActive(true);
    }
}
