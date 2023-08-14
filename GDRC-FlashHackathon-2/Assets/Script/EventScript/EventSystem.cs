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
                string[] msg = { "�����100��������ǧ����˭��ѡ���� ��Ф��ش���·���͡�ҡǧ���� 500,000 �ҷ",
                    "�Ҵ١ѹ��� �س�������ʹ�繤��ش��������",
                    "����ǧ������ �س����ö�Թ�����ҧ�����",
                    "�� wasd �����Թ",
                    "�س�ѧ����ö��ѡ������͡�͡ǧ�����",
                    "�� Q ���ͼ�ѡ ���������Ҿǡ�ҵ�ͧ���ͺ�س���",
                    "���㹪��Ź���� ��Ҩ��աԨ�������س��㹷ء��ѹ ���������������",
                };
                int[] indexs = { 0, 1, 2, 3, 0, 1, 2 };
                dialogueSystem.PlayDialogue(msg, indexs);
                statSO.isFirstPlay = false;
            }

            if (statSO.day > 1)
            {
                string[] msg = { "���ͧ�ҡ�س����ö��Ҫ��Ե�ʹ��������ѹ��͹",
                    "�������س���͡ 1 � 2 �ѿ����ɷ��Ъ��¤س",
                    "���͡������������ѹ�觼ŵ�ͤس��ʹ�����"
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
                string[] msg = { "������ ��Ҩ����س�ͺ�Ӷ��",
                    "�س�е�ͧ�ͺ���١������ҧ��鹤س�ж١�Ѵ�͡�ѹ��",
                    "�������դ��͡���ҧ���� 5 ��",
                };
                int[] indexs = { 0, 1, 2 };
                dialogueSystem.PlayDialogue(msg, indexs);
            }
            if (chooseEvent == 1)
            {
                string[] msg = { "������ ��Ҩ����س����ͺǧ��� �¨���pist�����ع��͹���仪��س",
                    "�س�е�ͧ�����ʹ�������ҷ���˹�",
                    "�������դ��͡���ҧ���� 5 ��",
                };
                int[] indexs = { 0, 1, 2};
                dialogueSystem.PlayDialogue(msg, indexs);
            }
            if (chooseEvent == 2)
            {
                string[] msg = { "������ ���Ѫ�͡��ŵ eatable ��ҡ��ǧ���",
                    "��觷��س��ͧ�ӡ������ѹ������ҡ���� 15 ���",
                    "�������դ��͡���ҧ���� 5 ��"
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
