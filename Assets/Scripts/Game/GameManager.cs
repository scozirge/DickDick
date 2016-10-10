using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class GameManager : MonoBehaviour
{

    public static List<EnemyRole> ERoleList = new List<EnemyRole>();

    void Start()
    {
        GameDictionary.InitDic();
        Player.Init();
        InitEnemyRole();
        ChangeScene("Town");
        DontDestroyOnLoad(this);
    }
    public static void InitEnemyRole()
    {
        Dictionary<string, string> roleData1 = new Dictionary<string, string>();
        roleData1.Add("Name", "A");
        roleData1.Add("Health", "100");
        roleData1.Add("Attack", "50");
        roleData1.Add("Defense", "40");
        roleData1.Add("Vitality", "100");
        roleData1.Add("Level", "100");
        roleData1.Add("Weight", "70");
        EnemyRole enemyRole1 = new EnemyRole(roleData1);
        Dictionary<string, string> roleData2 = new Dictionary<string, string>();
        roleData2.Add("Name", "B");
        roleData2.Add("Health", "100");
        roleData2.Add("Attack", "50");
        roleData2.Add("Defense", "40");
        roleData2.Add("Vitality", "100");
        roleData2.Add("Level", "100");
        roleData2.Add("Weight", "50");
        EnemyRole enemyRole2 = new EnemyRole(roleData2);
        Dictionary<string, string> roleData3 = new Dictionary<string, string>();
        roleData3.Add("Name", "C");
        roleData3.Add("Health", "100");
        roleData3.Add("Attack", "50");
        roleData3.Add("Defense", "40");
        roleData3.Add("Vitality", "100");
        roleData3.Add("Level", "100");
        roleData3.Add("Weight", "30");
        EnemyRole enemyRole3 = new EnemyRole(roleData3);
        ERoleList.Clear();
        ERoleList.Add(enemyRole1);
        ERoleList.Add(enemyRole2);
        ERoleList.Add(enemyRole3);
    }
    public void DungeonStart()
    {

    }
}
