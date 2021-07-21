using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    public static float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(GameManager.CanGameProcess)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
    
}
