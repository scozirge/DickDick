using UnityEngine;
using System.Collections;

public class EnemyRoleCom : RoleCom
{
    public override float Accurate { get; protected set; }
    public override void Init(int _index, Role _role)
    {
        base.Init(_index, _role);
        Accurate = 1;
    }
}
