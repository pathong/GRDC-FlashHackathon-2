using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RunEvent : MonoBehaviour
{
    public GameObject pole, circle, tesla;
    public TMP_Text timeText;
    public int duration;
    // Start is called before the first frame update
    void Start()
    {
        duration = 60;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            duration -= 1;
            if (duration <= 0)
            {
                EndEvent();
            }

            SpawnTesla();
            UpdateText();
        }
    }

    private void SpawnTesla()
    {
        float Radius = circle.GetComponent<CircleCollider2D>().radius;
        Radius *= circle.transform.localScale.x;
        Radius += 3;

        float x = Random.Range(-Radius, Radius);
        float y = Mathf.Sqrt(Radius*Radius - x*x);

        GameObject newTesla = Instantiate(tesla);
        newTesla.transform.position = new Vector3(x, y, 0);
        
        Vector3 dir = newTesla.transform.position - circle.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        newTesla.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Rigidbody2D rb = newTesla.GetComponent<Rigidbody2D>();
        float speed = Random.Range(60f, 100f);
        transform.Rotate(0, 0, Random.Range(-30f, 30f));

        rb.AddForce(-newTesla.transform.right * speed * 10);
    }

    private void UpdateText()
    {
        timeText.text = "Time : " + duration.ToString();
    }

    private void EndEvent()
    {

        Loader.Load(Loader.Scene.NightScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
