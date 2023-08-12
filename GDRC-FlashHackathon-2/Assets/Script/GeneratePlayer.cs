using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GeneratePlayer : MonoBehaviour
{
    [SerializeField] private GameObject other;
    [SerializeField] private float radius;
    [SerializeField] private Transform origin;
    [SerializeField] private int amount;

    [ContextMenu("Generate")]
    public void Generate(){
        for (int i = 0; i < amount; i++)
        {
            Instantiate(other, 
                new Vector3(origin.position.x + UnityEngine.Random.Range(-radius,radius), origin.position.y + UnityEngine.Random.Range(-radius,radius), 0), 
                quaternion.identity
            );
        }

    }
}
