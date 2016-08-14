using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerRole : Role
{
    public int Vitality { get; protected set; }

    public PlayerRole(Dictionary<string, string> _dataDic)
        : base(_dataDic)
    {
        Vitality = int.Parse(_dataDic["Vitality"]);
    }
}
