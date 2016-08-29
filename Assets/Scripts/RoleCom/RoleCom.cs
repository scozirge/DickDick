using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract partial class RoleCom : MonoBehaviour
{
    protected Role RelyRole { get; set; }
    protected RoleCom Target { get; set; }
    public bool IsAlive { get; protected set; }
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
    protected float accurate;
    public virtual float Accurate { get; protected set; }
    public int Index { get; protected set; }

    public virtual void Init(int _index, Role _role)
    {
        RelyRole = _role;
        Health = RelyRole.Health;
        MaxHealth = Health;
        IsAlive = true;
        Index = _index;
    }

    public void SetTarget(RoleCom _target)
    {
        Target = _target;
    }
    public void ReceiveDmg(int _dmg)
    {
        if (!IsAlive)
            return;
        Health -= _dmg;
        BattleUI.ShowHitText("CriticalHit", _dmg, this);
        BattleUI.UpdateHealthUI();
        DeathCheck();
    }
    public void DeathCheck()
    {
        if (Health <= 0)
        {
            IsAlive = false;
            PlayMotion("Die", 0);
        }
    }
    public virtual AttackCondition Attack()
    {
        if (Target==null)
        {
            Debug.LogWarning("無攻擊目標");
            return AttackCondition.Error;
        }
        if (!Target.IsAlive)
        {
            Debug.LogWarning("嘗試攻擊已死亡的目標");
            return AttackCondition.WrongTarget;
        }
        if (ProbabilityGetter.GetResult(Accurate))
        {
            Target.PlayMotion("BeHit", 0);
            Target.ReceiveDmg(5);
            return AttackCondition.Success;
        }
        else
        {
            BattleUI.ShowHitText("Miss", Target);
            return AttackCondition.Miss;
        }
    }

}
