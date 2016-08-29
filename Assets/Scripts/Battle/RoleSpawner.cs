using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class BattleManager : MonoBehaviour
{
    const float PlayerStartPosY = 3.5f;
    const float EnemyStartPosX = 1f;
    const float PlayerStartPosX = 1f;
    const float PosXDist = -1.5f;
    static Transform Trans_PlayerRoleComParent;
    static Transform Trans_EnemyRoleComParent;
    static GameObject Prefab_PlayerRoleCom;
    static GameObject Prefab_EnemyRoleCom;

    public static void InitSpawner()
    {
        Prefab_PlayerRoleCom = Resources.Load<GameObject>("Object/Role/PlayerRole");
        if (Prefab_PlayerRoleCom == null)
        {
            Debug.LogWarning("找不到Object/Role/PlayerRole");
            return;
        }
        Prefab_EnemyRoleCom = Resources.Load<GameObject>("Object/Role/EnemyRole");
        if (Prefab_EnemyRoleCom == null)
        {
            Debug.LogWarning("找不到Object/Role/EnemyRole");
            return;
        }
        Trans_PlayerRoleComParent = MyTransform.FindChild("Player");
        Trans_EnemyRoleComParent = MyTransform.FindChild("Enemy");
    }

    public static void SpawnPlayerRole(List<PlayerRole> _roleList)
    {
        if (_roleList == null)
        {
            Debug.LogWarning("傳入空的玩家腳色清單");
            return;
        }
        if (_roleList.Count > 3)
        {
            Debug.LogWarning(string.Format("要產生的玩家腳色數量超過{0}", _roleList.Count));
            return;
        }
        for (int i = 0; i < _roleList.Count; i++)
        {
            GameObject obj_role = Instantiate(Prefab_PlayerRoleCom, Vector3.zero, Quaternion.identity) as GameObject;
            PlayerRoleCom playerRoleCom = obj_role.GetComponent<PlayerRoleCom>();
            playerRoleCom.Init(i, _roleList[i]);
            obj_role.transform.SetParent(Trans_PlayerRoleComParent);
            obj_role.transform.localScale = Vector3.one;
            obj_role.transform.localPosition = new Vector2(PlayerStartPosX + PosXDist * i, PlayerStartPosY);
            PRoleList.Add(playerRoleCom);
        }
    }
    public static void SpawnEnemyRole(List<EnemyRole> _roleList)
    {

        if (_roleList == null)
        {
            Debug.LogWarning("傳入空的敵方腳色清單");
            return;
        }
        if (_roleList.Count > 3)
        {
            Debug.LogWarning(string.Format("要產生的敵方腳色數量超過{0}", _roleList.Count));
            return;
        }
        for (int i = 0; i < _roleList.Count; i++)
        {
            GameObject obj_role = Instantiate(Prefab_EnemyRoleCom, Vector3.zero, Quaternion.identity) as GameObject;
            EnemyRoleCom enemyRoleCom = obj_role.GetComponent<EnemyRoleCom>();
            enemyRoleCom.Init(i, _roleList[i]);
            obj_role.transform.SetParent(Trans_EnemyRoleComParent);
            obj_role.transform.localScale = Vector3.one;
            obj_role.transform.localPosition = new Vector2(EnemyStartPosX + PosXDist * i, PlayerStartPosY);
            ERoleList.Add(enemyRoleCom);
        }
    }
}
