using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionEvent : MonoBehaviour
{
    public GameObject character, background, dialogueObject, choiceObject;
    public TMP_Text dialogue, result;
    public List<TMP_Text> choiceText;
    public List<Sprite> spriteChar, spriteBack;

    private int lastnum;
    // Start is called before the first frame update
    void Start()
    {
        PlayQuestion(Random.RandomRange(0, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayQuestion(int num)
    {
        dialogueObject.SetActive(false);
        choiceObject.SetActive(true);
        if (num == 1)
        {
            dialogue.text = "�س����û�鹺�ҹ mr.bid �͹��������� 1.00 ���ԡ� �س��չ��ᾧ ����Ҷ֧˹�һ�еٺ�ҹ mr.bid �ѹ㴹�� ���๷���������� �س�з����ҧ��";
            choiceText[0].text = "�ǹ���๷����Ң����Թ";
            choiceText[1].text = "�������๷���";
            choiceText[2].text = "�͡���๷�����Ҥس�ŧ�ҧ ��������˹";
            choiceText[3].text = "�͹��Ѻ�Ѻ���๷���";
            //character.GetComponent<SpriteRenderer>().sprite = spriteChar[num - 1];
            //background.GetComponent<SpriteRenderer>().sprite = spriteChar[num - 1];
        }
        else if(num == 2)
        {

            dialogue.text = "�š���ѧ༪ԭ�Ѻ��¾Ժѵԫ����� �������й�Ӣͧ�س���ѧ����� �س��ͧ��÷��������������� �س��价���˹";
            choiceText[0].text = "��ҹ mr.bid";
            choiceText[1].text = "��ҹ���๷���";
            choiceText[2].text = "�Ѵ";
            choiceText[3].text = "��ͧ��Թ�ͧ���͹�������������¹";
            //character.GetComponent<SpriteRenderer>().sprite = spriteChar[num - 1];
            //background.GetComponent<SpriteRenderer>().sprite = spriteChar[num - 1];
        }
        else if(num == 3)
        {

            dialogue.text = "�س�繤��Һʹ ���๷����͡���س��ҷ���ҹ �����Ҩ��ѡ�Ҥس �س�з����ҧ��";
            choiceText[0].text = "�ͺ��ŧ";
            choiceText[1].text = "����ʸ";
            choiceText[2].text = "�����������Թ ������Ժ˹ѧ��͢������ҹ";
            choiceText[3].text = "�͡���๷�����Ңͺ�س�ҡ ��仪ǹ���͹�ҡ����������§����Ш͡�ȡ�͹";
            //character.GetComponent<SpriteRenderer>().sprite = spriteChar[num - 1];
            //background.GetComponent<SpriteRenderer>().sprite = spriteChar[num - 1];
        }
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
                    result.text = "���๷����駵��Ǩ �֧�Ҩкء��ҹ mr.bid ����͹�ѹ ����������Ң����Թ ���Ң��¤͹෹��";
                    break;
                case 2:
                    result.text = "���๷�����մ��ͧ���¤����纻Ǵ ���§�ͧ���๷�����ء mr.bid";
                    break;
                case 3:
                    result.text = "���๷����Ҥس��Ѻ��ҹ";
                    break;
                case 4:
                    result.text = "�س�͹��Ѻ���ҧ�դ����آ ��С�Ѻ��ҹ��͹ mr.bid ��� �֧��������Թ ��س���������ҧʴ��";
                    break;
            }
        }
        else if(lastnum == 2)
        {
            switch (num)
            {
                case 1:
                    result.text = "��ҹ mr.bid �ա�û�ͧ�ѹ���ҧ��˹� ������ʺ�§��§������Ѻ����駻����";
                    break;
                case 2:
                    result.text = "���๷����繫�����";
                    break;
                case 3:
                    result.text = "�س��ͧ��������� ���������դҶһ�Һ������ �����Ѵ�ѧ���������繻���ҳ�ҡ";
                    break;
                case 4:
                    result.text = "�֧�س����Թ��ѡ�� �����§�͵�͡����Ҫ��Ե�ʹ";
                    break;
            }
        }
        else if(lastnum == 3)
        {
            switch (num)
            {
                case 1:
                    result.text = "���๷����繫�����";
                    break;
                case 2:
                    result.text = "�س�Դ�١���� �س�Դ������๷�����ŧ�ع�ѡ�Ҥ���蹨�ԧ����";
                    break;
                case 3:
                    result.text = "�س�Һʹ lol";
                    break;
                case 4:
                    result.text = "�س˹ըҡ���๷�������";
                    break;
            }
        }
    }
}