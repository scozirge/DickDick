using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class EnemyData
{
    static string DataName;
    public int ID { get; private set; }
    //值業名稱
    public string Name
    {
        get
        {
            if (!GameDictionary.String_EnemyDic.ContainsKey(ID.ToString()))
            {
                Debug.LogWarning(string.Format("String_Enemy表不包含{0}的文字資料", ID));
                return "NullText";
            }
            return GameDictionary.String_EnemyDic[ID.ToString()].GetString(Player.UseLanguage);
        }
        private set { return; }
    }
    public string Type { get; private set; }
    public string Race { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public float Accurate { get; private set; }
    public float AccurateDecay { get; private set; }
    public float DefendProbability { get; private set; }
    public float DefendProbabilityAdd { get; private set; }
    public int Combo { get; private set; }
    public int ComboSpell { get; private set; }
    public int ActivitySpell { get; private set; }
    public int[] Buffers;
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, EnemyData> _dic, string _dataName)
    {
        DataName = _dataName;
        string jsonStr = Resources.Load<TextAsset>(string.Format("Json/{0}", DataName)).ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd[DataName];
        for (int i = 0; i < items.Count; i++)
        {
            EnemyData data = new EnemyData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, data);
        }
    }
    EnemyData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "ID":
                        ID = int.Parse(item[key].ToString());
                        break;
                    case "Type":
                        Type = item[key].ToString();
                        break;
                    case "Race":
                        Race = item[key].ToString();
                        break;
                    case "Health":
                        Health = int.Parse(item[key].ToString());
                        break;
                    case "Attack":
                        Attack = int.Parse(item[key].ToString());
                        break;
                    case "Defense":
                        Defense = int.Parse(item[key].ToString());
                        break;
                    case "Accurate":
                        Accurate = float.Parse(item[key].ToString());
                        break;
                    case "AccurateDecay":
                        AccurateDecay = float.Parse(item[key].ToString());
                        break;
                    case "DefendProbability":
                        DefendProbability = float.Parse(item[key].ToString());
                        break;
                    case "DefendProbabilityAdd":
                        DefendProbabilityAdd = float.Parse(item[key].ToString());
                        break;
                    case "Combo":
                        Combo = int.Parse(item[key].ToString());
                        break;
                    case "ComboSpell":
                        ComboSpell = int.Parse(item[key].ToString());
                        break;
                    case "ActivitySpell":
                        ActivitySpell = int.Parse(item[key].ToString());
                        break;
                    case "Buffer":
                        Buffers = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    default:
                        Debug.LogWarning(string.Format("{0}表有不明屬性:{1}", DataName, key));
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

