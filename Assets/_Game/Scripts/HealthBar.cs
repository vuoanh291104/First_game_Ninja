using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] Image imageFill;
    float hp;
    float maxhp;
    void Update()
    {
        imageFill.fillAmount =Mathf.Lerp(imageFill.fillAmount, hp/maxhp, Time.deltaTime*5f);   
    }
    public void OnInit(float maxhp){
        this.maxhp =maxhp;
        hp=maxhp;
        imageFill.fillAmount=1;
    }
    public void SetNewHp(float hp){
        this.hp = hp;
        // imageFill.fillAmount = hp/maxhp;
    }
}
