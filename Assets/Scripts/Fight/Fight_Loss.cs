using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//失败
public class Fight_Loss : FightUnit
{
    public override void Init()
    {
        Debug.Log("失败了");
        FightManager.Instance.StopAllCoroutines();


        //失败页面，需要自己做
        UIManager.Instance.ShowUI<BadEndUI>("BadEndUI");
        AudioManager.Instance.PlayBGM("bgm2");
    }

    public override void OnUpdate()
    {

    }
}
