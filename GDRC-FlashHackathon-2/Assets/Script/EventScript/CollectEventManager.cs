using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectEventManager : MonoBehaviour
{
    public int score, duration;
    public TMP_Text timeText, scoreText;
    public GameObject circle, chocolate;

    private int MIN_CHOCOLATE = 25, numChocolate = 0;

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
            if (numChocolate < MIN_CHOCOLATE)
            {
                GenerateChocolate(1);
            }
            UpdateText();
        }
        
    }

    private void GenerateChocolate(int num)
    {
        float Radius = circle.GetComponent<CircleCollider2D>().radius;
        Radius *= circle.transform.localScale.x;

        for(int i = 0; i < num; i++)
        {
            float x = Random.Range(-Radius, Radius), y = Random.Range(-Radius, Radius);
            while (Mathf.Sqrt(x*x + y*y) >= Radius)
            {
                x = Random.Range(-Radius, Radius);
                y = Random.Range(-Radius, Radius);
            }

            GameObject newChocolate = Instantiate(chocolate);
            newChocolate.transform.position = new Vector3(x, y, 0);
            numChocolate += 1;
        }
        
    }

    private void UpdateText()
    {
        scoreText.text = "Score : " + score.ToString();
        timeText.text = "Time : " + duration.ToString();
    }

    private void EndEvent()
    {
        if (score >= 15) {
            circle.SetActive(false);
            Loader.Load(Loader.Scene.NightScene); 
        }
        else Loader.Load(Loader.Scene.EndScene);
    }

    public void AddScore()
    {
        score += 1;
        UpdateText();
        numChocolate -= 1;
    }
}
