using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColliderBanana : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    GameObject player;
    // Start is called before the first frame update
    private bool onceInvoke;
   
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
        onceInvoke = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player){
            //플레이어 태그랑 충돌한다면 Object destroy
            animator.SetBool("isBanana", true);
            PMove.IsSlide = true;
            //Debug.Log("banana");
            if(onceInvoke){
                onceInvoke = false;
                StartCoroutine(delayTime());
            }
            
            //GameManager.CanGameProcess = false;//충동하면 진행 false
            //Destroy(gameObject);
            

        }

    }

    IEnumerator delayTime()
    {
        Debug.Log("여기는 타나?");
        this.GetComponent<Renderer>().enabled= false;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("코루틴잘탄다");
        PMove.IsSlide = false;
        animator.SetBool("isBanana", false);
        Debug.Log("코루틴 끝");
        onceInvoke = true;
       
     
    }

    




}
