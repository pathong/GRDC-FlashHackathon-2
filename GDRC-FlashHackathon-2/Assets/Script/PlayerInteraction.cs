using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerInput playerinput;
    private InputAction talkInput;
    private InputAction pushInput;

    [SerializeField] private float interactionRange;
    [SerializeField] private float pushForce;


    private void Awake() {
        playerinput = new PlayerInput();

        talkInput = playerinput.Interaction.Talk;
        talkInput.Enable();
        talkInput.performed += TalkHandler;

        pushInput = playerinput.Interaction.Push;
        pushInput.Enable();
        pushInput.performed += PushHandler;
    }

    private void TalkHandler(InputAction.CallbackContext context){
        GameObject other = FindNearest(5);
        if(other != null){
            //interact
            other.GetComponent<OtherBehaviour>().StartInteract(this.gameObject);
            // talkInput.Disable();
        }
    }
    private void PushHandler(InputAction.CallbackContext context){

        GameObject other = FindNearest(5);
        if(other != null){
            Vector2 dir = other.transform.position - this.transform.position;
            other.GetComponent<Rigidbody2D>().AddForce(dir*pushForce);
        }
    }

    private GameObject FindNearest(float range){
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Other");
        GameObject nearestObj = null;

        float closestDistance = Mathf.Infinity;
        foreach (GameObject obj in objectsWithTag)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < closestDistance && distance < range)
            {
                closestDistance = distance;
                nearestObj = obj;
            }
        }

        Debug.Log(nearestObj.name);
        return nearestObj;
    }
}
