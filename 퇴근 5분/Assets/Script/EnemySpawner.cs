using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject enemyPrefeb;
    [SerializeField]
    private float spawnTime;
    private bool onceInvokeSpwan = true; 

    // Start is called before the first frame update
    private void Start()
    {
       StartCoroutine("SpawnEnemy");     
        
    }

    
    
    void Update()
    {
        Debug.Log("once"+onceInvokeSpwan);
        int runOnce = 0;
        if(GameManager.CanGameProcess == true && onceInvokeSpwan == false)
        {
            onceInvokeSpwan = true;
            StartCoroutine("SpawnEnemy");
            Debug.Log("한번실행했는가?");
        }

        if(GameManager.CanGameProcess == false)
        {
            onceInvokeSpwan = false;
        }

    }
    

    // Update is called once per frame
    private IEnumerator SpawnEnemy()
    {
        
        //Debug.Log(IsSpawnerOk);
        while(GameManager.CanGameProcess)
        {

        float positionX = 0;
        int decidePos = Random.Range(0, 3);
            switch(decidePos){
                case 0:
                    positionX = -0.51f;
                    break;
                case 1:
                    positionX = -1.81f;
                    break;
                case 2:
                    positionX = 0.79f;
                    break;

            
            }
        // x 위치는 스테이지의 크기 범위 내에서 임의의 값을 선택
        // 길을 막는 캐릭터를 생성
        Instantiate(enemyPrefeb, new Vector3(positionX, stageData.LimitMax.y+1.0f, 0.0f), Quaternion.identity);
        //spawntime만큼 대기
        yield return new WaitForSeconds(spawnTime);   
        
        }
        
    }
}
