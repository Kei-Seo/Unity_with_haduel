using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestoryer : MonoBehaviour
{
    // 화면 밖으로 벗어난다면 prefeb을 제거하는 스크립트
    //
    // Start is called before the first frame update
    [SerializeField]
    private StageData stageData;
    private float destroyWeight = 2.0f;

    private void LateUpdate()
    {
        if(transform.position.y < stageData.LimitMin.y - destroyWeight ||
        transform.position.y > stageData.LimitMax.y + destroyWeight ||
        transform.position.x < stageData.LimitMin.x - destroyWeight ||
        transform.position.x > stageData.LimitMax.x + destroyWeight )
        {
            Destroy(gameObject);
        }
           
        
        
    }
}
