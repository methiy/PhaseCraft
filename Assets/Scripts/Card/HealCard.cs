using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if(TryUse() == true)
        {
            //ʹ��Ч��
            int val = int.Parse(data["Arg0"]);
            if(val+FightManager.Instance.CurHp>FightManager.Instance.MaxHp){
                val=FightManager.Instance.MaxHp-FightManager.Instance.CurHp;
            }

            //����ʹ�ú��������ÿ�ſ�������һ����
            //! todo ��Ѫ����
            AudioManager.Instance.PlayEffect("Effect/healspell");//���õ�����
            //����Ѫ��
            FightManager.Instance.CurHp += val;
            //ˢ��Ѫ���ı�
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateHp();

            Vector3 pos = Camera.main.transform.position;
            pos.y = 0;
            PlayEffect(pos);
        }
        else
        {
            base.OnEndDrag(eventData);
        }
        
    }
}
