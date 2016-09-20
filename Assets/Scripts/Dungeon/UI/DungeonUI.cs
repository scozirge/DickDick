using UnityEngine;
using System.Collections;

public class DungeonUI : MonoBehaviour
{
    static DungeonCtrlPanel DCtrlPanel;
    static GameObject Go_DCtrlPanel;
    [SerializeField]
    static DungeonMapPanel DMapPanel;

    public void Init()
    {
        DMapPanel = transform.FindChild("MapPanel").GetComponent<DungeonMapPanel>();
        DCtrlPanel = transform.FindChild("CtrlPanel").GetComponent<DungeonCtrlPanel>();
        Go_DCtrlPanel = DCtrlPanel.gameObject;
        HideCtrl();
    }
    public static void GetStop(StopData _data)
    {
        DCtrlPanel.GetStop(_data);
        ShowCtrl();
    }
    static void HideCtrl()
    {
        Go_DCtrlPanel.SetActive(false);
    }
    static void ShowCtrl()
    {
        Go_DCtrlPanel.SetActive(true);
    }
    public static void Forward()
    {
        DMapPanel.Forward();
        HideCtrl();
    }
}
