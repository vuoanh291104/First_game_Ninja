using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IState
{
   void OnEnter(Enemy enemy); //bắt đầu vô State
   void OnExecute(Enemy enemy); //Update State
   void OnExit(Enemy enemy); // Thoát khỏi State

    
}
