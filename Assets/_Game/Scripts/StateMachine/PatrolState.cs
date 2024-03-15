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
        if(enemy.Target!=null){
            //doi huong cua enemy toi player
            enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
            if(enemy.IsTargetInRange()){
                enemy.ChangeState(new AttackState());
            }else{
                enemy.Moving();

            }
            
        }else{
            if(timer < randomTime){
                enemy.Moving();
            }
            else{
                enemy.ChangeState(new IdleState());
            }
        
        }
        
    }

    void IState.OnExit(Enemy enemy)
    {

    }
}
