using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player){
            //플레이어 태그랑 충돌한다면 Object destroy
        
            GameManager.CanGameProcess = false;//충동하면 진행 false
            Destroy(gameObject);
            

        }
    }




}
