using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ParalysisCard : CardItem
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
                //!todo 做一个麻痹特效
                PlayEffect(hitEnemy.transform.position);
                // 打击音效
                //! todo 麻痹音效
                AudioManager.Instance.PlayEffect("Effect/sword");
                // 此敌人跳过回合
                hitEnemy.SetState(State.Inaccessible);
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
