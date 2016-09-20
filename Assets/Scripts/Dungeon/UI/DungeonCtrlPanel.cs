using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DungeonCtrlPanel : MonoBehaviour
{
    [SerializeField]
    GameObject Go_Accept;
    [SerializeField]
    Text Text_Accept;
    [SerializeField]
    GameObject Go_Quit;
    [SerializeField]
    Text Text_Quit;

    public void GetStop(StopData _data)
    {
        switch(_data.Type)
        {
            case "Encounter":
                Encounter();
                break;
        }
    }
    public void ChoiceResult(int _result)
    {
        DungeonManager.GetResult(_result);
    }

    void Encounter()
    {
        Text_Accept.text = "戰鬥";
        Text_Quit.text = "逃跑";
    }
    void Trap()
    {
        Text_Accept.text = "解除陷阱";
        Text_Quit.text = "放棄";
    }
    void Rescue()
    {
        Text_Accept.text = "救助";
        Text_Quit.text = "無視";
    }
    void RiskTreasure()
    {
        Text_Accept.text = "嘗試打開";
        Text_Quit.text = "放棄";
    }
}
