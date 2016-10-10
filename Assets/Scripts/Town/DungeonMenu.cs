using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class DungeonMenu : MonoBehaviour
{
    [SerializeField]
    Text Text_StageName;
    [SerializeField]
    ObjectPool GoPool;
    [SerializeField]
    FloorBtn Prefab_Floor;
    [SerializeField]
    Transform Trans_ObjParent;
    int CurStageLevel;
    StageData CurStage;
    List<FloorBtn> FloorBtnList = new List<FloorBtn>();
    [SerializeField]
    TownUI MyTownUI;
    DelegateFnc CallPreparedness; 

    public void Init()
    {
        CurStageLevel = 0;
        CurStage = StageData.GetStageByLevel(CurStageLevel);
        GoPool.InitPool(CurStage.FloorNum, Prefab_Floor.gameObject, Trans_ObjParent);
        CallPreparedness = MyTownUI.CallPreparedness;
        gameObject.SetActive(false);
    }
    public void Next()
    {
        CurStageLevel++;
        if (CurStageLevel >= StageData.StageList.Count)
            CurStageLevel = StageData.StageList.Count - 1;
        CurStage = StageData.GetStageByLevel(CurStageLevel);
        UpdateMenu();
    }
    public void Previous()
    {
        CurStageLevel--;
        if (CurStageLevel < 0)
            CurStageLevel = 0;
        CurStage = StageData.GetStageByLevel(CurStageLevel);
        UpdateMenu();
    }
    public void UpdateMenu()
    {
        Text_StageName.text = CurStage.Name;
        int tmpSize = 0;
        if (FloorBtnList.Count > CurStage.FloorNum)
            tmpSize = FloorBtnList.Count;
        else
            tmpSize = CurStage.FloorNum;
        for (int i = 0; i < tmpSize; i++)
        {
            if (i < FloorBtnList.Count)
            {
                if (i < CurStage.FloorNum)
                {
                    FloorBtnList[i].Show(i + 1);
                }
                else
                {
                    FloorBtnList[i].Hide();
                }
            }
            else
            {
                FloorBtn fb = GoPool.GetOjb().GetComponent<FloorBtn>();
                fb.Init(CallPreparedness);
                fb.Show(i + 1);
                FloorBtnList.Add(fb);
            }
        }
    }
}
