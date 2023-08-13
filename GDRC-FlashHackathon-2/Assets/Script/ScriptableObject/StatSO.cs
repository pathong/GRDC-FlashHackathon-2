using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName ="Stat",menuName ="ScriptableObject/Stat")]
public class StatSO : ScriptableObject 
{
    public float Boring;
    public int money;
    public int normal;
    public int enemy;
    public int friend;
    
    public StatSO initialStat;

    public void InitializeStat(){
        Boring = initialStat.Boring;
        money = 0;
        normal = initialStat.normal;
        enemy = 0;
        friend = 0;
    }




}
