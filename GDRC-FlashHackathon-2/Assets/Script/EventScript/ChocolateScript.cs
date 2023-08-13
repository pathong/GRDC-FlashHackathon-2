using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChocolateScript : MonoBehaviour
{

    CollectEventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("EventManager").GetComponent<CollectEventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eventManager.AddScore();
            Destroy(gameObject);
        }
    }
}
