using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HappinessUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text txt;
    [SerializeField] private TMP_Text moneyTxt;
    [SerializeField] private StatSO statSO;

    private void Update() {
        slider.value = statSO.happiness/100;
        txt.text = ((int)statSO.happiness).ToString();
        moneyTxt.text = statSO.money.ToString() + " dollars";
    }
}
