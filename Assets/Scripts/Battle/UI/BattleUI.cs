using UnityEngine;
using System.Collections;



public class BattleUI : MonoBehaviour
{
    static RolePanel MyRolePanel;
    static CtrlPanel MyCtrlPanel;
    public void Init()
    {
        MyRolePanel = transform.FindChild("RolePanel").GetComponent<RolePanel>();
        MyRolePanel.Init();
        MyCtrlPanel = transform.FindChild("CtrlPanel").GetComponent<CtrlPanel>();
        MyCtrlPanel.Init();
        HideCombo();
    }
    public static void UpdateHealthUI()
    {
        MyRolePanel.UpdateHealthUI();
    }
    public static void ShowHitText(string _label, int _value, RoleCom _roleCom)
    {
        MyRolePanel.ShowHitText(_label, _value, _roleCom);
    }
    public static void ShowHitText(int _value, RoleCom _roleCom)
    {
        MyRolePanel.ShowHitText(_value, _roleCom);
    }
    public static void ShowHitText(string _label, RoleCom _roleCom)
    {
        MyRolePanel.ShowHitText(_label, _roleCom);
    }
    public static void UpdateAccurateUI(float _acculate)
    {
        MyCtrlPanel.UpdateAccurateUI(_acculate);
    }
    public static void ShowCombo(int _combo)
    {
        MyRolePanel.ShowCombo(_combo);
    }
    public static void HideCombo()
    {
        MyRolePanel.HideCombo();
    }
}
