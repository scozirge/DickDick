using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleItem : MonoBehaviour
{
    [SerializeField]
    Text Text_Name;
    [SerializeField]
    Text Text_Lv;
    [SerializeField]
    Image[] Image_Curses;
    [SerializeField]
    Image Image_Icon;
    DelegatePlayerRole CallRoleInfo;
    PlayerRole MyRoleData;

    public void Init(DelegatePlayerRole _call)
    {
        if (_call == null)
        {
            Debug.LogWarning("傳入委託為空");
            return;
        }
        CallRoleInfo = _call;
    }
    public void Show(PlayerRole _role)
    {
        MyRoleData = _role;
        Text_Name.text = MyRoleData.Name;
        Text_Lv.text = MyRoleData.Level.ToString();
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void OnClick()
    {
        if (CallRoleInfo == null)
        {
            Debug.LogWarning("委託為空");
            return;
        }
        CallRoleInfo(MyRoleData);
    }
}
