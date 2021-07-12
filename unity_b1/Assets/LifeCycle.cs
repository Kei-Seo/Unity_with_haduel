using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
   void Start()
   {
        Vector3 vec = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),0); //벡터값
        transform.Translate(vec);
        
   }
   
   
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("플레이어가 아무 키를 눌렀습니다.");
        }
        /*if (Input.anyKey)
        {
            Debug.Log("�÷��̾ �ƹ� Ű�� ��� ������ �ֽ��ϴ�.");
        }*/
        if(Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("아이탬을 구매했습니다.");
        }
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            Debug.Log("왼쪽으로 이동중");
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)){
            Debug.Log("오른쪽으로 이동을 멈추었습니다.");
        }

        if(Input.GetMouseButtonDown(0)){
            Debug.Log("미사일 발사");
        }

        if(Input.GetMouseButton(0)){
            Debug.Log("미사일 모으는 중");
        }

        if(Input.GetMouseButtonUp(0)){
            Debug.Log("미사일 발사!!");
        }

        if(Input.GetButtonDown("Jump")){
            Debug.Log("점프!");
        }

        if(Input.GetButton("Jump")){
            Debug.Log("점프 모으는중,,,");
        }

        if(Input.GetButton("Horizontal")){
            Debug.Log("횡 이동중" + Input.GetAxisRaw("Horizontal"));
        }


    }





}
