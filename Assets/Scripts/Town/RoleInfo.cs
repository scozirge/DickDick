using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleInfo : MonoBehaviour
{
    [SerializeField]
    Text Text_Title;
    [SerializeField]
    Text Text_Close;
    [SerializeField]
    Text Text_Next;
    [SerializeField]
    Text Text_Previous;


    [SerializeField]
    Text Text_Name;
    [SerializeField]
    Text Text_Lv;
    [SerializeField]
    Text Text_HP;
    [SerializeField]
    Text Text_ATK;
    [SerializeField]
    Text Text_Def;
    [SerializeField]
    Text Text_Weight;
    PlayerRole CurRoleData;
    public int CurRoleIndex { get; private set; }

    public void Init()
    {
        gameObject.SetActive(false);
        Text_Title.text = GameDictionary.String_UIDic["RoleInfo"].GetString(Player.UseLanguage);
        Text_Next.text = GameDictionary.String_UIDic["Next"].GetString(Player.UseLanguage);
        Text_Previous.text = GameDictionary.String_UIDic["Previous"].GetString(Player.UseLanguage);
        Text_Close.text = GameDictionary.String_UIDic["Close"].GetString(Player.UseLanguage);
    }
    public void UpdateInfo(PlayerRole _roleData)
    {
        CurRoleData = _roleData;
        CurRoleIndex = CurRoleData.Index;
        Text_Name.text = string.Format("{0}：{1}", GameDictionary.String_UIDic["Name"].GetString(Player.UseLanguage), CurRoleData.Name);
        Text_Lv.text = string.Format("{0}：{1}", GameDictionary.String_UIDic["Level"].GetString(Player.UseLanguage), CurRoleData.Level);
        Text_HP.text = string.Format("{0}：{1}", GameDictionary.String_UIDic["Health"].GetString(Player.UseLanguage), CurRoleData.Health);
        Text_ATK.text = string.Format("{0}：{1}", GameDictionary.String_UIDic["Attack"].GetString(Player.UseLanguage), CurRoleData.Attack);
        Text_Def.text = string.Format("{0}：{1}", GameDictionary.String_UIDic["Defense"].GetString(Player.UseLanguage), CurRoleData.Defense);
        Text_Weight.text = string.Format("{0}：{1}", GameDictionary.String_UIDic["Weight"].GetString(Player.UseLanguage), CurRoleData.Weight);
    }
    public void Next()
    {
        CurRoleIndex++;
        if (CurRoleIndex >= Player.RoleNum)
            CurRoleIndex = Player.RoleNum - 1;
        CurRoleData = Player.GetRoleByIndex(CurRoleIndex);
        UpdateInfo(CurRoleData);
    }
    public void Previous()
    {
        CurRoleIndex--;
        if (CurRoleIndex < 0)
            CurRoleIndex = 0;
        CurRoleData = Player.GetRoleByIndex(CurRoleIndex);
        UpdateInfo(CurRoleData);
    }
}
