using UnityEngine;
using System.Collections;

public abstract partial class RoleCom
{
    public bool BeSelected { get; protected set; }
    public bool BeAim { get; protected set; }
    [SerializeField]
    GameObject Go_Selected;
    [SerializeField]
    GameObject Go_Aim;
    public void SetBeSelected()
    {
        BeSelected = true;
        Go_Selected.SetActive(BeSelected);
    }
    public void SetUnSelected()
    {
        BeSelected = false;
        Go_Selected.SetActive(BeSelected);
    }
    public void SetBeAim()
    {
        BeAim = true;
        Go_Aim.SetActive(BeAim);
    }
    public void SetUnAim()
    {
        BeAim = false;
        Go_Aim.SetActive(BeAim);
    }
}
