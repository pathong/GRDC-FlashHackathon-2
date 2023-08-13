using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GeneratePlayer : MonoBehaviour
{
    [SerializeField] private StatSO statSO;
    [SerializeField] private GameObject other;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject friend;
    [SerializeField] private float radius;
    [SerializeField] private Transform origin;

    private NameGenerator nameGenerator;

    private void Awake() {
        nameGenerator = new NameGenerator();
    }

    [ContextMenu("Generate")]
    public void Generate(){
        GenerateEach(statSO.normal,other);
        GenerateEach(statSO.enemy,enemy);
        GenerateEach(statSO.friend,friend);

    }

    public void GenerateEach(int amount,GameObject prefab){

        if(amount == 0){return;}

        for (int i = 0; i < amount; i++)
        {
            Quaternion randomRot = new Quaternion(0,0,UnityEngine.Random.Range(-1f,1f),1);
            GameObject obj = Instantiate(prefab, 
                new Vector3(
                    origin.position.x + UnityEngine.Random.Range(-radius,radius), 
                    origin.position.y + UnityEngine.Random.Range(-radius,radius), 
                    0),
                new Quaternion(0,0,UnityEngine.Random.Range(-1f,1f),1)
            );
            obj.GetComponent<OtherBehaviour>().Name = nameGenerator.GetRandomName();
        }
    }
}
