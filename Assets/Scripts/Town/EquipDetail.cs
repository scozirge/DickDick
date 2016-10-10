using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EquipDetail : MonoBehaviour
{
    [SerializeField]
    Text Text_Name;
    [SerializeField]
    Text Text_Weight;
    [SerializeField]
    Text Text_Description;
    [SerializeField]
    Text Text_ComboSpell;
    [SerializeField]
    Text Text_ComboCount;
    [SerializeField]
    Text Text_ComboDescription;

    public void UpdateInfo(WeaponData _data)
    {
        if (_data == null)
            return;
        Text_Name.text = _data.Name;
        Text_Weight.text = _data.Weight.ToString();
        Text_ComboCount.text = _data.Combo.ToString();
    }
    public void UpdateInfo(ArmorData _data)
    {
        if (_data == null)
            return;
        Text_Name.text = _data.Name;
        Text_Weight.text = _data.Weight.ToString();
    }
    public void UpdateInfo(AccessoryData _data)
    {
        if (_data == null)
            return;
        Text_Name.text = _data.Name;
    }
}
