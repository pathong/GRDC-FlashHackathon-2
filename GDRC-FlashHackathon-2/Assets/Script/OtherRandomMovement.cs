using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class OtherRandomMovement : MonoBehaviour
{
    [SerializeField] RandomTimer moveRan;
    [SerializeField] RandomTimer rotateRan;
    [SerializeField] UnityEngine.Vector2 moveSpeed;
    [SerializeField] UnityEngine.Vector2 rotateSpeed; 

    [Header("Detector")]
    [SerializeField] float detectTime;
    [SerializeField] Transform detectorOrigin;
    [SerializeField] float detectRange;
    [SerializeField] LayerMask wallLayer;


    Rigidbody2D rb;
    private void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
    }


    public void OnMoveTimerHandler(){
        rb.AddForce(transform.right* UnityEngine.Random.Range(moveSpeed.x, moveSpeed.y));
        moveRan.Start();
    }
    public void OnrotateTimerHandler(){
        rb.AddTorque(UnityEngine.Random.Range(-1,1) * UnityEngine.Random.Range(rotateSpeed.x, rotateSpeed.y) );
        rotateRan.Start();
    }

    IEnumerator Detect(){
        WaitForSeconds wait = new WaitForSeconds(detectTime);
        while(true){
            RaycastHit2D hit = Physics2D.Raycast(detectorOrigin.position, detectorOrigin.right, detectRange, wallLayer);
            yield return wait;
        }
    }



}
