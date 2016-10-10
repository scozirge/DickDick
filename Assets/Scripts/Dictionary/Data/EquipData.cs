using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;

public abstract class EquipData 
{
    public static string DataName { get; protected set; }
    public int ID { get; protected set; }
    public int Rare{get;protected set;}
    public int BufferID{get;protected set;}
    public int HealthWeight{get;protected set;}
    public int AttackWeight{get;protected set;}
    public int DefenseWeight{get;protected set;}
    public int GroupID{get;protected set;}
    public string SpriteName{get;protected set;}


   protected  EquipData(JsonData _item)
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
                    case "Rare":
                        Rare = int.Parse(item[key].ToString());
                        break;
                    case "BufferID":
                        BufferID = int.Parse(item[key].ToString());
                        break;
                    case "HealthWeight":
                        HealthWeight = int.Parse(item[key].ToString());
                        break;
                    case "AttackWeight":
                        AttackWeight = int.Parse(item[key].ToString());
                        break;
                    case "DefenseWeight":
                        DefenseWeight = int.Parse(item[key].ToString());
                        break;
                    case "GroupID":
                        GroupID = int.Parse(item[key].ToString());
                        break;
                    case "SpriteName":
                        SpriteName = item[key].ToString();
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
