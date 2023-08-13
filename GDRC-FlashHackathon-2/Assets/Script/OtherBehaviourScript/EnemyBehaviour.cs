using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float detectionRange;
    [SerializeField] private float pushForce;
    [SerializeField] private float interval;
    [SerializeField] private Color enemyCol;

    [SerializeField] private float happinessIncrement;
    [SerializeField] private StatSO stat;
    private void OnEnable() {
        player = GameObject.FindGameObjectWithTag("Player");
        this.GetComponent<SpriteRenderer>().color = enemyCol;
        StartCoroutine(push());
        StartCoroutine(DecreaseBoring());
    }

    IEnumerator push(){
        WaitForSeconds wait = new WaitForSeconds(interval);
        while(true){
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Check if the player is within the detection range
            if (distanceToPlayer <= detectionRange)
            {
                Vector2 dir = player.transform.position - this.transform.position;
                player.GetComponent<Rigidbody2D>().AddForce(dir*pushForce);
            }        

            yield return wait;
        }
    }
    IEnumerator DecreaseBoring(){
        WaitForSeconds wait = new WaitForSeconds(10);
        while(true){
            stat.ChangeHappiness(happinessIncrement);
            yield return wait;
        }
    }
}
