using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectEventManager : MonoBehaviour
{
    public int score, duration;
    public TMP_Text timeText, scoreText;
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        duration = 60;
        StartCoroutine(StartTimer());
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            duration -= 1;
            if(duration <= 0)
            {
                EndEvent();
            }
            UpdateText();
        }
        
    }

    private void GenerateChocolate(int num)
    {

    }

    private void UpdateText()
    {
        scoreText.text = "Score : " + score.ToString();
        timeText.text = "Time : " + duration.ToString();
    }

    private void EndEvent()
    {

    }

    public void AddScore()
    {
        score += 1;
        UpdateText();
    }
}
