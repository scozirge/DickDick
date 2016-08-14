using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract partial class RoleCom : MonoBehaviour
{
    protected Role RelyRole { get; set; }
    protected RoleCom Target { get; set; }
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
    protected int Combo { get; set; }
    protected float AccurateDecay { get; set; }
    protected float Accurate { get { return (float)(100 - Combo * AccurateDecay) / 100; } set { return; } }
    public int Index { get; protected set; }

    public virtual void Init(int _index, Role _role)
    {
        RelyRole = _role;
        Health = RelyRole.Health;
        MaxHealth = Health;
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
        Health -= _dmg;
        RolePanel.UpdateHealthUI();
    }
    public void Attack()
    {
        if (ProbabilityGetter.GetResult(Accurate))
        {
            Target.ReceiveDmg(10);
            AddCombo();
        }
        else
            Debug.Log("miss");
    }
    protected void AddCombo()
    {
        Combo++;
    }
}
