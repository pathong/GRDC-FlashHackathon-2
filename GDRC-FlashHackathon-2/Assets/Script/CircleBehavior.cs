using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shrink(float amount)
    {
        Vector3 localScale = transform.localScale;
        transform.localScale = localScale - new Vector3(amount, amount, 0); 
    }

    public void Expand(float amount)
    {
        Vector3 localScale = transform.localScale;
        transform.localScale = localScale + new Vector3(amount, amount, 0);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Other"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            print("Game over. you exit circle!");
        }
        
        
    }

}
