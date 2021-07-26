using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StageData : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField]
    private Vector2 limitMax;

    int currentStage;
    public int getCurrentStage(){return currentStage;}

    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;
}
