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
    void Start(){
        go_UI.SetActive(false);
    }
    
    public void ShowClearUI()
    {
        go_UI.SetActive(true);
        //txt_CurrentStage.text = Stage.getCurrentStage();
    }

  
}
