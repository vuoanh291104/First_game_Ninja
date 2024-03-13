using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float hp;
    private bool IsDeath => hp<=0;  // => same return
    private string currentAnimName;
    [SerializeField] private Animator anim;
    

    public virtual void OnInit(){

    }
    public virtual void OnDespawn(){

    }
    public void ChangeAnim(string animName){
            if(currentAnimName != animName){
                anim.ResetTrigger(currentAnimName);
                currentAnimName = animName;
                anim.SetTrigger(currentAnimName);
            }
        }
    public void OnHit(float damage){
        if(!IsDeath){
            hp-=damage;
            if(IsDeath){
                OnDeath();
            }
        }
    }
    private void OnDeath(){

    }

}
