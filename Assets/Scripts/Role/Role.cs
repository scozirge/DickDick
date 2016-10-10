using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class Role
{
    public string Name { get; protected set; }
    public virtual int Health
    {
        get
        {
            return (int)(BaseHealth);
        }
        private set { return; }
    }
    protected int BaseHealth {get;set;}

    public virtual int Vitality
    {
        get
        {
            return (int)(BaseVitality );
        }
        private set { return; }
    }
    protected int BaseVitality { get; set; }

    public virtual int Attack
    {
        get
        {
            return (int)(BaseAttack );
        }
        private set { return; }
    }
    protected int BaseAttack { get; set; }

    public virtual int Defense
    {
        get
        {
            return (int)(BaseDefense );
        }
        private set { return; }
    }
    protected int BaseDefense { get; set; }

    public virtual int Weight
    {
        get
        {
            return (int)(BaseWeight);
        }
        private set { return; }
    }
    protected int BaseWeight { get; set; }

    public int Level { get; protected set; }


    public string Race { get; protected set; }
    public int Spell { get; protected set; }
    public List<int> Buffer = new List<int>();
    public string SpriteName { get; protected set; }
    public Role(Dictionary<string, string> _dataDic)
    {
        Name = _dataDic["Name"];
        BaseHealth = int.Parse(_dataDic["Health"]);
        BaseVitality = int.Parse(_dataDic["Vitality"]);
        BaseAttack = int.Parse(_dataDic["Attack"]);
        BaseDefense = int.Parse(_dataDic["Defense"]);
        BaseWeight = int.Parse(_dataDic["Weight"]);
        Level = int.Parse(_dataDic["Level"]);
    }
}
