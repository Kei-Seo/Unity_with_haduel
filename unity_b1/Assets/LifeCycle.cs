using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    //초기화 영역
    void Awake()
    {
        Debug.Log("플레이어 데이터가 준비되었습니다.");
    }

    //활성화 영역
    void OnEnable()
    {
        Debug.Log("플레이어가 로그인 했습니다.")
    }
    
    void Start()
    {
        Debug.Log("사냥 준비를 끝냈습니다.");
    }

    void FixedUpdate()
    {
        Debug.Log("이동~");
    }

    void Update()
    {
        Debug.Log("이동")
    }

    void OnDisable()
    {
        Debug.Log("플레이어가 로그아웃 했습니다.")
    }

    void LateUpdate()
    {
        Debug.Log("경헙치 획득")
    }

    void onDestory()
    {
        Debug.Log("플레이어 데이터를 해체하겠습니다.")
    }

}
