using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonManager : MonoBehaviour
{
    static DungeonManager MyManager;
    [SerializeField]
    Animator Ani_Stage;
    [SerializeField]
    DungeonUI MyDungeonUI;
    public static StopData CurStop;
    public static int CurStopIndex;
    public static List<StopData> StopList;
    public static StageData MyStageData;

    void Start()
    {
        if (!GameDictionary.IsInit)
            GameDictionary.InitDic();
        MyManager = this;
        Init(GameDictionary.StageDic[1]);
    }


    public void Init(StageData _sd)
    {
        CurStopIndex = 0;
        MyStageData = _sd;
        CreateDungeon();
        MyDungeonUI.Init();
        NextStop();
    }

    public static void CreateDungeon()
    {
        StopList = MyStageData.GetNewStopList(1);
    }
    public static void NextStop()
    {
        CurStopIndex++;
        CurStop = StopList[CurStopIndex];
        MyManager.PlayMotion("Forward", 0);
        DungeonUI.Forward();
    }
    public static void GetStop()
    {
        DungeonUI.GetStop(CurStopIndex);
    }
    public static void GetResult(int _result)
    {
        CurStop.GetResult(_result);
    }
    /// <summary>
    /// 播放場景動畫
    /// </summary>
    public void PlayMotion(string _motion, float _normalizedTime)
    {
        switch (_motion)
        {
            case "Stay":
                if (Animator.StringToHash(string.Format("Base Layer.{0}", _motion)) != Ani_Stage.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Stage.Play(_motion, 0, _normalizedTime);
                break;
            case "Forward":
                if (Animator.StringToHash(string.Format("Base Layer.{0}", _motion)) != Ani_Stage.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Stage.Play(_motion, 0, _normalizedTime);
                break;
            default:
                break;
        }
    }
}
