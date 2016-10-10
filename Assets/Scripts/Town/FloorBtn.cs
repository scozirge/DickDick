using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FloorBtn : MonoBehaviour
{
    [SerializeField]
    Text Text_Name;
    DelegateFnc CallPreparedness;

    public void Init(DelegateFnc _call)
    {
        if (_call == null)
        {
            Debug.LogWarning("傳入委託為空");
            return;
        }
        CallPreparedness = _call;
    }
    public void Show(int _floor)
    {
        Text_Name.text = string.Format("第{0}層樓", _floor);
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void OnClick()
    {
        if (CallPreparedness == null)
        {
            Debug.LogWarning("委託為空");
            return;
        }
        CallPreparedness();
    }
}
