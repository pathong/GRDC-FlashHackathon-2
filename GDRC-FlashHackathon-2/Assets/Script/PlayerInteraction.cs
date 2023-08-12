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


    private void Awake() {
        talkInput = playerinput.Interaction.Talk;
        talkInput.Enable();
        talkInput.performed += TalkHandler;

        pushInput = playerinput.Interaction.Push;
        pushInput.Enable();
    }

    private void TalkHandler(InputAction.CallbackContext context){
        GameObject other = FindNearest(5);
        if(other != null){
            //interact
            other.GetComponent<OtherBehaviour>().StartInteract(this.gameObject);
            talkInput.Disable();
        }
    }
    private void PushHandler(InputAction.CallbackContext context){

    }

    private GameObject FindNearest(float range){
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("other");
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

        return nearestObj;
    }
}
