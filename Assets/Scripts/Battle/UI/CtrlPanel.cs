using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CtrlPanel : MonoBehaviour
{
    [SerializeField]
    Text Text_Accurate;
    
    public void Init()
    {

    }

    public void OnAttackClick()
    {
        BattleManager.Attack();
    }
    public void OnDefendClick()
    {
        BattleManager.Defend();
    }

    public void UpdateAccurateUI(float _acculate)
    {
        Text_Accurate.text = string.Format("命中:{0}%", TextManager.ToPercent(_acculate));
    }
}
