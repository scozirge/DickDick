using UnityEngine;
using System.Collections;

public class CtrlPanel : MonoBehaviour
{
    public void OnAttackClick()
    {
        BattleManager.Attack();
    }
}
