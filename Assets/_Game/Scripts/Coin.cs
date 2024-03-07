using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            Debug.Log("Coin" + collision.gameObject.name);
            
            this.gameObject.SetActive(false);
            
        }
        

    }
}
