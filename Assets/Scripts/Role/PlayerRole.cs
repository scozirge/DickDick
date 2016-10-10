using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerRole : Role
{
    public int Index { get; private set; }
    public override int Health
    {
        get
        {
            return (int)(BaseHealth * (1 + EquipHealthRate) + EquipHealth);
        }
        private set { return; }
    }
    protected int EquipHealth { get; set; }
    protected int EquipHealthRate { get; set; }

    public override int Vitality
    {
        get
        {
            return (int)(BaseVitality * (1 + EquipVitalityRate) + EquipVitality);
        }
        private set { return; }
    }
    protected int EquipVitality { get; set; }
    protected int EquipVitalityRate { get; set; }

    public override int Attack
    {
        get
        {
            return (int)(BaseAttack * (1 + EquipAttackRate) + EquipAttack);
        }
        private set { return; }
    }
    protected int EquipAttack { get; set; }
    protected int EquipAttackRate { get; set; }

    public override int Defense
    {
        get
        {
            return (int)(BaseDefense * (1 + EquipDefenseRate) + EquipDefense);
        }
        private set { return; }
    }
    protected int EquipDefense { get; set; }
    protected int EquipDefenseRate { get; set; }
    public PlayerRole(Dictionary<string, string> _dataDic)
        : base(_dataDic)
    {
        Index = int.Parse(_dataDic["Index"]);
    }
}
