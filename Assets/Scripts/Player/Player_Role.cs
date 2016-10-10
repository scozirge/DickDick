using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class Player
{
    public static Dictionary<int, PlayerRole> RoleDic = new Dictionary<int, PlayerRole>();
    public static List<PlayerRole> RoleList = new List<PlayerRole>();
    public static int RoleNum { get; private set; }

    public static void AddRole(int _id, Dictionary<string, string> _roleData)
    {
        if (_roleData == null)
        {
            Debug.LogWarning("新增腳色為空");
            return;
        }
        if (RoleDic.ContainsKey(_id))
        {
            Debug.LogWarning(string.Format("嘗試加入重複的腳色ID:{0}", _id));
            return;
        }
        _roleData.Add("Index", RoleNum.ToString());
        PlayerRole playerRole = new PlayerRole(_roleData);
        RoleDic.Add(_id, playerRole);
        RoleList.Add(playerRole);
        RoleNum++;
    }
    public static PlayerRole GetRoleByIndex(int _index)
    {
        if (_index < 0 || _index >= RoleList.Count)
        {
            Debug.LogWarning(string.Format("傳入的索引超出範圍，索引:{0}", _index));
            return null;
        }
        return RoleList[_index];
    }
    static void InitRole()
    {
        Dictionary<string, string> roleData1 = new Dictionary<string, string>();
        roleData1.Add("Name", "戰士");
        roleData1.Add("Health", "100");
        roleData1.Add("Attack", "80");
        roleData1.Add("Defense", "60");
        roleData1.Add("Vitality", "100");
        roleData1.Add("Level", "5");
        roleData1.Add("Weight", "30");
        Dictionary<string, string> roleData2 = new Dictionary<string, string>();
        roleData2.Add("Name", "騎士");
        roleData2.Add("Health", "100");
        roleData2.Add("Attack", "70");
        roleData2.Add("Defense", "80");
        roleData2.Add("Vitality", "100");
        roleData2.Add("Level", "15");
        roleData2.Add("Weight", "40");
        Dictionary<string, string> roleData3 = new Dictionary<string, string>();
        roleData3.Add("Name", "法師");
        roleData3.Add("Health", "100");
        roleData3.Add("Attack", "100");
        roleData3.Add("Defense", "20");
        roleData3.Add("Vitality", "100");
        roleData3.Add("Level", "8");
        roleData3.Add("Weight", "40");
        AddRole(0, roleData1);
        AddRole(1, roleData2);
        AddRole(2, roleData3);
    }
}
