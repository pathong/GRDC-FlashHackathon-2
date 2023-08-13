using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField] private StatSO statSO;
    public void StartGame()
    {
        statSO.ResetStat();
        Loader.Load(Loader.Scene.DayScenes);
    }
}
