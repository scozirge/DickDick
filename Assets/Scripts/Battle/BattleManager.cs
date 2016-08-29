using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class BattleManager : MonoBehaviour
{
    static BattleManager MyBM;
    static Transform MyTransform;
    [SerializeField]
    BattleUI MyBattleUI;
    [SerializeField]
    RolePanel MyRoleUIPanel;
    public static List<PlayerRoleCom> PRoleList = new List<PlayerRoleCom>();
    public static PlayerRoleCom PCurSelectRole;
    public static int CurPRoleIndex { get; private set; }
    public static RoleCom PTargetRole;
    public static int Round { get; private set; }
    public static bool PlayerPhase { get; private set; }

    void Update()
    {
        TouchDetect();
    }

    public void Init(List<PlayerRole> _playerRoleList)
    {
        MyBM = this;
        MyTransform = transform;
        InitBattleCtrl();
        InitRoleCom(_playerRoleList);
        CurPRoleIndex = 0;
        CurERoleIndex = 0;
        Round = 0;
        PlayerPhase = true;
        PSetCurRole(CurPRoleIndex);
        PSetTargetRole(ERoleList[0]);
        MyBattleUI.Init();

    }
    public static void BattleStart()
    {
        BattleUI.UpdateAccurateUI(PCurSelectRole.Accurate);
    }
    public static void PNextTrun()
    {
        CurPRoleIndex++;
        if (CurPRoleIndex == PRoleList.Count)
        {
            NextSide();
            return;
        }
        else if (CurPRoleIndex > 2)
        {
            CurPRoleIndex = 0;
            Debug.LogWarning(string.Format("CurPRoleIndex超出範圍{0}", CurPRoleIndex));
            return;
        }
        PSetCurRole(CurPRoleIndex);
        if (PTargetRole.IsAlive)
            PSetTargetRole(PTargetRole);
        else
            FindNewTarget();
    }
    public static void NextSide()
    {
        ClearTargetAndSelect();
        if (PlayerPhase)
        {
            PlayerPhase = false;
            MyBM.StartCoroutine(EWaitToAction());
        }
        else
        {
            PlayerPhase = true;
            NextRound();
        }
    }
    static void ResetPlayer()
    {
        for (int i = 0; i < PRoleList.Count; i++)
        {
            PRoleList[i].ResetTurn();
        }
    }
    public static void NextRound()
    {
        Round++;
        CurPRoleIndex = 0;
        PSetCurRole(CurPRoleIndex);
        FindNewTarget();
        ResetPlayer();
    }

    public static void InitRoleCom(List<PlayerRole> _playerRoleList)
    {
        InitSpawner();
        InitEnemyRole();
        SpawnPlayerRole(_playerRoleList);
    }

    public static void PSetCurRole(int _index)
    {
        if (_index >= PRoleList.Count || _index < 0)
        {
            Debug.LogWarning(string.Format("傳入的索引超出範圍:{0}", _index));
            return;
        }
        PCurSelectRole = PRoleList[_index];
        for (int i = 0; i < PRoleList.Count; i++)
        {
            if (PRoleList[i].Index != _index)
                PRoleList[i].SetUnSelected();
            else
            {
                PRoleList[i].SetBeSelected();
            }
        }
    }

    public static void PSetTargetRole(RoleCom _targetRole)
    {
        if (!_targetRole.IsAlive)
            return;
        PTargetRole = _targetRole;
        PCurSelectRole.SetTarget(PTargetRole);
        for (int i = 0; i < ERoleList.Count; i++)
        {
            if (ERoleList[i].Index != _targetRole.Index)
                ERoleList[i].SetUnAim();
            else
            {
                ERoleList[i].SetBeAim();
            }
        }
    }
    public static void ClearTargetAndSelect()
    {
        for (int i = 0; i < ERoleList.Count; i++)
        {
            ERoleList[i].SetUnAim();
            ERoleList[i].SetUnSelected();
        }
        for (int i = 0; i < PRoleList.Count; i++)
        {
            PRoleList[i].SetUnAim();
            PRoleList[i].SetUnSelected();
        }
    }
    public static void FindNewTarget()
    {
        for (int i = 0; i < ERoleList.Count; i++)
        {
            if (ERoleList[i].IsAlive)
            {
                PSetTargetRole(ERoleList[i]);
                break;
            }
        }
    }
    public static void Attack()
    {
        PCurSelectRole.Attack();
    }
    public static void Defend()
    {
        if (PCurSelectRole.Defend() == DefendCondition.Success)
            PNextTrun();
    }
    public static void InitEnemyRole()
    {
        Dictionary<string, string> roleData1 = new Dictionary<string, string>();
        roleData1.Add("Health", "100");
        EnemyRole enemyRole1 = new EnemyRole(roleData1);
        Dictionary<string, string> roleData2 = new Dictionary<string, string>();
        roleData2.Add("Health", "100");
        EnemyRole enemyRole2 = new EnemyRole(roleData2);
        Dictionary<string, string> roleData3 = new Dictionary<string, string>();
        roleData3.Add("Health", "100");
        EnemyRole enemyRole3 = new EnemyRole(roleData3);
        List<EnemyRole> enemyRoleList = new List<EnemyRole>();
        enemyRoleList.Add(enemyRole1);
        enemyRoleList.Add(enemyRole2);
        enemyRoleList.Add(enemyRole3);
        SpawnEnemyRole(enemyRoleList);
    }
}
