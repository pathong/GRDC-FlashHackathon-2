using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class OtherBehaviour : MonoBehaviour
{
    public string Name;
    [SerializeField] private float rotationSpeed = 1;

    public void StartInteract(GameObject player){
        this.GetComponent<OtherRandomMovement>().enabled = false;
        FaceToPlayer(player.transform);

        DialougeManger.instance.StartFriendDialouge(player, this.gameObject);
    }

    private void FaceToPlayer(Transform target){
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = targetRotation;
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}