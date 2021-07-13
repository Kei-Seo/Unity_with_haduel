﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            //플레이어 태그랑 충돌한다면 Object destroy
            Destroy(gameObject);
            
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.gameProcess = false;
            

        }
    }


}
