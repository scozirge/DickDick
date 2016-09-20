using UnityEngine;
using System.Collections;

public class DungeonMapPanel : MonoBehaviour
{
    [SerializeField]
    Animator Ani_Map;

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
}
