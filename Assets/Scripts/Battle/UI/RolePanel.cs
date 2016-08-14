using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class RolePanel : MonoBehaviour
{
    [SerializeField]
    RectTransform MyCanvasRect;
    [SerializeField]
    Camera MyCamera;
    [SerializeField]
    static Slider[] PlayerHealthSliders;
    [SerializeField]
    static Slider[] EnemyHealthSliders;
    public void Init()
    {
        PlayerHealthSliders = new Slider[3];
        EnemyHealthSliders = new Slider[3];
        for (int i = 0; i < 3; i++)
        {
            PlayerHealthSliders[i] = transform.FindChild(string.Format("PHealthBar{0}", i)).GetComponent<Slider>();
            EnemyHealthSliders[i] = transform.FindChild(string.Format("EHealthBar{0}", i)).GetComponent<Slider>();
        }
        for (int i = 0; i < PlayerHealthSliders.Length; i++)
        {
            if (i > BattleManager.PlayerRoleList.Count)
                PlayerHealthSliders[i].gameObject.SetActive(false);
            else
            {
                PlayerHealthSliders[i].gameObject.SetActive(true);
                UIPosition.UIToWorldPos(MyCanvasRect, MyCamera, BattleManager.PlayerRoleList[i].transform, PlayerHealthSliders[i].GetComponent<RectTransform>(), 0, -240);
            }
            PlayerHealthSliders[i].value = 1;
        }
        for (int i = 0; i < EnemyHealthSliders.Length; i++)
        {
            if (i > BattleManager.EnemyRoleList.Count)
                EnemyHealthSliders[i].gameObject.SetActive(false);
            else
            {
                EnemyHealthSliders[i].gameObject.SetActive(true);
                UIPosition.UIToWorldPos(MyCanvasRect, MyCamera, BattleManager.EnemyRoleList[i].transform, EnemyHealthSliders[i].GetComponent<RectTransform>(), 0, -240);
            }
            EnemyHealthSliders[i].value = 1;
        }
    }
    public static void UpdateHealthUI()
    {
        for (int i = 0; i < BattleManager.PlayerRoleList.Count; i++)
        {
            PlayerHealthSliders[i].value = BattleManager.PlayerRoleList[i].HealthRatio;
        }
        for (int i = 0; i < BattleManager.EnemyRoleList.Count; i++)
        {
            EnemyHealthSliders[i].value = BattleManager.EnemyRoleList[i].HealthRatio;
        }
    }
}
