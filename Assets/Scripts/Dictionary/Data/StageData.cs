using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class StageData
{
    static string DataName;
    public int ID { get; private set; }
    //值業名稱
    public string Name
    {
        get
        {
            if (!GameDictionary.String_StageDic.ContainsKey(ID.ToString()))
            {
                Debug.LogWarning(string.Format("String_Stage表不包含{0}的文字資料", ID));
                return "NullText";
            }
            return GameDictionary.String_StageDic[ID.ToString()].GetString(Player.UseLanguage);
        }
        private set { return; }
    }
    public int Difficult { get; private set; }
    public int FloorNum { get; private set; }
    public int StopNum { get; private set; }
    public int MinCampInterval { get; private set; }
    public int MaxCampInterval { get; private set; }
    public int Enemy { get; private set; }
    public int Rescue { get; private set; }
    public int TreasureGuard { get; private set; }
    public int TrapTreasure { get; private set; }
    public int Trap { get; private set; }
    public int LightAltar { get; private set; }
    public int ReviveAltar { get; private set; }
    public int Robber { get; private set; }
    public int[] Boss;
    public int[] Minions;
    public string SpriteName { get; private set; }
    private List<int> WeightList = new List<int>();
    public static Dictionary<int, string> TypeDic = new Dictionary<int, string>();
    public static List<StageData> StageList = new List<StageData>();
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, StageData> _dic, string _dataName)
    {
        DataName = _dataName;
        string jsonStr = Resources.Load<TextAsset>(string.Format("Json/{0}", DataName)).ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd[DataName];
        for (int i = 0; i < items.Count; i++)
        {
            StageData data = new StageData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, data);
            StageList.Add(data);
        }
        TypeDic.Add(0, "Enemy");
        TypeDic.Add(1, "Rescue");
        TypeDic.Add(2, "Treasure");
        TypeDic.Add(3, "TrapTreasure");
        TypeDic.Add(4, "PhysicsTrap");
        TypeDic.Add(5, "MagicTrap");
        TypeDic.Add(6, "LightAltar");
        TypeDic.Add(7, "ReviveAltar");
        TypeDic.Add(8, "Robber");
    }
    StageData(JsonData _item)
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
                    case "Difficult":
                        Difficult = int.Parse(item[key].ToString());
                        break;
                    case "StopNum":
                        StopNum = int.Parse(item[key].ToString());
                        break;
                    case "FloorNum":
                        FloorNum = int.Parse(item[key].ToString());
                        break;
                    case "CampInterval":
                        int[] values = TextManager.StringSplitToIntArray(item[key].ToString(), ':');
                        MinCampInterval = values[0];
                        MaxCampInterval = values[1];
                        break;
                    case "Enemy":
                        Enemy = int.Parse(item[key].ToString());
                        WeightList.Add(Enemy);
                        break;
                    case "Rescue":
                        Rescue = int.Parse(item[key].ToString());
                        WeightList.Add(Rescue);
                        break;
                    case "TreasureGuard":
                        TreasureGuard = int.Parse(item[key].ToString());
                        WeightList.Add(TreasureGuard);
                        break;
                    case "TrapTreasure":
                        TrapTreasure = int.Parse(item[key].ToString());
                        WeightList.Add(TrapTreasure);
                        break;
                    case "Trap":
                        Trap = int.Parse(item[key].ToString());
                        WeightList.Add(Trap);
                        break;
                    case "LightAltar":
                        LightAltar = int.Parse(item[key].ToString());
                        WeightList.Add(LightAltar);
                        break;
                    case "ReviveAltar":
                        ReviveAltar = int.Parse(item[key].ToString());
                        WeightList.Add(ReviveAltar);
                        break;
                    case "Robber":
                        Robber = int.Parse(item[key].ToString());
                        WeightList.Add(Robber);
                        break;
                    case "Boss":
                        Boss = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    case "Minion":
                        Minions = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    case "SpriteName":
                        SpriteName = item[key].ToString();
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
    public List<StopData> GetNewStopList(int _lv)
    {
        List<StopData> sdList = new List<StopData>();
        sdList.Add(new StopData("Home", _lv));
        int nextExit = UnityEngine.Random.Range(MinCampInterval, MaxCampInterval + 1);
        for (int curStop = 0; curStop < StopNum; curStop++)
        {
            if (curStop == StopNum - 1)
            {
                sdList.Add(new StopData("Exit", _lv));
                break;
            }
            if (curStop > nextExit)
                nextExit = UnityEngine.Random.Range(MinCampInterval, MaxCampInterval + 1) + curStop;
            if (curStop != nextExit)
            {
                string type = TypeDic[ProbabilityGetter.GetFromWeigth(WeightList)];
                sdList.Add(new StopData(type, _lv));
            }
            else
            {
                sdList.Add(new StopData("Camp", _lv));
            }
        }
        return sdList;
    }
    public static StageData GetStageByID(int _id)
    {
        if (!GameDictionary.StageDic.ContainsKey(_id))
        {
            Debug.LogWarning(string.Format("不存在ID為{0}的StageData", _id));
            return null;
        }
        else
        {
            return GameDictionary.StageDic[_id];
        }
    }
    public static StageData GetStageByLevel(int _level)
    {
        if (_level < 0 )
        {
            return StageList[0];
        }
        else if(_level>=StageList.Count)
        {
            return StageList[StageList.Count - 1];
        }
        else
        {
            return StageList[_level];
        }
    }
}

