using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData; 

    [SerializeField]
    public GameObject stunEffect; //stunEffect

    [SerializeField]
    private GameObject enemyPrefeb; //밑에서 내려오는 동물 prefeb
    [SerializeField]
    private GameObject MonkeyPrefeb; //원숭이 prefeb
    [SerializeField]
    private GameObject BananaPrefeb; //바나나 prefeb

    public float spawnTime;
    private bool onceInvokeSpwan = false;
    public static bool throwBanana;


    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;


    private Transform myTransform;

    private GameManager gameMananger;
    private bool IsSpawnEnemy;
    private bool IsSpawnMonkey;

    public bool enableSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
        enableSpawn = true;
        //InvokeRepeating("SpawnAnimal", 4, 1); //4초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
        IsSpawnEnemy = true;
        throwBanana = false;
        IsSpawnMonkey = true;

    }

    IEnumerator ThrowBanana(float positionX, float positionY)
    {
        yield return new WaitForSeconds(1f);
        GameObject enemyBanana= (GameObject)Instantiate(BananaPrefeb, new Vector3(positionX, positionY + 2f, 0.0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
    }

    void SpawnAnimal()
    {
        float positionX = 0;
        //float positionX2 = 0;
        int decideEnemyPos = Random.Range(0, 3);
        switch (decideEnemyPos)
        {
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
        //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        if (GameManager.CanGameProcess)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefeb, new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
        }
    }

    void SpawnBanana()
    {

        float positionY = Random.Range(1, (int)stageData.LimitMax.y);
        float positionX = 0;
        int decideEnemyPos = Random.Range(0, 3);
        switch (decideEnemyPos)
        {
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
        
        //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        if (GameManager.CanGameProcess)
        {
            GameObject enemyMonkey = (GameObject)Instantiate(MonkeyPrefeb, new Vector3(1.3f, positionY + 2f, 0.0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            StartCoroutine(ThrowBanana(positionX, positionY));
        }
    }
    void Awake()
    {
        
        gameMananger = GameObject.Find("GameManager").GetComponent<GameManager>();
        IsSpawnEnemy = true;
        throwBanana = false;
        IsSpawnMonkey = true;

    }


    public void InvokeStage()
    {
        switch (gameMananger.stageIndex)
        {
            case 1:
                InvokeRepeating("SpawnBanana", 8, 2.5f);
                InvokeRepeating("SpawnAnimal", 4, 1f);
                break;
            case 2:
                CancelInvoke("SpawnAnimal");
                CancelInvoke("SpawnBanana");
                InvokeRepeating("SpawnBanana", 8, 2f);
                InvokeRepeating("SpawnAnimal", 4, 0.9f);
                break;
            case 3:
                CancelInvoke("SpawnAnimal");
                CancelInvoke("SpawnBanana");
                InvokeRepeating("SpawnBanana", 8, 1.8f);
                InvokeRepeating("SpawnAnimal", 4, 0.9f);
                break;
            case 4:
                CancelInvoke("SpawnAnimal");
                CancelInvoke("SpawnBanana");
                InvokeRepeating("SpawnBanana", 8, 1.7f);
                InvokeRepeating("SpawnAnimal", 4, 0.8f);
                break;
            case 5:
                CancelInvoke("SpawnAnimal");
                CancelInvoke("SpawnBanana");
                InvokeRepeating("SpawnBanana", 8, 1.6f);
                InvokeRepeating("SpawnAnimal", 4, 0.8f);
                break;
            case 6:
                CancelInvoke("SpawnAnimal");
                CancelInvoke("SpawnBanana");
                InvokeRepeating("SpawnBanana", 8, 1.5f);
                InvokeRepeating("SpawnAnimal", 4, 0.7f);
                break;
            case 7:
                CancelInvoke("SpawnAnimal");
                CancelInvoke("SpawnBanana");
                InvokeRepeating("SpawnBanana", 8, 1.4f);
                InvokeRepeating("SpawnAnimal", 4, 0.7f);
                break;
            case 8:
                CancelInvoke("SpawnAnimal");
                CancelInvoke("SpawnBanana");
                InvokeRepeating("SpawnBanana", 8, 1.3f);
                InvokeRepeating("SpawnAnimal", 4, 0.6f);
                break;
            case 9:
                CancelInvoke("SpawnAnimal");
                CancelInvoke("SpawnBanana");
                InvokeRepeating("SpawnBanana", 8, 1.2f);
                InvokeRepeating("SpawnAnimal", 4, 0.5f);
                break;

        }
    }

    private IEnumerator SpawnMonkey()
    {
        throwBanana = true;

        while (GameManager.CanGameProcess)
        {
            //int tempY = Int(stageData.LimitMax.y);
            int positionY = Random.Range(1, (int)stageData.LimitMax.y);
            Instantiate(MonkeyPrefeb, new Vector3(1.433f, positionY + 2f, 0.0f), Quaternion.identity);
            float positionX = 0;
            int decideEnemyPos = Random.Range(0, 3);
            switch (decideEnemyPos)
            {
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
            //Vector3 toVec = new Vector3(positionX, Random.Range(0, 5), 0.0f);
            Instantiate(BananaPrefeb, new Vector3(positionX, positionY + 2f, 0.0f), Quaternion.identity);
            //StartCoroutine(MoveTo(BananaPrefeb, toVec));
            yield return new WaitForSeconds(spawnTime + 2);
            IsSpawnMonkey = true;

        }


    }

    // Update is called once per frame
    private IEnumerator SpawnEnemy()
    {

        //Debug.Log(IsSpawnEnemy);

        float positionX = 0;
        //float positionX2 = 0;
        int decideEnemyPos = Random.Range(0, 3);
        switch (decideEnemyPos)
        {
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
        Instantiate(enemyPrefeb, new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        IsSpawnEnemy = true;
        onceInvokeSpwan = false;
    }

}

