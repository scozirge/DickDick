using UnityEngine;
using System.Collections;

public abstract class Equipment
{
    public int ID { get; protected set; }
    public bool IsEquip { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Weight { get; protected set; }
    public int Attack { get; protected set; }
    public int Defense { get; protected set; }
    public int Health { get; protected set; }
    public int Accurate { get; protected set; }
    public float AccurateDecay { get; protected set; }
    /// <summary>
    /// 初始化裝備，傳入裝備ID
    /// </summary>
    public Equipment(int _equipID)
    {
        ID = _equipID;
    }
    /// <summary>
    /// 裝備此裝備
    /// </summary>
    public virtual bool Equip()
    {
        //不可重複裝備
        if (IsEquip)
        {
            Debug.LogWarning(string.Format("不可重複裝備({0})", Name));
            return false;
        }
        IsEquip = true;
        return true;
    }
    /// <summary>
    /// 脫下此裝備
    /// </summary>
    public virtual bool TakeOff()
    {
        //不可重複裝備
        if (!IsEquip)
        {
            Debug.LogWarning(string.Format("沒穿過此裝備({0})，無法脫下", Name));
            return false;
        }
        IsEquip = false;
        return true;
    }
}
