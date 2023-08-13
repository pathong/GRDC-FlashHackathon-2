using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehavior : MonoBehaviour
{
    [SerializeField] private StatSO stat;

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
            OtherBehaviour other = collision.GetComponent<OtherBehaviour>();
            stat.DecrementPlayer(1,other.type);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            print("Game over. you exit circle!");
        }
        
        
    }

}
