using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class HitText : MonoBehaviour
{
    [SerializeField]
    Text Text_Value;
    [SerializeField]
    Text Text_Label;
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
        IsWork = false;
    }
    public void Show(string _label, int _value, RoleCom _roleCom)
    {
        MyGameobject.SetActive(true);
        Text_Value.text = _value.ToString();
        Text_Label.text = _label;
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
