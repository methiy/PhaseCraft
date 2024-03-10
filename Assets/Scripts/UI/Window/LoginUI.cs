using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ��ʼ����(Ҫ�̳�UIBase)
/// </summary>
/// 
public class LoginUI : UIBase
{

    private void Awake()
    {
        //��ʼ��Ϸ
        Register("bg/startBtn").onClick = onStartGameBtn;//������Ϊ��ʼ��Ϸ���������ļ��к�����
    }

    private void onStartGameBtn(GameObject obj,PointerEventData pData)
    {
        //�ر�login����
        Close();

        //ս����ʼ��
        FightManager.Instance.ChangeType(FightType.Init);
    }
}
