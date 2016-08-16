using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract partial class RoleCom : MonoBehaviour
{
    protected Role RelyRole { get; set; }
    protected RoleCom Target { get; set; }
    public BattleRoleCondition MyCondition;
    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            if (value < 0)
                value = 0;
            health = value;
        }
    }

    public int MaxHealth;
    public float HealthRatio { get { return (float)Health / (float)MaxHealth; } set { return; } }
    public int Combo { get; set; }
    protected float AccurateDecay { get; set; }
    private float accurate;
    public float Accurate
    {
        get
        {
            accurate = (float)(100 - Combo * AccurateDecay) / 100;
            if (accurate < 0)
                accurate = 0;
            return accurate;
        }
        set { return; }
    }
    public int Index { get; protected set; }

    public virtual void Init(int _index, Role _role)
    {
        RelyRole = _role;
        Health = RelyRole.Health;
        MaxHealth = Health;
        MyCondition = BattleRoleCondition.Alive;
        AccurateDecay = 15;
        Combo = 0;
        Index = _index;
    }

    public void SetTarget(RoleCom _target)
    {
        Target = _target;
    }
    public void ReceiveDmg(int _dmg)
    {
        if (MyCondition == BattleRoleCondition.Death)
            return;
        Health -= _dmg;
        BattleUI.UpdateHealthUI();
        BattleUI.ShowHitText("CriticalHit", _dmg, this);
        PlayMotion("BeHit", 0);
        DeathCheck();
    }
    public void DeathCheck()
    {
        if (Health <= 0)
        {
            MyCondition = BattleRoleCondition.Death;
            PlayMotion("Die", 0);
            BattleManager.FindNewTarget();
        }
    }
    public void Attack()
    {
        if (Target.MyCondition == BattleRoleCondition.Death)
        {
            Debug.LogWarning("嘗試攻擊已死亡的目標");
            return;
        }
        if (ProbabilityGetter.GetResult(Accurate))
        {
            Target.ReceiveDmg(40);
            AddCombo();
        }
        else
            Debug.Log("miss");
    }
    protected void AddCombo()
    {
        Combo++;
        BattleUI.UpdateAccurateUI(Accurate);
    }
}
