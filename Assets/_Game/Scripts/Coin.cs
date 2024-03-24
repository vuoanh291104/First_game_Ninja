using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    int coindem = 0;
    [SerializeField] private Text coinText;
    
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.tag == "Player"){
            
            coindem++;
            Debug.Log( coindem.ToString());
            coinText.text=coindem.ToString();
            this.gameObject.SetActive(false);
            
            
        }
        

    }
    
    
}
