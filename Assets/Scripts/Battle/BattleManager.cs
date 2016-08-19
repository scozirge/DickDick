using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class BattleManager : MonoBehaviour
{
    static Transform MyTransform;
    [SerializeField]
    BattleUI MyBattleUI;
    [SerializeField]
    RolePanel MyRoleUIPanel;
    public static List<PlayerRoleCom> PlayerRoleList = new List<PlayerRoleCom>();
    public static List<EnemyRoleCom> EnemyRoleList = new List<EnemyRoleCom>();
    public static PlayerRoleCom CurSelectRole;
    public static int CurRoleIndex { get; private set; }
    public static RoleCom TargetRole;

    void Update()
    {
        TouchDetect();
    }
    public void Init(List<PlayerRole> _playerRoleList)
    {
        MyTransform = transform;
        InitBattleCtrl();
        InitRoleCom(_playerRoleList);
        CurRoleIndex = 0;
        SetCurRole(CurRoleIndex);
        SetTargetRole(EnemyRoleList[0]);
        MyBattleUI.Init();
    }
    public static void BattleStart()
    {
        BattleUI.UpdateAccurateUI(CurSelectRole.Accurate);
    }
    public static void NextTrun()
    {
        CurRoleIndex++;
        if (CurRoleIndex > 2)
            return;
        SetCurRole(CurRoleIndex);
        if (!TargetRole.IsAlive)
            SetTargetRole(TargetRole);
        else
            FindNewTarget();
    }
    public static void NewRound()
    {

    }

    public static void InitRoleCom(List<PlayerRole> _playerRoleList)
    {
        InitSpawner();
        InitEnemyRole();
        SpawnPlayerRole(_playerRoleList);
    }

    public static void SetCurRole(int _index)
    {
        if (_index >= PlayerRoleList.Count || _index < 0)
        {
            Debug.LogWarning(string.Format("傳入的索引超出範圍:{0}", _index));
            return;
        }
        CurSelectRole = PlayerRoleList[_index];
        for (int i = 0; i < PlayerRoleList.Count; i++)
        {
            if (PlayerRoleList[i].Index != _index)
                PlayerRoleList[i].SetUnSelected();
            else
            {
                PlayerRoleList[i].SetBeSelected();
            }
        }
    }
    public static void SetTargetRole(RoleCom _targetRole)
    {
        if (!_targetRole.IsAlive)
            return;
        TargetRole = _targetRole;
        CurSelectRole.SetTarget(TargetRole);
        for (int i = 0; i < EnemyRoleList.Count; i++)
        {
            if (EnemyRoleList[i].Index != _targetRole.Index)
                EnemyRoleList[i].SetUnAim();
            else
            {
                EnemyRoleList[i].SetBeAim();
            }
        }
    }
    public static void FindNewTarget()
    {
        for (int i = 0; i < EnemyRoleList.Count; i++)
        {
            if (EnemyRoleList[i].IsAlive)
                SetTargetRole(EnemyRoleList[i]);
        }
    }
    public static void Attack()
    {
        CurSelectRole.Attack();
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
