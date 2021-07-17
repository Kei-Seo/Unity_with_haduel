using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    // Start is called before the first frame update
    float moveL, moveR;
    [Header("이동속도 조절")]
    private Vector2 touchBeganPos;
    private Vector2 touchEndedPos;
    private Vector2 touchDif;
    private float swipeSensitivity;

    private bool IsJump = false;
    public float jumpForce = 5f;

    private Rigidbody2D rigidbody;

    // Rigidbody2D rigid; 
    // // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // // Update is called once per frame
    void Update()
    {


        Swipe1();
    }

    void FixedUpdate ()
    {
       
        if(IsJump)
        {
            IsJump = false;
            //GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, jumpForce, 0f));
            rigidbody.velocity = Vector2.zero;
            Vector2 JumpVelocity = new Vector2(0, jumpForce);
            rigidbody.AddForce(JumpVelocity, ForceMode2D.Impulse);

        }
    }



    public void Swipe1()
    {
        if (GameManager.CanGameProcess)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);


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
                    //터치.
                    else
                    {
                        IsJump = true;  
                        Debug.Log("touch");
                    }
                }
            }
        }

        //스와이프
    }
}
