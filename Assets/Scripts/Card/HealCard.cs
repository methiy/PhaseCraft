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
            //使用效果
            int val = int.Parse(data["Arg0"]);
            if(val+FightManager.Instance.CurHp>FightManager.Instance.MaxHp){
                val=FightManager.Instance.MaxHp-FightManager.Instance.CurHp;
            }

            //播放使用后的声音（每张卡声音不一样）
            //! todo 回血声音
            AudioManager.Instance.PlayEffect("Effect/healspell");//配置到表中
            //增加血量
            FightManager.Instance.CurHp += val;
            //刷新血量文本
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
