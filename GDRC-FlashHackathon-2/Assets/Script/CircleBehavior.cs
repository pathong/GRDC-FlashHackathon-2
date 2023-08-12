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
        Destroy(collision.gameObject);
        print("Game over. you exit circle!");
    }
/*    void OnTriggerEnter2D(Collider2D collision)
    {
        print("You in contact with ");
    }*/



}
