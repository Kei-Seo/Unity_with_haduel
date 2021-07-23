using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    float moveL, moveR;
    [Header("이동속도 조절")]
    private Vector2 touchBeganPos;
    private Vector2 touchEndedPos;
    private Vector2 touchDif;
    private float TouchTime;
    private float swipeSensitivity;

    public static bool IsSlide = false;
   

    private Rigidbody2D rigidbody;

    public static bool Isjump = false;

    private bool isBtnDown = false;
    // Rigidbody2D rigid; 
    // // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        IsSlide = false;
    }
    // // Update is called once per frame
    void Update()
    {
        
        Swipe1();
    }

    

    public void Swipe1()
    {
        if (GameManager.CanGameProcess && !IsSlide)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                TouchTime = Time.time;

                if (touch.phase == TouchPhase.Began)
                {
                    touchBeganPos = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    touchEndedPos = touch.position;
                    touchDif = (touchEndedPos - touchBeganPos);

                    //스와이프. 터치의 x이동거리나 y이동거리가 민감도보다 크면
                    if (Mathf.Abs(touchDif.y) > swipeSensitivity || Mathf.Abs(touchDif.x) > swipeSensitivity)
                    {
                        if (touchDif.x > 0 && Mathf.Abs(touchDif.y) < Mathf.Abs(touchDif.x))
                        {
                            Vector3 pos = this.transform.position;
                            if (pos.x >= 0.7f)
                            {
                                //이미 오른쪽이면 더 이상 움직일 수 없다.     
                            }
                            else
                            {
                                transform.Translate(1.3f, 0, 0);
                                Debug.Log("right");

                            }

                        }
                        else if (touchDif.x < 0 && Mathf.Abs(touchDif.y) < Mathf.Abs(touchDif.x))
                        {
                            Vector3 pos = this.transform.position;
                            if (pos.x <= -1.3f)
                            {
                                //이미 왼쪽이면 더 이상 움직일 수 없다.     
                            }
                            else
                            {
                                transform.Translate(-1.3f, 0, 0);
                                Debug.Log("left");

                            }
                        }
                    }
                    // else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    // {
                    //     if (Time.time - TouchTime <= 0.5)
                    //     {
                    //         Debug.Log("1");
                    //         //GameManager.isSpeedUp = true;
                    //         Movement2D.moveSpeed = 20;

                    //         //do stuff as a tap​
                    //     }
                    //     else
                    //     {
                    //         Debug.Log("2");

                    //         // this is a long press or drag​
                    //     }
                        
                    // }
                    //터치.
                    else
                    {
                        
                        Debug.Log("touch");
                    }
                }
            }
        }

        //스와이프
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("버튼을 눌렀습니다.");
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("버튼을 똈습니다..");
        isBtnDown = false;
    }
}
