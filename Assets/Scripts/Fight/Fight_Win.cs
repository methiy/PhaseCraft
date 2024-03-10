using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//胜利
public class Fight_Win : FightUnit
{
    public override void Init()
    {
     
        Debug.Log("胜利");
        FightManager.Instance.StopAllCoroutines();


        //失败页面，需要自己做
        UIManager.Instance.ShowUI<HappyEndUI>("HappyEndUI");
        AudioManager.Instance.PlayBGM("bgm3");
    }

    public override void OnUpdate()
    {

    }
}
