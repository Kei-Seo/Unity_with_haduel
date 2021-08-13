using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
  
    
    private GameManager gameManager; 
   
    public void inVokeNextStage()
    {
        //Debug.Log("여기서 멈췄다.");
        GameObject.Find("GameManager").GetComponent<GameManager>().NextStage();
    }
}
