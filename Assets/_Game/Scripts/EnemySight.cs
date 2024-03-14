using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Enemy enemy;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            enemy.SetTagert(collision.GetComponent<Character>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.tag == "Player"){
            enemy.SetTagert(null);
        }
    }
}
