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
    private GameObject MonkeyPrefeb;
    [SerializeField]
    private GameObject BananaPrefeb;

    public float spawnTime;
    private bool onceInvokeSpwan = true;
    public static bool throwBanana;


    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    public Transform Projectile;
    private Transform myTransform;

    private bool IsSpawnEnemy;
    private bool IsSpawnMonkey;

    // Start is called before the first frame update
    void Start()
    {

        IsSpawnEnemy = true;
        throwBanana = false;
        IsSpawnMonkey = true;
        StartCoroutine("SpawnEnemy");
        StartCoroutine("SpawnMonkey");

    }


    void moveSpeedSpwanManagement()
    {
        if (Movement2D.moveSpeed < 1)
        {
            spawnTime = 2f;
        }
        else if (Movement2D.moveSpeed >= 1 && Movement2D.moveSpeed < 2)
        {
            spawnTime = 1.7f;
        }
        else if (Movement2D.moveSpeed >= 2 && Movement2D.moveSpeed < 3)
        {
            spawnTime = 1.4f;
        }
        else if (Movement2D.moveSpeed >= 3 && Movement2D.moveSpeed < 4)
        {
            spawnTime = 1.1f;
        }
        else if (Movement2D.moveSpeed >= 4 && Movement2D.moveSpeed < 5)
        {
            spawnTime = 0.9f;
        }
        else if (Movement2D.moveSpeed >= 5 && Movement2D.moveSpeed < 6)
        {
            spawnTime = 0.8f;
        }
        else if (Movement2D.moveSpeed >= 6 && Movement2D.moveSpeed < 7)
        {
            spawnTime = 0.7f;
        }
        else if (Movement2D.moveSpeed >= 7 && Movement2D.moveSpeed < 8)
        {
            spawnTime = 0.65f;
        }
        else if (Movement2D.moveSpeed >= 8 && Movement2D.moveSpeed < 9)
        {
            spawnTime = 0.6f;
        }
    }


    void Update()
    {
        moveSpeedSpwanManagement();
        //Debug.Log("once" + onceInvokeSpwan);
        int runOnce = 0;
        if (GameManager.CanGameProcess == true && onceInvokeSpwan == false)
        {
            onceInvokeSpwan = true;
            if (IsSpawnEnemy)
            {
                StartCoroutine("SpawnEnemy");

                if (IsSpawnMonkey)
                {
                    IsSpawnMonkey = false;
                    int decideSpwanMonkey = Random.Range(0, 3);
                    switch (decideSpwanMonkey)
                    {
                        case 0:
                            //StartCoroutine("SpawnMonkey");
                            break;
                        case 1:
                            //StartCoroutine("SpawnMonkey");
                            break;
                        case 2:
                            StartCoroutine("SpawnMonkey");
                            break;
                    }

                }

            }

        }

        if (GameManager.CanGameProcess == false)
        {
            onceInvokeSpwan = false;
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
        IsSpawnEnemy = false;
        //Debug.Log(IsSpawnerOk);
        while (GameManager.CanGameProcess)
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
            Instantiate(enemyPrefeb, new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
            IsSpawnEnemy = true;

        }

    }
}
