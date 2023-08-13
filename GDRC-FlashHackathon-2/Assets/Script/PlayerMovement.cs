using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    public PlayerInput playerinput;

    private InputAction move; 
    private Vector2 moveDir;

    private void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
        playerinput = new PlayerInput();
    }

    private void OnEnable() {
        move = playerinput.Player.Move;
        move.Enable();
    }
    
    private void OnDisable() {
        move.Disable();
    }


    private void Update() {
        moveDir = move.ReadValue<Vector2>();

    }

    private void FixedUpdate() {
        if(moveDir.x != 0){
            var impulse = (-moveDir.x * rotateSpeed * Mathf.Deg2Rad) * rb.inertia;
            rb.AddTorque(impulse); 

        }
        if(moveDir.y != 0){
            rb.AddForce(this.transform.up * moveDir.y * moveSpeed);
        }
        
    }


}
