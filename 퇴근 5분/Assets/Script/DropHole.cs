using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHole : MonoBehaviour
{
    GameObject player;
    private bool CanJumpPass = false;
    // Start is called before the first frame update
    
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(PMove.Isjump && collision.gameObject == player){
            CanJumpPass = true; //만약 점프를 하고 오브젝트랑 부딪힌다면
        }
        if(collision.gameObject == player && !CanJumpPass){
            //플레이어 태그랑 충돌한다면 Object destroy
            
            GameManager.CanGameProcess = false;//충동하면 진행 false
            Destroy(gameObject);

        }else{
            CanJumpPass = false; 
        }
    }




}
