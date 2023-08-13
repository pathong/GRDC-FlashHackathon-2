using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public enum E_FriendType{normal, friend, enemy};
public class OtherBehaviour : MonoBehaviour
{
    public string Name;
    public E_FriendType type = E_FriendType.normal;
    [SerializeField] private float rotationSpeed = 1;
    public StatSO statSO;

    public void StartInteract(PlayerInteraction player){
        this.GetComponent<OtherRandomMovement>().enabled = false;
        FaceToPlayer(player.transform);
        type = RandomType();
        DialougeManger.instance.StartFriendDialouge(player, this);
    }

    public void ChangeToEnemy()
    {
        type = E_FriendType.enemy;
        FinishDialouge();
    }

    private void FaceToPlayer(Transform target){
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = targetRotation;
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void FinishDialouge(){

        switch(type){
            case E_FriendType.enemy:
                this.gameObject.GetComponent<EnemyBehaviour>().enabled = true;
                statSO.ChangeType(E_FriendType.enemy);
                break;
            case E_FriendType.friend:
                this.gameObject.GetComponent<FriendBehaviour>().enabled = true;
                statSO.ChangeType(E_FriendType.friend);
                break;
        }
        this.GetComponent<OtherRandomMovement>().enabled = true;
    }
    private E_FriendType RandomType(){
        float rand = Random.Range(-1f,1f);
        return (rand > 0)? E_FriendType.enemy : E_FriendType.friend;

    }


}