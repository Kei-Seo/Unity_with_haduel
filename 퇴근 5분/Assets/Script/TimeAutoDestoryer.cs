using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAutoDestoryer : MonoBehaviour
{
    //원숭이 prefeb은 시간이 지나면 제거되도록 설정한 스크립트 입니다.
    // Start is called before the first frame update
    [SerializeField]
    private StageData stageData;
    private float destroyWeight = 2.0f;

    private void Start()
    {
        StartCoroutine("SpawnMonkey");
    }

    private IEnumerator SpawnMonkey()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
        
    }
}
