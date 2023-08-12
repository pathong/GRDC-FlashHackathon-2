using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomTimer : MonoBehaviour
{
    [SerializeField] private float min,max;
    public UnityEvent OnTimerEnd;

    public void StartTimer(){
        StartCoroutine(StartCorou());
    }

    private IEnumerator StartCorou(){
        WaitForSeconds wait = new WaitForSeconds(UnityEngine.Random.Range(min,max));
        yield return wait;

        OnTimerEnd?.Invoke();

    }
}
