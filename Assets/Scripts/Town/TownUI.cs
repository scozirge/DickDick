using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TownUI : MonoBehaviour
{
    [SerializeField]
    Text Text_Money;
    [SerializeField]
    Text Text_Honor;
    [SerializeField]
    DungeonMenu MyDungeonMenu;
    GameObject Go_DungeonMenu;
    [SerializeField]
    Preparedness MyPreparedness;
    GameObject Go_Preparedness;
    [SerializeField]
    RoleMenu MyRoleMenu;
    GameObject Go_RoleMenu;
    [SerializeField]
    RoleInfo MyRoleInfo;
    GameObject Go_RoleInfo;
    [SerializeField]
    EquipInfo MyEquipInfo;
    GameObject Go_EquipInfo;

    public void Start()
    {
        Go_DungeonMenu = MyDungeonMenu.gameObject;
        Go_Preparedness = MyPreparedness.gameObject;
        Go_RoleMenu = MyRoleMenu.gameObject;
        Go_RoleInfo = MyRoleInfo.gameObject;
        Go_EquipInfo = MyEquipInfo.gameObject;
        MyDungeonMenu.Init();
        MyPreparedness.Init();
        MyRoleMenu.Init();
        MyRoleInfo.Init();
        MyEquipInfo.Init();
    }

    public void DungeonOnClick()
    {
        Go_DungeonMenu.SetActive(true);
        MyDungeonMenu.UpdateMenu();
    }
    public void DungeonClose()
    {
        Go_DungeonMenu.SetActive(false);
    }
    public void CallPreparedness()
    {
        Go_Preparedness.SetActive(true);
    }
    public void PreparednessClose()
    {
        Go_DungeonMenu.SetActive(true);
        MyDungeonMenu.UpdateMenu();
        Go_Preparedness.SetActive(false);
    }
    public void InnOnClick()
    {
        Go_RoleMenu.SetActive(true);
        MyRoleMenu.UpdateMenu();
    }
    public void RoleMenuClose()
    {
        Go_RoleMenu.SetActive(false);
    }
    public void CallRoleInfo(PlayerRole _roleData)
    {
        Go_RoleInfo.SetActive(true);
        MyRoleInfo.UpdateInfo(_roleData);
        Go_RoleMenu.SetActive(false);

    }
    public void RoleInfoClose()
    {
        Go_RoleMenu.SetActive(true);
        Go_RoleInfo.SetActive(false);
    }
    public void WeaponBtnOnClick()
    {
        Go_EquipInfo.SetActive(true);
        MyEquipInfo.UpdateInfo(GameDictionary.WeaponDic[1], null);
        Go_RoleInfo.SetActive(false);
    }
    public void ArmorBtnOnClick()
    {
        Go_EquipInfo.SetActive(true);
        MyEquipInfo.UpdateInfo(GameDictionary.ArmorDic[1], null);
        Go_RoleInfo.SetActive(false);
    }
    public void AccessoryBtnOnClick()
    {
        Go_EquipInfo.SetActive(true);
        MyEquipInfo.UpdateInfo(GameDictionary.AccessoryDic[1], null);
        Go_RoleInfo.SetActive(false);
    }
    public void EquipInfoClose()
    {
        Go_EquipInfo.SetActive(false);
        Go_RoleInfo.SetActive(true);
    }
    
}
