using UnityEngine;
using System.Collections;

public class DungeonManager : MonoBehaviour
{
    static DungeonManager MyManager;
    [SerializeField]
    Animator Ani_Stage;
    [SerializeField]
    DungeonUI MyDungeonUI;


    static StopData CurStopData;

    void Start()
    {
        MyManager = this;
        MyDungeonUI.Init();
        NextStop();
    }
    public void Init()
    {

    }
    public static void NextStop()
    {
        MyManager.PlayMotion("Forward", 0);
        DungeonUI.Forward();
    }
    public static void GetStop()
    {
        CurStopData = new StopData();
        DungeonUI.GetStop(CurStopData);
    }
    public static void GetResult(int _result)
    {
        CurStopData.GetResult(_result);
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
