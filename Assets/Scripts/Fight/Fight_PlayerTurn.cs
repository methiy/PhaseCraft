using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        Debug.Log("playerTime");
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            //�ظ��ж���
            FightManager.Instance.CurPowerCount = 3;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();

            //�����޿������г�ʼ��
            if (FightCardManager.Instance.HasCard() == false)
            {
                FightCardManager.Instance.Init();
                //��������������
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
            }
           
            //����
            Debug.Log("����");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(5);//������
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();

            //���¿�����
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
        });
    }

    public override void OnUpdate()
    {
        
    }
}
