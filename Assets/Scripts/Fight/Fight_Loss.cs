using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʧ��
public class Fight_Loss : FightUnit
{
    public override void Init()
    {
        Debug.Log("ʧ����");
        FightManager.Instance.StopAllCoroutines();


        //ʧ��ҳ�棬��Ҫ�Լ���
        UIManager.Instance.ShowUI<BadEndUI>("BadEndUI");
        AudioManager.Instance.PlayBGM("bgm2");
    }

    public override void OnUpdate()
    {

    }
}
