using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Diagnostics;

public class DialougeManger : MonoBehaviour
{
    [SerializeField] private GameObject dialouge1;
    [SerializeField] private GameObject dialouge2;
    [SerializeField] private TMP_Text dialouge2Txt;
    [SerializeField] private string friendSpeech, hateSpeech;
    public static DialougeManger instance;
    public OtherBehaviour currentOther;
    private PlayerInteraction playerInteraction;
    private void Awake() {
        if(instance!=null){
            Destroy(this);
        }
        instance = this;
    }

    public void StartFriendDialouge(PlayerInteraction player, OtherBehaviour other) { 
        currentOther = other;
        playerInteraction = player;
        dialouge1.SetActive(true);
    }
    public void D1D2(){
        dialouge1.SetActive(false);
        switch (currentOther.type){
            case E_FriendType.enemy:
                dialouge2Txt.text = hateSpeech;
                break;
            case E_FriendType.friend:
                dialouge2Txt.text = friendSpeech;
                break;
        }
        dialouge2.SetActive(true);
    }
    public void EndD2(){
        dialouge2.SetActive(false);
        currentOther.FinishDialouge();
        playerInteraction.FinishDialouge();
        currentOther = null;
    }
}
