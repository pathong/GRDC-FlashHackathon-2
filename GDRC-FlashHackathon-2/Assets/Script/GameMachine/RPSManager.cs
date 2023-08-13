using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum E_rps{r,p,s};
public class RPSManager : MonoBehaviour
{
    [SerializeField] private int playerScore,mrbreastScore;
    private string[] mrBreastChoose = {"r","p","s"};
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private Image playerImg, mbImg;
    [SerializeField] Sprite r,p,s;


    private void Start() {
        scoreTxt.text = "0 : 0";
    }

    public void Choose(string rps){

        string randChoose = mrBreastChoose[Random.Range (0, mrBreastChoose.Length)];
        switch(rps){
            case "r":
                playerImg.sprite = r;
                if(randChoose == "p"){mrbreastScore++;mbImg.sprite=p;}
                if(randChoose == "s"){playerScore++;mbImg.sprite=s;}
                else{mbImg.sprite=r;}
                break;
            case "p":
                playerImg.sprite = p;
                if(randChoose == "s"){mrbreastScore++;mbImg.sprite=s;}
                if(randChoose == "r"){playerScore++;mbImg.sprite=r;}
                else{mbImg.sprite=p;}
                break;
            case "s":
                playerImg.sprite = s;
                if(randChoose == "r"){mrbreastScore++;mbImg.sprite=r;}
                if(randChoose == "p"){playerScore++;mbImg.sprite=p;}
                else{mbImg.sprite=s;}
                break;
        }

        scoreTxt.text = playerScore.ToString() + " : " + mrbreastScore.ToString();

        if(playerScore == 3){
            //player win.
        }
        if(mrbreastScore== 3){
            //mrBeast win.
        }

    }


}
