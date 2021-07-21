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

    // Start is called before the first frame update
    private void Start()
    {
        throwBanana = false;
        StartCoroutine("SpawnEnemy");
      

    }



    void Update()
    {
        //Debug.Log("once" + onceInvokeSpwan);
        int runOnce = 0;
        if (GameManager.CanGameProcess == true && onceInvokeSpwan == false)
        {
            onceInvokeSpwan = true;
            StartCoroutine("SpawnEnemy");
            StartCoroutine("SpawnMonkey");
        }

        if (GameManager.CanGameProcess == false)
        {
            onceInvokeSpwan = false;
        }

        if(throwBanana){
            throwBanana = false;
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
            Vector3 toVec = new Vector3(positionX, Random.Range(0, 5), 0.0f);
            StartCoroutine(MoveTo(BananaPrefeb, toVec));
        }

    }
    private IEnumerator MoveTo(GameObject gameObject, Vector3 toPos){
        
        Debug.Log(toPos);
        
        float count = 0;
        Vector3 wasPos = gameObject.transform.position;
        Debug.Log(wasPos);
        while(true)
        {
            count += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(wasPos, toPos, count);

            if(count >= 1)
            {
                gameObject.transform.position = toPos;
                break;
            }
            yield return null;
        }
    }



    // private IEnumerator ThrowBanana(){
    //     yield return new WaitForSeconds(1.5f);

    //     // Move projectile to the position of throwing object + add some offset if needed.
    //     Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

    //     // Calculate distance to target
    //     float target_Distance = Vector3.Distance(Projectile.position, Target.position);

    //     // Calculate the velocity needed to throw the object to the target at specified angle.
    //     float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

    //     // Extract the X  Y componenent of the velocity
    //     float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
    //     float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

    //     // Calculate flight time.
    //     float flightDuration = target_Distance / Vx;

    //     // Rotate projectile to face the target.
    //     Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

    //     float elapse_time = 0;

    //     while (elapse_time < flightDuration)
    //     {
    //         Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

    //         elapse_time += Time.deltaTime;

    //         yield return null;
    //     }
    // }

    private IEnumerator SpawnMonkey()
    {
        throwBanana = true;
        
        while (GameManager.CanGameProcess){
            //int tempY = Int(stageData.LimitMax.y);
            int positionY = Random.Range(0, (int)stageData.LimitMax.y);
            Instantiate(MonkeyPrefeb, new Vector3(1.433f, positionY-1f, 0.0f),Quaternion.identity);
            Instantiate(BananaPrefeb, new Vector3(1.433f, positionY-1f, 0.0f),Quaternion.identity);
            yield return new WaitForSeconds(spawnTime+2);

        }
        
        
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemy()
    {

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

        }

    }
}
