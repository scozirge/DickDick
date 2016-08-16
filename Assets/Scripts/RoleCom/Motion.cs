using UnityEngine;
using System.Collections;

public abstract partial class RoleCom
{
    public bool BeSelected { get; protected set; }
    public bool BeAim { get; protected set; }
    [SerializeField]
    GameObject Go_Selected;
    [SerializeField]
    GameObject Go_Aim;
    [SerializeField]
    Animator MyAni;

    public void SetBeSelected()
    {
        BeSelected = true;
        Go_Selected.SetActive(BeSelected);
    }
    public void SetUnSelected()
    {
        BeSelected = false;
        Go_Selected.SetActive(BeSelected);
    }
    public void SetBeAim()
    {
        BeAim = true;
        Go_Aim.SetActive(BeAim);
    }
    public void SetUnAim()
    {
        BeAim = false;
        Go_Aim.SetActive(BeAim);
    }


    /// <summary>
    /// 播放腳色施法
    /// </summary>
    public void PlayMotion(string _motion, float _normalizedTime)
    {
        switch (_motion)
        {
            case "Default":
                if (Animator.StringToHash(string.Format("Base Layer.{0}", _motion)) != MyAni.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    MyAni.Play(_motion, 0, _normalizedTime);
                break;
            case "BeHit":
                if (Animator.StringToHash(string.Format("Base Layer.{0}", _motion)) != MyAni.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    MyAni.Play(_motion, 0, _normalizedTime);
                else
                    MyAni.StopPlayback();//重播
                break;
            case "Die":
                if (Animator.StringToHash(string.Format("Base Layer.{0}", _motion)) != MyAni.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    MyAni.Play(_motion, 0, _normalizedTime);
                break;
            default:
                break;
        }
    }
}
