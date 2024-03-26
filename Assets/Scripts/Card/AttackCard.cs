using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

//攻击卡
public class AttackCardItem : CardItem
{
    Enemy hitEnemy;//射线检测到敌人脚本
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        CheckRayToEnemy();
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
       if(hitEnemy==null){
            base.OnEndDrag(eventData);
       }else{
            if (TryUse() == true){
                // 播放特效
                PlayEffect(hitEnemy.transform.position);
                // 打击音效
                AudioManager.Instance.PlayEffect("Effect/sword");
                // 敌人受伤
                int val = int.Parse(data["Arg0"]);
                hitEnemy.Hit(val);
                hitEnemy=null;
            }else{
                base.OnEndDrag(eventData);
            }
       }
       
    }
    private void CheckRayToEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        const float MAX_LENGTH=10000.0f;
        if(Physics.Raycast(ray,out hit, MAX_LENGTH, LayerMask.GetMask("Enemy")))
        {
            hitEnemy = hit.transform.GetComponent<Enemy>();
        }
        else
        {
            //未射到怪物
            if(hitEnemy != null)
            {
                //hitEnemy.OnUnSelect();
                hitEnemy = null;
            }
        }

    }
}
