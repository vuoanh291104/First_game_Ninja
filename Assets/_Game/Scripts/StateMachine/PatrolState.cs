using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PatrolState : IState
{

    float randomTime;
    float timer;
    void IState.OnEnter(Enemy enemy)
    {
        timer =0; 
        randomTime =Random.Range(3f,6f);
    }

    void IState.OnExecute(Enemy enemy)
    { 
        timer += Time.deltaTime;
        if(timer < randomTime){
            enemy.Moving();

        }else{
            enemy.ChangeState(new IdleState());
        }
        
    }

    void IState.OnExit(Enemy enemy)
    {

    }
}
