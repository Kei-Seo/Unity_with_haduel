using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Slider progressBar; //slider declare
    [SerializeField]
    private float maxValue; //progressbar max value
    // Start is called before the first frame update
    [SerializeField]
    private float remainTime = 300;
    //ㅁ
    [SerializeField]
    private Text remainTimeText;

    public static bool CanGameProcess; //게임 진행 변수

    private float minTime;
    private float secTime;
    // Update is called once per frame
    void Start()
    {
        CanGameProcess = true;
    }
    
    
    void Update()
    {
        remainTime -= Time.deltaTime * 8;
        minTime = remainTime / 60;
        secTime = remainTime % 60;
        Debug.Log(CanGameProcess);
        if (CanGameProcess)
        {
            //ProgressBar
            progressBar.maxValue = maxValue; //progressbar max range
            progressBar.value += Time.deltaTime; //progressbar value plus

            //remain time
        }
        else
        {
            
            Debug.Log("충돌했어여~");
            StartCoroutine("delayTime");
            Debug.Log(CanGameProcess);
            
     
        }
    }

    void OnGUI()
    {
        string timeStr;
        timeStr = "" + secTime.ToString("00.00");
        timeStr = timeStr.Replace(".", ":");
        remainTimeText.text = "Time : " + (int)minTime + ":" + timeStr;
    }


    IEnumerator delayTime()
    {
        Debug.Log("기다릴게여~");
        yield return new WaitForSeconds(3);
        CanGameProcess = true;
        
    }
}
