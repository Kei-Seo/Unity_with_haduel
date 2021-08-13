using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderBanana : MonoBehaviour
{
    [SerializeField]
    //Animator animator;
    GameObject player;
    private EnemySpawner enemySpawner;
    //스턴 이펙트 스폰을 위한 enemySpawner
   
    public bool onceInvoke;
    //한번의 실행을 위해
    void Start()
    {
        onceInvoke = true;
    }
    void Awake(){
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player){
            //플레이어와 바나나가 충돌했다면
            enemySpawner.stunEffect.SetActive(true); //스턴 이펙트 활성화 
            
            //여기부터 스턴 이펙트를 받아서 추가로 넣어주시면 감사하겠습니다.
            //아직 스턴 이펙트가 없어서 이미지로 대체 했습니다.
            //스턴 이펙트는 player 고양이 머리위에 이펙트가 나오게 됩니다.
            Vector3 position = enemySpawner.stunEffect.transform.localPosition;
            position.x = 0;
            position.y = 0; 
            enemySpawner.stunEffect.transform.localPosition = position;
            //여기까지 입니다.
           
            PMove.IsSlide = true; 
            //바나나와 충돌시 양 옆으로 스와이프 할 수 없게 됩니다.
            if(onceInvoke){
                onceInvoke = false;
                StartCoroutine(delayTime());
            }
        }
    }


    /* 바나나와 충돌할 시 0.5동안 스턴이 걸리게 됩니다.
    *  스턴이 걸리면 양 옆으로 움직이지 못합니다.
    *  
    *
    */

    IEnumerator delayTime()
    {
        this.GetComponent<Renderer>().enabled= false;
        yield return new WaitForSeconds(0.5f);
        enemySpawner.stunEffect.SetActive(false);
        PMove.IsSlide = false; //슬라이트 터치 방지 변수
        onceInvoke = true; 

    }

    




}
