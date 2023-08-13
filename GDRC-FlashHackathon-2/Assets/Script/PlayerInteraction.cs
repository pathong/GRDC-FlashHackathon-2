using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerInput playerinput;
    private InputAction talkInput;
    private InputAction pushInput;
    private InputAction MachineInput;

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

        MachineInput = playerinput.Interaction.Machine;
        MachineInput.Enable();
        MachineInput.performed += MachineHandler;

    }
    private void MachineHandler(InputAction.CallbackContext context){
        GameObject machine = GameObject.FindGameObjectWithTag("Machine");
        if(Vector2.Distance(machine.transform.position, this.transform.position) <= 2){
            machine.GetComponent<GameMachine>().Open();
        }
    }

    private void TalkHandler(InputAction.CallbackContext context){
        GameObject other = FindNearest(5);
        if(other != null && other.GetComponent<OtherBehaviour>().type == E_FriendType.normal){
            //interact
            other.GetComponent<OtherBehaviour>().StartInteract(this);
            talkInput.Disable();
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

        return nearestObj;
    }

    public void FinishDialouge(){
        talkInput.Enable();
    }
}
