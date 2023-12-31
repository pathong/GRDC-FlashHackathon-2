using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName ="Stat",menuName ="ScriptableObject/Stat")]
public class StatSO : ScriptableObject 
{
    public float happiness;
    public int money;
    public int normal;
    public int enemy;
    public int friend;
    public int day;
    public bool isFirstPlay;
    
    public StatSO initialStat;

    [ContextMenu("Initial Stat")]
    public void InitializeStat(){
        happiness= initialStat.happiness;
        money = 0;
        normal = initialStat.normal;
        enemy = 0;
        friend = 0;
        day = 1;
        isFirstPlay = true;
    }

    public void ResetStat()
    {
        happiness = initialStat.happiness;
        money = 0;
        normal = initialStat.normal;
        enemy = 0;
        friend = 0;
    }

    public void ChangeType(E_FriendType type){
        switch (type)
        {
            case E_FriendType.friend:
                friend++;
                break;
            case E_FriendType.enemy:
                enemy++;
                break;
        }
        normal--;
    }
    public void DecrementPlayer(int amount, E_FriendType type){
        switch(type){
            case E_FriendType.normal:
                normal--;
                break;
            case E_FriendType.enemy:
                enemy--;
                break;
            case E_FriendType.friend:
                friend--;
                break;
        }
    }

    public void DecrementPlayer(int amount){
        amount = (int)MathF.Max(amount, friend + enemy + normal);
        for (int i = 0; i < amount; i++)
        {
            int rand = UnityEngine.Random.Range(-1,2);
            switch(rand)
            {
                case 1:
                    if(normal == 0){
                        i--;
                        continue;
                    }
                    normal--;
                    break;
                case 2:
                    if(friend== 0){
                        i--;
                        continue;
                    }
                    friend--;
                    break;
                case 3:
                    if(enemy== 0){
                        i--;
                        continue;
                    }
                    enemy--;
                    break;
            }
        }

    }

    public void ChangeHappiness(float amount){
        happiness+= amount;
        if(happiness > 100){
            happiness =100;
        }
    }




}
