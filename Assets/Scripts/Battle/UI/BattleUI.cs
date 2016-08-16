using UnityEngine;
using System.Collections;

public class BattleUI : MonoBehaviour
{
    static RolePanel MyRolePanel;
    static CtrlPanel MyCtrlPanel;
    public void Init()
    {
        MyRolePanel = transform.FindChild("RoleUIPanel").GetComponent<RolePanel>();
        MyRolePanel.Init();
        MyCtrlPanel = transform.FindChild("CtrlUIPanel").GetComponent<CtrlPanel>();
        MyCtrlPanel.Init();
    }
    public static void UpdateHealthUI()
    {
        MyRolePanel.UpdateHealthUI();
    }
    public static void ShowHitText(string _label, int _value, RoleCom _roleCom)
    {
        MyRolePanel.ShowHitText(_label, _value, _roleCom);
    }
    public static void UpdateAccurateUI(float _acculate)
    {
        MyCtrlPanel.UpdateAccurateUI(_acculate);
    }
}
