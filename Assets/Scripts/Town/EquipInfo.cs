using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EquipInfo : MonoBehaviour
{
    [SerializeField]
    Text Text_Title;
    [SerializeField]
    Text Text_Close;
    [SerializeField]
    EquipDetail OldEquip;
    [SerializeField]
    EquipDetail NewEquip;

    public void Init()
    {
        gameObject.SetActive(false);
        Text_Title.text = GameDictionary.String_UIDic["RoleInfo"].GetString(Player.UseLanguage);
        Text_Close.text = GameDictionary.String_UIDic["Close"].GetString(Player.UseLanguage);
    }
    public void UpdateInfo(WeaponData _oldEquip, WeaponData _newEquip)
    {
        if (_oldEquip == null)
        {
            Debug.LogWarning("_oldEquip不可為空");
            return;
        }
        OldEquip.UpdateInfo(_oldEquip);
        NewEquip.UpdateInfo(_newEquip);
    }
    public void UpdateInfo(ArmorData _oldEquip, ArmorData _newEquip)
    {
        if (_oldEquip == null)
        {
            Debug.LogWarning("_oldEquip不可為空");
            return;
        }
        OldEquip.UpdateInfo(_oldEquip);
        NewEquip.UpdateInfo(_newEquip);
    }
    public void UpdateInfo(AccessoryData _oldEquip, AccessoryData _newEquip)
    {
        if (_oldEquip == null)
        {
            Debug.LogWarning("_oldEquip不可為空");
            return;
        }
        OldEquip.UpdateInfo(_oldEquip);
        NewEquip.UpdateInfo(_newEquip);
    }
}
