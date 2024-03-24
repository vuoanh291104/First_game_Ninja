using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected float hp;
    private string currentAnimName;
    [SerializeField] private Animator anim;
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] protected CombatText combatTextPrefab;
    public bool IsDead => hp<=0;  // => same return

    private void Start(){
        OnInit();
    }

    public virtual void OnInit(){
        hp = 100;
        healthBar.OnInit(100,transform);
    }

    public virtual void OnDespawn(){
        
    }
    protected virtual void OnDeath(){
        ChangeAnim("die");
        Invoke(nameof(OnDespawn),2f);
    }
    
    protected void ChangeAnim(string animName){
            if(currentAnimName != animName){
                anim.ResetTrigger(currentAnimName);
                currentAnimName = animName;
                anim.SetTrigger(currentAnimName);
            }
        }
    public virtual void OnHit(float damage){
        if(!IsDead){
            hp-=damage;
            if(IsDead){
                hp=0;
                OnDeath();
            }
            healthBar.SetNewHp(hp);
            Instantiate(combatTextPrefab,transform.position+ Vector3.up,Quaternion.identity).OnInit(damage);

        }
    }
    

}
