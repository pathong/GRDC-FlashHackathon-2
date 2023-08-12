using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class OtherBehaviour : MonoBehaviour
{
    public string Name;

    public void StartInteract(GameObject player){
        this.GetComponent<OtherRandomMovement>().enabled = false;
        FaceToPlayer(player.transform);
    }

    private void FaceToPlayer(Transform target){
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

}