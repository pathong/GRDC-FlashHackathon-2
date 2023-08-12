using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OtherRandomMovement : MonoBehaviour
{
    [SerializeField] RandomTimer moveRan;
    [SerializeField] RandomTimer rotateRan;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed; 
    Rigidbody2D rb;
    private void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
    }


    public void OnMoveTimerHandler(){
        rb.AddForce(transform.right*moveSpeed);
    }
    public void OnrotateTimerHandler(){
        rb.AddTorque(Random.Range(-1,1) * rotateSpeed);
    }



}
