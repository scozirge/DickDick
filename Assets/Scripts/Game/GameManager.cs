using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class GameManager : MonoBehaviour
{
    public static Dictionary<int, PlayerRole> RoleDic = new Dictionary<int, PlayerRole>();
    public static List<PlayerRole> RoleList = new List<PlayerRole>();

    void Start()
    {
        InitRole();
        ChangeScene("Dungeon");
        DontDestroyOnLoad(this);
    }
    public static void AddRole(int _id, PlayerRole _role)
    {
        if (_role == null)
        {
            Debug.LogWarning("新增腳色為空");
            return;
        }
        if (RoleDic.ContainsKey(_id))
        {
            Debug.LogWarning(string.Format("嘗試加入重複的腳色ID:{0}", _id));
            return;
        }
        RoleDic.Add(_id, _role);
        RoleList.Add(_role);
    }
    public static void InitRole()
    {
        Dictionary<string, string> roleData1 = new Dictionary<string, string>();
        roleData1.Add("Health", "100");
        roleData1.Add("Vitality", "100");
        PlayerRole role1 = new PlayerRole(roleData1);
        Dictionary<string, string> roleData2 = new Dictionary<string, string>();
        roleData2.Add("Health", "100");
        roleData2.Add("Vitality", "100");
        PlayerRole role2 = new PlayerRole(roleData1);
        Dictionary<string, string> roleData3 = new Dictionary<string, string>();
        roleData3.Add("Health", "100");
        roleData3.Add("Vitality", "100");
        PlayerRole role3 = new PlayerRole(roleData1);
        AddRole(0, role1);
        AddRole(1, role2);
        AddRole(2, role3);
    }
    public void DungeonStart()
    {

    }
}
