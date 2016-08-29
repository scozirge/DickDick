using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class BattleManager : MonoBehaviour
{
    public static List<EnemyRoleCom> ERoleList = new List<EnemyRoleCom>();
    public static EnemyRoleCom ECurSelectRole;
    public static int CurERoleIndex { get; private set; }
    public static RoleCom ETargetRole;
    static IEnumerator EWaitToAction()
    {
        CurERoleIndex = 0;
        yield return new WaitForSeconds(0.5f);
        EAction();
    }
    static IEnumerator EWaitToAttack()
    {
        yield return new WaitForSeconds(0.5f);
        ECurSelectRole.Attack();
        yield return new WaitForSeconds(0.5f);
        ENextTurn();
    }
    static void ENextTurn()
    {
        CurERoleIndex++;
        ClearTargetAndSelect();
        EAction();
    }
    public static void EAction()
    {
        for (int i = CurERoleIndex; i < ERoleList.Count; i++)
        {
            if (!ERoleList[i].IsAlive)
            {
                CurERoleIndex++;
                ERoleList[i].SetUnSelected();
            }
            else
            {
                ECurSelectRole = ERoleList[i];
                ERoleList[i].SetBeSelected();
                ESetTargetRole();
                MyBM.StartCoroutine(EWaitToAttack());
                return;
            }
        }
        NextSide();
    }
    public static void ESetTargetRole()
    {
        int targetIndex = Random.Range(0, PRoleList.Count);
        ETargetRole = PRoleList[targetIndex];
        ECurSelectRole.SetTarget(ETargetRole);
        for (int i = 0; i < PRoleList.Count; i++)
        {
            if (PRoleList[i].Index != ETargetRole.Index)
                PRoleList[i].SetUnAim();
            else
            {
                PRoleList[i].SetBeAim();
            }
        }
    }
}
