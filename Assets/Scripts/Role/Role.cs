using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class Role
{
    public int Health { get; protected set; }

    public Role(Dictionary<string, string> _dataDic)
    {
        Health = int.Parse(_dataDic["Health"]);
    }
}
