using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialogue, player;
    public EventSystem eventSystem;
    public TMP_Text text;
    public GameObject img;
    public List<Sprite> AllImg;

    private string[] msg;
    private int[] indexs;

    private bool ready = true, stop = true;
    private int currindex;
    public void PlayDialogue(string[] msg, int[] indexs)
    {
        dialogue.SetActive(true);
        this.msg = msg;
        this.indexs = indexs;
        currindex = 0;
        stop = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ready)
        {
            ready = false;
            currindex++;
            StartCoroutine(Cooldown());
        }

        if (!stop) UpdateDialogue();
    }

    private void UpdateDialogue()
    {
        if (currindex >= msg.Length)
        {
            stop = true;
            eventSystem.DialogueEnd();
            dialogue.SetActive(false);
            return;
        }
        text.text = msg[currindex];
        img.GetComponent<Image>().sprite = AllImg[indexs[currindex]];
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        ready = true;
    }

}
