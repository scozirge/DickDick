using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public partial class GameDictionary
{
    //關卡字典
    public static Dictionary<string, StringData> String_StageDic;
    public static Dictionary<int, StageData> StageDic;
    //敵人字典
    public static Dictionary<string, StringData> String_EnemyDic;
    public static Dictionary<int, EnemyData> EnemyDic;
    //裝備
    public static Dictionary<int, WeaponData> WeaponDic;
    public static Dictionary<string, StringData> String_WeaponDic;
    public static Dictionary<int, ArmorData> ArmorDic;
    public static Dictionary<string, StringData> String_ArmorDic;
    public static Dictionary<int, AccessoryData> AccessoryDic;
    public static Dictionary<string, StringData> String_AccessoryDic;
    //UI
    public static Dictionary<string, StringData> String_UIDic;

    /// <summary>
    /// 將Json資料寫入字典裡
    /// </summary>
    static void LoadJsonDataToDic()
    {
        StringDataGetter StringGetter = new StringDataGetter();
        //關卡字典
        String_StageDic = StringGetter.GetStringData("String_Stage");
        StageDic = new Dictionary<int, StageData>();
        StageData.SetData(StageDic, "Stage");
        //敵人字典
        String_EnemyDic = StringGetter.GetStringData("String_Enemy");
        EnemyDic = new Dictionary<int, EnemyData>();
        EnemyData.SetData(EnemyDic, "Enemy");
        //裝備字典
        String_WeaponDic = StringGetter.GetStringData("String_Weapon");
        WeaponDic = new Dictionary<int, WeaponData>();
        WeaponData.SetData(WeaponDic, "Weapon");
        String_ArmorDic = StringGetter.GetStringData("String_Armor");
        ArmorDic = new Dictionary<int, ArmorData>();
        ArmorData.SetData(ArmorDic, "Armor");
        String_AccessoryDic = StringGetter.GetStringData("String_Accessory");
        AccessoryDic = new Dictionary<int, AccessoryData>();
        AccessoryData.SetData(AccessoryDic, "Accessory");
        //UI
        String_UIDic = StringGetter.GetStringData("String_UI");

    }
}
