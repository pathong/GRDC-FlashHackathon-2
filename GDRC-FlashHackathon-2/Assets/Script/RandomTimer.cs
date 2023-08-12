using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RandomTimer : MonoBehaviour
{
    [SerializeField] private string TimerName;
    [SerializeField] private float min,max;
    public UnityEvent OnTimerEnd;

    public void Start() => StartCoroutine(StartTimer()); 
        
    

    IEnumerator StartTimer(){
        WaitForSeconds wait = new WaitForSeconds(UnityEngine.Random.Range(min,max));
        yield return wait;
        OnTimerEnd?.Invoke();
    }
}
