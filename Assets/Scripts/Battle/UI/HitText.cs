using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class HitText : MonoBehaviour
{
    [SerializeField]
    Text Text_Value;
    GameObject Go_Value;
    [SerializeField]
    Text Text_Label;
    GameObject Go_Label;
    [SerializeField]
    Animator MyAni;
    GameObject MyGameobject;
    RectTransform MyCanvasRect;
    Camera MyCamera;
    public bool IsWork { get; private set; }
    public void Init(RectTransform _canvasRect, Camera _camera)
    {
        MyCanvasRect = _canvasRect;
        MyCamera = _camera;
        MyGameobject = gameObject;
        MyGameobject.transform.localScale = Vector3.one;
        MyGameobject.transform.localPosition = Vector3.zero;
        Go_Value = Text_Value.gameObject;
        Go_Label = Text_Label.gameObject;
        IsWork = false;
    }
    public void Show(params object[] _params)
    {
        try
        {
            if (_params.Length == 3)
            {
                Go_Label.SetActive(true);
                Go_Value.SetActive(true);
                Text_Label.text = _params[0].ToString();
                Text_Value.text = _params[1].ToString();
                SetAni(_params[2] as RoleCom);
            }
            else if (_params.Length == 2)
            {
                if (_params[0] is int)
                {
                    Go_Label.SetActive(false);
                    Text_Value.text = _params[0].ToString();
                }
                else if (_params[0] is string)
                {
                    Go_Value.SetActive(false);
                    Text_Label.text = _params[0].ToString();
                }
                else
                    Debug.LogWarning("HitText傳入參數型態錯誤");
                SetAni(_params[1] as RoleCom);
            }
            else
            {
                Debug.LogWarning("HitText傳入參數數量錯誤");
            }
        }
        catch (Exception _ex)
        {
            Debug.LogWarning("傳入錯誤的參數給HitText.Show");
            Debug.LogWarning(_ex);
        }
    }
    void SetAni(RoleCom _roleCom)
    {
        MyGameobject.SetActive(true);
        UIPosition.UIToWorldPos(MyCanvasRect, MyCamera, _roleCom.transform, GetComponent<RectTransform>(), 0, 150);
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Hit")) != MyAni.GetCurrentAnimatorStateInfo(0).fullPathHash)
            MyAni.Play("Hit", 0, 0);
        IsWork = true;
    }
    public void EndAni()
    {
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Default")) != MyAni.GetCurrentAnimatorStateInfo(0).fullPathHash)
            MyAni.Play("Default", 0, 0);
        MyGameobject.SetActive(false);
        IsWork = false;
    }
}
