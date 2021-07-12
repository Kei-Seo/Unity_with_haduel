using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vecter3 target = new Vector3(8, 1.5f, 0);
    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position,target, 2f);
    }
}
