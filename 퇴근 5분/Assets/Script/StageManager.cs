using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{

    [SerializeField] Text txt_CurrentStage;
    [SerializeField] GameObject stageClear;
    [SerializeField] GameObject stageFail;
    [SerializeField] GameObject stageNext;


    //[SerializeField] StageData stage;

    // Start is called before the first frame update
    public void ShowNextStageUI()
    {
        stageNext.SetActive(true);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }

    public void ShowNoneNextStageUI()
    {
        Debug.Log("active false");
        stageNext.SetActive(false);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }


    public void ShowFailUI()
    {
        stageFail.SetActive(true);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }

    public void ShowNoneFailUI()
    {
        Debug.Log("active false");
        stageFail.SetActive(false);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }


    public void ShowClearUI()
    {
        stageClear.SetActive(true);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }

    public void ShowNoneClearUI()
    {
        Debug.Log("active false");
        stageClear.SetActive(false);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }

  
}
