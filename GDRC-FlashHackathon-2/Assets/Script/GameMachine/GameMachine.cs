using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMachine : MonoBehaviour
{
    
    private RPSManager rps;
    private bool isStart;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject menuObj; 
    [SerializeField] GameObject rpsObj; 
    [SerializeField] GameObject reward; 
    [SerializeField] TMP_Text rewardTxt;
    [SerializeField] GameObject loose; 

    [SerializeField] StatSO statSO;

    private void Start() {
        isStart = false;
    }
    public void ToRPS(){
        menuObj.SetActive(false);
        rpsObj.SetActive(true);
    }
    public void ToMenu(){
        reward.SetActive(false);
        loose.SetActive(false);

        menuObj.SetActive(true);
        panel.SetActive(true);
    }

    public void Open(){
        if(isStart){return;}
        isStart = true;

        menuObj.SetActive(true);
        panel.SetActive(true);
    }

    public void ToReward(){
        int r = Random.Range(10, 1000000);
        statSO.money += r;
        statSO.ChangeHappiness(20);
        rewardTxt.text = rewardTxt.text + " " + r.ToString() + " dollars";

        
        rpsObj.SetActive(false); 
        reward.SetActive(true);
    }
    public void ToLoose(){
       rpsObj.SetActive(false); 
       loose.SetActive(true);
    }

    public void Exit(){
        menuObj.SetActive(false);
        panel.SetActive(false);
        isStart = false;
    }

    public void GameOver(){

    }


    
}
