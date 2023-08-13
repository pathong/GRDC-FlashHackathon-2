using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float detectionRange;
    [SerializeField] private float pushForce;
    [SerializeField] private float interval;
    [SerializeField] private Color enemyCol;
    private void OnEnable() {
        player = GameObject.FindGameObjectWithTag("Player");
        this.GetComponent<SpriteRenderer>().color = enemyCol;
        StartCoroutine(push());
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
}
