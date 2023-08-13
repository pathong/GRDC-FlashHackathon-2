using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionEvent : MonoBehaviour
{
    public GameObject character1, character2, background, dialogueObject, choiceObject;
    public TMP_Text dialogue, result;
    public List<TMP_Text> choiceText;
    public List<Sprite> spriteChar1, spriteChar2, spriteBack;

    private int lastnum;
    private bool isWin, isLose;
    // Start is called before the first frame update
    void Start()
    {
        PlayQuestion(Random.RandomRange(1, 4));
        isWin = false;
        isLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isWin) Loader.Load(Loader.Scene.NightScene);
        }
    }

    private void PlayQuestion(int num)
    {
        dialogueObject.SetActive(false);
        choiceObject.SetActive(true);
        if (num == 1)
        {
            dialogue.text = "คุณคือโจรปล้นบ้าน mr.bid ตอนนี้เป็นเวลา 1.00 นาฬิกา คุณได้ปีนกำแพง และมาถึงหน้าประตูบ้าน mr.bid ทันใดนั้น มายเนทเมทก็โผล่มา คุณจะทำอย่างไร";
            choiceText[0].text = "ชวนมายเนทเมทมาขโมยเงิน";
            choiceText[1].text = "ต่อยมายเนทเมท";
            choiceText[2].text = "บอกมายเนทเมทว่าคุณหลงทาง ที่นี่ที่ไหน";
            choiceText[3].text = "นอนหลับกับมายเนทเมท";
            
        }
        else if(num == 2)
        {

            dialogue.text = "โลกกำลังเผชิญกับภัยพิบัติซอมบี้ อาหารและน้ำของคุณกำลังจะหมด คุณต้องการที่อยู่อาศัยใหม่ คุณจะไปที่ไหน";
            choiceText[0].text = "บ้าน mr.bid";
            choiceText[1].text = "บ้านมายเนทเมท";
            choiceText[2].text = "วัด";
            choiceText[3].text = "ห้องใต้ดินของเพื่อนที่ไม่เคยมาเรียน";
        }
        else if(num == 3)
        {

            dialogue.text = "คุณเป็นคนตาบอด มายเนทเมทบอกให้คุณไปหาที่บ้าน และเค้าจะรักษาคุณ คุณจะทำอย่างไร";
            choiceText[0].text = "ตอบตกลง";
            choiceText[1].text = "ปฏิเสธ";
            choiceText[2].text = "แกล้งเป็นไม่ได้ยิน แล้วหยิบหนังสือขึ้นมาอ่าน";
            choiceText[3].text = "บอกมายเนทเมทว่าขอบคุณมาก ขอไปชวนเพื่อนๆจากชมรมคนเลี้ยงนกกระจอกเทศก่อน";
        }
        character1.GetComponent<Image>().sprite = spriteChar1[num - 1];
        character2.GetComponent<Image>().sprite = spriteChar2[num - 1];
        background.GetComponent<Image>().sprite = spriteBack[num - 1];
        lastnum = num;
    }

    public void ClickButton(int num)
    {
        dialogueObject.SetActive(true);
        choiceObject.SetActive(false);
        if(lastnum == 1)
        {
            switch (num)
            {
                case 1:
                    result.text = "มายเนทเมทแจ้งตำรวจ ถึงเขาจะบุกบ้าน mr.bid เหมือนกัน แต่เขาไม่ได้มาขโมยเงิน เขามาขโมยคอนเทนต์";
                    isLose = true;
                    break;
                case 2:
                    result.text = "มายเนทเมทกรีดร้องด้วยความเจ็บปวด เสียงของมายเนทเมทปลุก mr.bid";
                    isLose = true;
                    break;
                case 3:
                    result.text = "มายเนทเมทพาคุณกลับบ้าน";
                    isWin = true;
                    break;
                case 4:
                    result.text = "คุณนอนหลับอย่างมีความสุข และกลับบ้านก่อน mr.bid ตื่น ถึงจะไม่ได้เงิน แต่คุณก็ตื่นมาอย่างสดใส";
                    isWin = true;
                    break;
            }
        }
        else if(lastnum == 2)
        {
            switch (num)
            {
                case 1:
                    result.text = "บ้าน mr.bid มีการป้องกันอย่างแน่นหนา และมีเสบียงเพียงพอสำหรับคนทั้งประเทศ";
                    isWin = true;
                    break;
                case 2:
                    result.text = "มายเนทเมทเป็นซอมบี้";
                    isLose = true;
                    break;
                case 3:
                    result.text = "คุณต้องไม่เชื่อแน่ เจ้าอาวาสมีคาถาปราบซอมบี้ และในวัดยังมีหมาแมวเป็นปริมาณมาก";
                    isWin = true;
                    break;
                case 4:
                    result.text = "ถึงคุณจะได้กินแต่นักเก็ต แต่ก็เพียงพอต่อการเอาชีวิตรอด";
                    isWin = true;
                    break;
            }
        }
        else if(lastnum == 3)
        {
            switch (num)
            {
                case 1:
                    result.text = "มายเนทเมทเป็นซอมบี้";
                    isLose = true;
                    break;
                case 2:
                    result.text = "คุณคิดถูกแล้ว คุณคิดว่ามายเนทเมทจะลงทุนรักษาคนอื่นจริงๆหรอ";
                    isWin = true;
                    break;
                case 3:
                    result.text = "คุณตาบอด lol";
                    isLose = true;
                    break;
                case 4:
                    result.text = "คุณหนีจากมายเนทเมทมาได้";
                    isWin = true;
                    break;
            }
        }
    }
}
