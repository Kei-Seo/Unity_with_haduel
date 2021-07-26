using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{

    [SerializeField] Text txt_CurrentStage;
    [SerializeField] GameObject go_UI;
    //[SerializeField] StageData stage;

    // Start is called before the first frame update

    public void ShowClearUI()
    {
        go_UI.SetActive(true);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }

    public void ShowNoneClearUI()
    {
        go_UI.SetActive(false);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }

  
}
