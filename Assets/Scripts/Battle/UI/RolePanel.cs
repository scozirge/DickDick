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
    Slider[] PlayerHealthSliders;
    [SerializeField]
    Slider[] EnemyHealthSliders;
    [SerializeField]
    Transform Trans_HitTextList;
    [SerializeField]
    GameObject Prefab_HitText;
    List<HitText> HitTextList = new List<HitText>();
    [SerializeField]
    Combo MyCombo;
    public void Init()
    {
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
    public void UpdateHealthUI()
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
    /// <summary>
    /// 創造擊中文字物件
    /// </summary>
    HitText SpawnHitText()
    {
        //創造物件並初始化
        GameObject go_hitText = GameObject.Instantiate(Prefab_HitText, Vector2.zero, Quaternion.identity) as GameObject;
        go_hitText.transform.SetParent(Trans_HitTextList);
        HitText hitText = go_hitText.GetComponent<HitText>();
        hitText.Init(MyCanvasRect, MyCamera);
        //加入清單
        HitTextList.Add(hitText);
        return hitText;
    }
    public void ShowHitText(params object[] _params)
    {
        if (HitTextList.Count == 0)
        {
            SpawnHitText().Show(_params);
        }
        else
        {
            bool isShowed = false;
            for (int i = 0; i < HitTextList.Count; i++)//用迴圈找可以播放的文字物件
            {
                if (!HitTextList[i].IsWork)
                {
                    HitTextList[i].Show(_params);
                    isShowed = true;
                    break;
                }
            }
            if (!isShowed)//isShowed為false代表目前的文字物件都在播放，創造新的文字物件並播放
            {
                SpawnHitText().Show(_params);
            }
        }
    }
    public void ShowCombo(int _combo)
    {
        MyCombo.ShowCombo(_combo);
    }
    public void HideCombo()
    {
        MyCombo.HideCombo();
    }
}
