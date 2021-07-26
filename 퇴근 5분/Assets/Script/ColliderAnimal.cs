using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAnimal : MonoBehaviour
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
            //Debug.Log(GameManager.CanGameProcess);
            SpeedFromZero();
            GameManager.CanGameProcess = false;//충동하면 진행 false
            Destroy(gameObject);
            

        }
    }



    private void SpeedFromZero()
    {
        Debug.Log("0에서부터 속도증가");
        float tempSpeed = Movement2D.moveSpeed;
        Movement2D.moveSpeed = tempSpeed/2;
    
    }




}
