using UnityEngine;
using System.Collections;

public partial class BattleManager
{
    public static bool CanCtrl { get; private set; }
    [SerializeField]
    Camera CtrlCamera;//攝影機
    Touch Touch;//目前的觸碰
    Vector2 TouchWorldPoint;//觸碰點對應到世界座標
    int CurTounchCount;//目前的觸碰點數目
    Collider2D[] Go_CurTouchTargets;//觸碰的目標物件群

    void InitBattleCtrl()
    {
        CanCtrl = true;
    }
    /// <summary>
    /// 觸碰偵測
    /// </summary>
    public void TouchDetect()//觸碰偵測
    {
        if (!CanCtrl)
            return;
        CurTounchCount = 0;
        while (CurTounchCount < Input.touchCount)
        {
            Touch = Input.GetTouch(CurTounchCount);
            switch (Touch.phase)
            {
                case TouchPhase.Moved://拖曳執行
                    DragTouch();
                    break;
                case TouchPhase.Began://開始觸碰時執行
                    BeganTouch();
                    break;
                case TouchPhase.Stationary://常按執行
                    //DragTouch();
                    break;
                case TouchPhase.Ended://放開時執行

                    EndTouch();
                    break;
            }
            ++CurTounchCount;
        }
    }
    void BeganTouch()//觸碰
    {
        //判斷觸碰點
        TouchWorldPoint = CtrlCamera.ScreenToWorldPoint(Input.GetTouch(CurTounchCount).position);
        if (Physics2D.OverlapPoint(TouchWorldPoint) != null)
        {
            Go_CurTouchTargets = Physics2D.OverlapPointAll(TouchWorldPoint);
            for (int i = 0; i < Go_CurTouchTargets.Length; i++)
            {
                if (Go_CurTouchTargets[i].tag == "EnemyRole")
                {
                    RoleCom targetRole = Go_CurTouchTargets[i].GetComponent<RoleCom>();
                    BattleManager.PSetTargetRole(targetRole);
                }
            }
        }
    }

    void DragTouch()//拖曳
    {
    }
    void EndTouch()
    {
    }
}
