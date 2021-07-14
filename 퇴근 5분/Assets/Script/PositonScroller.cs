using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositonScroller : MonoBehaviour
{
    [SerializeField] private Transform target; //현재 게임에서는 두개의 배결이 서로가 타겟
    [SerializeField] private float moveSpeed = 3.0f;

    [SerializeField] private float scrollRange = 9.9f;
    [SerializeField] private Vector3 moveDirection = Vector3.down;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (GameManager.CanGameProcess)
        {
            //배경이 moveDirection 방향으로 moveSpeed의 속도로 이동
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            //배경이 설정된 범위를 벗어나면 위치를 재설정
            if (transform.position.y <= -scrollRange)
            {
                transform.position = target.position + Vector3.up * scrollRange;
            }
        }
    }
}
