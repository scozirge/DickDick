using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DungeonMapPanel : MonoBehaviour
{
    [SerializeField]
    List<StopCom> StopComList;
    [SerializeField]
    Animator Ani_Map;

    public int CurStopIndex { get; private set; }
    
    public void Init()
    {
        for(int i=0;i<StopComList.Count;i++)
        {
            StopComList[i].SetData(DungeonManager.StopList[i]);
        }
    }

    /// <summary>
    /// 播放腳色施法
    /// </summary>
    void PlayMotion(string _motion, float _normalizedTime)
    {
        switch (_motion)
        {
            case "Stay":
                if (Animator.StringToHash(string.Format("Base Layer.{0}", _motion)) != Ani_Map.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Map.Play(_motion, 0, _normalizedTime);
                break;
            case "Forward":
                if (Animator.StringToHash(string.Format("Base Layer.{0}", _motion)) != Ani_Map.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Map.Play(_motion, 0, _normalizedTime);
                break;
            default:
                break;
        }
    }
    public void Forward()
    {
        PlayMotion("Forward", 0);
    }
    public void GetStop(int _index)
    {
        CurStopIndex = _index;
        for (int i = 0; i < StopComList.Count; i++)
        {
            StopComList[i].SetData(DungeonManager.StopList[CurStopIndex + i]);
        }
    }

}
