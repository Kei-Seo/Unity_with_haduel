using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAutoDestoryer : MonoBehaviour
{
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
