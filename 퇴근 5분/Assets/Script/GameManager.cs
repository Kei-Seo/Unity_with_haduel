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
    
    [SerializeField] StageManager theSM;
    private GameObject gameOverPanel;
    private GameObject clearPanel;
    private bool onceInvoke;
    public static bool isSpeedUp;
    // Update is called once per frame
    void Start()
    {
        gameOverPanel = GameObject.Find("GameOver");
        clearPanel = GameObject.Find("Clear");
        CanGameProcess = true;
        onceInvoke = true;
        progressBar.maxValue = maxValue; //progressbar max range
    }


    void Update()
    {
        if(remainTime <= 0){
            //게임 종료
            gameOverPanel.GetComponent<Image>().enabled = true;
            Time.timeScale = 0.0F;
            Debug.Log("시간이 멈ㅊㄴ다");
            Application.Quit();
        }
        
        //남은 시간 계산
        remainTime -= Time.deltaTime * 8;
        minTime = remainTime / 60; //분
        secTime = remainTime % 60; //초
        //GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        EnemySpawner enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        if(Movement2D.moveSpeed < 9){
            Movement2D.moveSpeed += (Time.deltaTime/5);
        }
        
        

        if (CanGameProcess)
        {
            onceInvoke = true;
            //ProgressBar
            progressBar.value +=  Movement2D.moveSpeed; //progressbar value plus
            if(progressBar.value == maxValue){
                clearPanel.GetComponent<Image>().enabled = true;
                theSM.ShowClearUI();
                Debug.Log("멈춘다.");
                Time.timeScale = 0.0F;
                Application.Quit();
            }
           
            //remain time
        }
        else
        {
            if (onceInvoke)
            {
                onceInvoke = false;
                StartCoroutine("delayTime");
            }

        }
    }

    void OnInvoke()
    {
        progressBar.maxValue = maxValue; //progressbar max range
        progressBar.value += Time.deltaTime; //progressbar value plus

    }

    void OnGUI()
    {
        if(secTime<0 && minTime<0){
        remainTimeText.text = "Time : 0:00:00"; 
        }else{
        string timeStr;
        timeStr = "" + secTime.ToString("00.00");
        timeStr = timeStr.Replace(".", ":");
        remainTimeText.text = "Time : " + (int)minTime + ":" + timeStr;
        }
        
    }


    IEnumerator delayTime()
    {
        
        yield return new WaitForSeconds(1);
        CanGameProcess = true;
     
    }
}
