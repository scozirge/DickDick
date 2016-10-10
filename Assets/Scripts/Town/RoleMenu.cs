using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class RoleMenu : MonoBehaviour
{
    [SerializeField]
    Text Text_Title;
    [SerializeField]
    ObjectPool GoPool;
    [SerializeField]
    RoleItem Prefab_RoleItem;
    [SerializeField]
    Transform Trans_ObjParent;
    List<RoleItem> RoleItemList = new List<RoleItem>();
    [SerializeField]
    TownUI MyTownUI;
    DelegatePlayerRole CallRoleInfo;


    public void Init()
    {
        GoPool.InitPool(10, Prefab_RoleItem.gameObject, Trans_ObjParent);
        CallRoleInfo = MyTownUI.CallRoleInfo;
        gameObject.SetActive(false);
    }
    public void UpdateMenu()
    {
        int tmpSize = 0;
        if (RoleItemList.Count > Player.RoleNum)
            tmpSize = RoleItemList.Count;
        else
            tmpSize = Player.RoleNum;
        for (int i = 0; i < tmpSize; i++)
        {
            if (i < RoleItemList.Count)
            {
                if (i < Player.RoleNum)
                {
                    RoleItemList[i].Show(Player.GetRoleByIndex(i));
                }
                else
                {
                    RoleItemList[i].Hide();
                }
            }
            else
            {
                RoleItem ri = GoPool.GetOjb().GetComponent<RoleItem>();
                ri.Init(CallRoleInfo);
                ri.Show(Player.GetRoleByIndex(i));
                RoleItemList.Add(ri);
            }
        }
    }
}
