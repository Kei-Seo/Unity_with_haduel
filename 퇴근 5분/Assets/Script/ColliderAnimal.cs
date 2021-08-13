using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAnimal : MonoBehaviour
{
   /* 위에서 내려오는 동물과 충돌했을때 
   *  발생할 수 있는 이벤트
   *  변수 player : 유니티 Player 오브젝트 
   *  변수 animator : 바나나를 밟았을때 애니메이션 
   */
    GameObject player;
    Animator animator;
    private EnemySpawner enemySpawner;
    //스턴 이펙트 스폰을 위한 enemySpawner

    // Start is called before the first frame update
    void Awake(){
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
    }
   /* 
   * player tag와 충돌했을 때 호출되는 함수
   * IsBanana를 false로 변경
   *  
   */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player){
            //플레이어 태그랑 충돌한다면 Object destroy
            animator.SetBool("IsBanana", false);
            SpeedFromZero(); //속도를 줄입니다.
            GameManager.CanGameProcess = false; //충동하면 진행을 멈춥니다.
            
            Destroy(gameObject);//충돌한 동물의 오브젝를 제거합니다.
            

        }
    }


   /* 충돌시 위에서 내려오는 동물의 속도를 줄이는 함수 
   *  위에서 내려오는 동물의 속도인 moveSpeed를 4분의 1로 줄입니다.
   */

    private void SpeedFromZero()
    {
        float tempSpeed = Movement2D.moveSpeed;
        Movement2D.moveSpeed = tempSpeed/4;
        //충돌시 속도 감소
    
    }




}
