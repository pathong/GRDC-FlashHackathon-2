using System.Collections;
using UnityEngine;

public class FriendBehaviour : MonoBehaviour
{
    [SerializeField] private StatSO stat;
    [SerializeField] private float decrement;
    [SerializeField] private float interval;
    [SerializeField] private Color friendCol;
    
    private void OnEnable() {
        this.GetComponent<SpriteRenderer>().color = friendCol;
        StartCoroutine(DecreaseBoring());
    }

    IEnumerator DecreaseBoring(){
        WaitForSeconds wait = new WaitForSeconds(interval);
        while(true){
            stat.Boring -= decrement;
            yield return wait;
        }
    }
}
