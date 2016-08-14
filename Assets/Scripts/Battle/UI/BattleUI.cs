using UnityEngine;
using System.Collections;

public class BattleUI : MonoBehaviour
{
    [SerializeField]
    RolePanel MyRolePanel;
    public void Init()
    {
        MyRolePanel.Init();
    }
}
