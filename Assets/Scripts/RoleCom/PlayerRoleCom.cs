using UnityEngine;
using System.Collections;

public class PlayerRoleCom : RoleCom
{
    public int Combo { get; set; }
    protected float AccurateDecay { get; set; }
    public bool IsEndTurn { get; protected set; }
    public override float Accurate
    {
        get
        {
            accurate = (float)(100 - Combo * AccurateDecay) / 100;
            if (accurate < 0)
                accurate = 0;
            return accurate;
        }
        protected set { return; }
    }
    public override void Init(int _index, Role _role)
    {
        base.Init(_index, _role);
        AccurateDecay = 15;
        Combo = 0;
        IsEndTurn = false;
    }
    public void Defend()
    {
        ResetCombo();
    }
    public override AttackCondition Attack()
    {
        if (IsEndTurn)
            return AttackCondition.Error;
        switch (base.Attack())
        {
            case AttackCondition.Success:
                if (!Target.IsAlive)
                    BattleManager.FindNewTarget();
                AddCombo();
                return AttackCondition.Success;
            case AttackCondition.WrongTarget:
                return AttackCondition.WrongTarget;
            case AttackCondition.Miss:
                ResetCombo();
                BattleManager.NextTrun();
                IsEndTurn = true;
                return AttackCondition.Miss;
            default:
                return AttackCondition.Error;
        }
    }
    protected void AddCombo()
    {
        Combo++;
        BattleUI.UpdateAccurateUI(Accurate);
        BattleUI.ShowCombo(Combo);
    }
    protected void ResetCombo()
    {
        Combo = 0;
        BattleUI.HideCombo();
    }
}
