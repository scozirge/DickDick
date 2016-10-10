using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;

public class WeaponData : EquipData
{
    public string Name
    {
        get
        {
            if (!GameDictionary.String_WeaponDic.ContainsKey(ID.ToString()))
            {
                Debug.LogWarning(string.Format("String_Weapon表不包含{0}的文字資料", ID));
                return "NullText";
            }
            return GameDictionary.String_WeaponDic[ID.ToString()].GetString(Player.UseLanguage);
        }
        private set { return; }
    }
    public string AttackType { get; protected set; }
    public string Type { get; protected set; }
    public int Weight { get; protected set; }
    public float Accurate { get; protected set; }
    public float AccurateDecay { get; protected set; }
    public int Combo { get; protected set; }
    public int ComboSpell { get; protected set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, WeaponData> _dic, string _dataName)
    {
        DataName = _dataName;
        string jsonStr = Resources.Load<TextAsset>(string.Format("Json/{0}", DataName)).ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd[DataName];
        for (int i = 0; i < items.Count; i++)
        {
            WeaponData data = new WeaponData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, data);
        }
    }

    protected WeaponData(JsonData _item)
        : base(_item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "AttackType":
                        AttackType = item[key].ToString();
                        break;
                    case "Type":
                        Type = item[key].ToString();
                        break;
                    case "Weight":
                        Weight = int.Parse(item[key].ToString());
                        break;
                    case "Accurate":
                        Accurate = float.Parse(item[key].ToString());
                        break;
                    case "AccurateDecay":
                        AccurateDecay = float.Parse(item[key].ToString());
                        break;
                    case "Combo":
                        Combo = int.Parse(item[key].ToString());
                        break;
                    case "ComboSpell":
                        ComboSpell = int.Parse(item[key].ToString());
                        break;
                    default:
                        //Debug.LogWarning(string.Format("{0}表有不明屬性:{1}", DataName, key));
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
