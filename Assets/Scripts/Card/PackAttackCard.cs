using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PackAttackCard : CardItem
{
    private Enemy[] enemyList;
    // private const string ENEMYTAG="enemy";

    private Enemy hitEnemy;//射线检测到敌人脚本
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
                AttackToAll();
                hitEnemy=null;
            }else{
                base.OnEndDrag(eventData);
            }
       }
       
    }
    private void GetAllEnemy(){
        enemyList=FindObjectsOfType<Enemy>();
    }
    private void AttackToAll(){
        Debug.Log("群体攻击");
        GetAllEnemy();
        foreach (Enemy hitEnemy in enemyList)
        {
            // 播放特效
            PlayEffect(hitEnemy.transform.position);
            // 打击音效
            AudioManager.Instance.PlayEffect("Effect/sword");
            // 敌人受伤
            int val = int.Parse(data["Arg0"]);
            hitEnemy.Hit(val);    
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
