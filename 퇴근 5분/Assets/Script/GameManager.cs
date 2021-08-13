using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    public GameObject m_ready; //게임 ready 이미지
    public GameObject m_start; //게임 go 이미지

    private bool gameStart; //게임 시작 true, 종료 false

    [SerializeField]
    private Slider progressBar; //고양이 회사까지 진행 바
    [SerializeField]
    private float maxValue; //progressbar max value
    // Start is called before the first frame update
    [SerializeField]
    private float minValue; //progressbar max value
    // Start is called before the first frame update
    [SerializeField]
    private float remainTime = 300; // 출근 까지 남은 시간 5분
    //ㅁ
    [SerializeField]
    private Text remainTimeText; 

    [SerializeField]
    private Text stageText;//가운데 상단 현재 몇 스테이지인지 표시
    [SerializeField]
    private Text stageNumber; //클리어시 다음 스테이지 표시

    public static bool CanGameProcess; //게임 진행 변수

    private float minTime;
    private float secTime;

    [SerializeField] StageManager theSM;

    private bool onceInvoke;
    GameObject player;
    Animator animator;


    public bool[] stageClear; //스테이지 클리어:true, 클리어x : false
    public int stageIndex; //현재 스테이지 변수

    // Update is called once per frame

    private IEnumerator ReadyAndStart()
    {
        stageNumber.text = "Stage : 1-"+stageIndex; //현제 스테이지 표시
        enemySpawner.InvokeStage(); //방해물 오브젝트 생성 
        m_ready.SetActive(true); //ready ui 활성화
        yield return new WaitForSeconds(2); //2초간 기다리고 
        m_ready.SetActive(false);
        m_start.SetActive(true); //start ui 활성화
        yield return new WaitForSeconds(2);
        m_start.SetActive(false);
        gameStart = true; //게임 시작 true, 종료 false
        gameBalance(); // 방해물이 내려오는 속도, slider max 조절.
        progressBar.value = 0.944f; 
        progressBar.maxValue = maxValue; //progressbar max range
       
        CanGameProcess = true;
        onceInvoke = true;
        remainTime = 300; //5분, 300초 세팅
        progressBar.value = maxValue;

    }


    // 방해물이 내려오는 속도, slider max 조절.
    // stageIndex에 따라 maxValue와 moveSpeed를 조정
    private void gameBalance()
    {
        switch(stageIndex){
            case 1: 
                maxValue = 9000;
                if (Movement2D.moveSpeed < 7)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
            case 2:
                maxValue = 11000;
                if (Movement2D.moveSpeed < 8)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
            case 3:
                maxValue = 13000;
                if (Movement2D.moveSpeed < 9)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
            case 4:
                maxValue = 15000;
                if (Movement2D.moveSpeed < 10)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
            case 5:
                maxValue = 17000;
                if (Movement2D.moveSpeed < 11)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
            case 6:
                maxValue = 19000;
                if (Movement2D.moveSpeed < 12)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
            case 7:
                maxValue = 21000;
                if (Movement2D.moveSpeed < 13)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
            case 8:
                maxValue = 23000;
                if (Movement2D.moveSpeed < 14)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
            case 9:
                maxValue = 25000;
                if (Movement2D.moveSpeed < 15)
                {
                    Movement2D.moveSpeed += (2*Time.deltaTime);
                }
                break;
        }
    }


    //게임 재시작을 위한 세팅 함수
    private void gameReset()
    {
        StartCoroutine("ReadyAndStart");
        remainTime = 300;
        progressBar.value = 0.944f;

    }

    //NextStage 버튼을 눌렀을때의 이벤트
    public void NextStage()
    {
        CanGameProcess = false;
        if (stageIndex < 10)
        {
            // you don't need to compare a boolean variable to true
            // cloneEnemy Tag인 장애물 제거
            var clones = GameObject.FindGameObjectsWithTag("cloneEnemy");
            foreach (var clone in clones) { Destroy(clone); }
            stageIndex++;
            theSM.ShowNoneNextStageUI();//nextStage ui 비활성화
            gameReset();

        }
        else
        {
            Time.timeScale = 0;
        }


    }
    void Awake()
    {
        stageClear = new bool[10];
        stageIndex = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        

    }

    void Start()
    {

        StartCoroutine("ReadyAndStart");
        
    }


    //시간초과시 게임종료
    private void gameOverBecauseTime()
    {
        if (stageClear[stageIndex]) { }
        else if (remainTime <= 0)
        {
            //게임 종료
            theSM.ShowFailUI(); //게임 종료 UI
            Time.timeScale = 0.0F; //화면을 컴춘다.
            Application.Quit();
        }
    }

    void Update()
    {
        if (gameStart)
        {
             remainTime -= Time.deltaTime * 10; // 출근시간 카운트
                minTime = remainTime / 60; //분
                secTime = remainTime % 60; //초

            //Debug.Log(stageClear[stageIndex]);
            if (CanGameProcess && !stageClear[stageIndex])
            {
                gameBalance();
                gameOverBecauseTime();
                //남은 시간 계산
                onceInvoke = true;
                //ProgressBar
                progressBar.value -= Movement2D.moveSpeed/2;
                //slider의 값에서 -를 해서 슬라이더의 고양이가 오른쪽에서 왼쪽으로 이동하도록 구현
                if (progressBar.value <= minValue && !stageClear[stageIndex])
                {
                    //스테이지를 클리어 했다면
                    gameStart = false; 
                    CanGameProcess = false;
                    stageClear[stageIndex] = true;
                    stageText.text = "1-"+stageIndex;
                    var clones = GameObject.FindGameObjectsWithTag("cloneEnemy");
                    foreach (var clone in clones) { Destroy(clone); }
                    theSM.ShowNextStageUI();
                    
                }
            }
            else if (!stageClear[stageIndex])
            {
                if (onceInvoke)
                {
                    onceInvoke = false;
                    StartCoroutine("delayTime");
                }
            }
        }
    }

    //화면에 표시되는 타이머 GUI
    void OnGUI()
    {
        if (secTime < 0 && minTime < 0)
        {
            remainTimeText.text = "0:00:00";
        }
        else
        {
            string timeStr;
            timeStr = "" + secTime.ToString("00.00");
            timeStr = timeStr.Replace(".", ":");
            remainTimeText.text = (int)minTime + ":" + timeStr;
        }

    }

    //위에서 내려오는 동물과 출돌했다면 1초간 정지시키는 함수    
    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(1);
        //1초가 지났다면 다시 재개를 위해 변수 초기화
        onceInvoke = true; 
        CanGameProcess = true; 
        PMove.IsSlide = false; 
        animator.SetBool("IsBanana", true);

    }
}
