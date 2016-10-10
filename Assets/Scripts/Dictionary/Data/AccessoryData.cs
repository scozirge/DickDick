using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;

public class AccessoryData : EquipData
{
    public string Name
    {
        get
        {
            if (!GameDictionary.String_AccessoryDic.ContainsKey(ID.ToString()))
            {
                Debug.LogWarning(string.Format("String_Accessory表不包含{0}的文字資料", ID));
                return "NullText";
            }
            return GameDictionary.String_AccessoryDic[ID.ToString()].GetString(Player.UseLanguage);
        }
        private set { return; }
    }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, AccessoryData> _dic, string _dataName)
    {
        DataName = _dataName;
        string jsonStr = Resources.Load<TextAsset>(string.Format("Json/{0}", DataName)).ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd[DataName];
        for (int i = 0; i < items.Count; i++)
        {
            AccessoryData data = new AccessoryData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, data);
        }
    }

    protected AccessoryData(JsonData _item)
        : base(_item)
    {
    }
}
