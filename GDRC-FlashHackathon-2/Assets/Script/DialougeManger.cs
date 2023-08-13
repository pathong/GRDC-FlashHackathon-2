using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DialougeManger : MonoBehaviour
{
    [SerializeField] private GameObject dialouge1;
    [SerializeField] private GameObject dialouge2;
    [SerializeField] private TMP_Text dialouge2Txt;
    [SerializeField] private string friendSpeech, hateSpeech;
    public static DialougeManger instance;
    private void Awake() {
        if(instance!=null){
            Destroy(this);
        }
        instance = this;
    }

    public void StartFriendDialouge(GameObject player, GameObject other){
        dialouge1.SetActive(true);
    }
    public void D1D2(){
        dialouge1.SetActive(false);
        float rand = Random.Range(-1f,1f);
        dialouge2Txt.text = (rand > 0) ? friendSpeech : hateSpeech; 
        dialouge2.SetActive(true);
    }
    public void EndD2(){
        dialouge2.SetActive(false);
    }
}
