using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʤ��
public class Fight_Win : FightUnit
{
    public override void Init()
    {
     
        Debug.Log("ʤ��");
        FightManager.Instance.StopAllCoroutines();


        //ʧ��ҳ�棬��Ҫ�Լ���
        UIManager.Instance.ShowUI<HappyEndUI>("HappyEndUI");
        AudioManager.Instance.PlayBGM("bgm3");
    }

    public override void OnUpdate()
    {

    }
}
