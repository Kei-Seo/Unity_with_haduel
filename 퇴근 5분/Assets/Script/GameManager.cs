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
    private float RunMeter = 0;
    //ㅁ
    [SerializeField]
    private Text RunMeterText;

    public bool gameProcess; //게임 진행 변수
    // Update is called once per frame
    void Update()
    {
        if (!gameProcess)
        {
             //ProgressBar
            progressBar.maxValue = maxValue; //progressbar max range
            progressBar.value += Time.deltaTime * 5; //progressbar value plus

            //Run meter
            RunMeter += Time.deltaTime * 10;
            RunMeterText.text = (int)RunMeter + "m";
        }
        else
        {
            delayTime();
        }
    }

    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(3);

    }
}
