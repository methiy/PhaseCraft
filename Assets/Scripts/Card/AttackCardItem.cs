using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

//������
public class AttackCardItem : CardItem, IPointerDownHandler
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public override void OnDrag(PointerEventData eventData)
    {
       
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
       
    }

    //����
    public void OnPointerDown(PointerEventData eventData)
    {
        //��������
        AudioManager.Instance.PlayEffect("Cards/draw");

        //��ʾ����
        UIManager.Instance.ShowUI<LineUI>("LineUI");

        //���ÿ�ʼ��λ��
        UIManager.Instance.GetUI<LineUI>("LineUI").SetStartPos(transform.GetComponent<RectTransform>().anchoredPosition);

        //�������
        Cursor.visible = false;

        //�ر�����Эͬ����
        StopAllCoroutines();

        //����������Эͬ����
        StartCoroutine(OnMouseDownRight(eventData));
    }

    private IEnumerator OnMouseDownRight(PointerEventData pData)
    {
        while (true)
        {
            //�����������Ҽ�������ѭ��
            if (Input.GetMouseButton(1))
            {
                break;
            }

            Vector2 pos;
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent.GetComponent<RectTransform>(),
                pData.position,
                pData.pressEventCamera,
                out pos
                ))
            {
                //���ü�ͷλ��
                UIManager.Instance.GetUI<LineUI>("LineUI").SetEndPos(pos);

                //�������߼���Ƿ���������
                CheckRayToEnemy();
            }

            yield return null;
        }

        //����ѭ������ʾ���
        Cursor.visible = true;
        //�ر����߽���
        UIManager.Instance.CloseUI("LineUI");
    }

    Enemy hitEnemy;//���߼�⵽���˽ű�
    private void CheckRayToEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, 10000, LayerMask.GetMask("Enemy")))
        {
            hitEnemy = hit.transform.GetComponent<Enemy>();

            //hitEnemy.OnSelect();//ѡ��

            //���������������ʹ�ù�����
            if (Input.GetMouseButtonDown(0))
            {
                //�ر�����Эͬ����
                StopAllCoroutines();

                //�����ʾ
                Cursor.visible = true;

                //�ر����߽���
                UIManager.Instance.CloseUI("LineUI");

                if (TryUse() == true)
                {
                    //������Ч
                    PlayEffect(hitEnemy.transform.position);

                    //�����Ч
                    AudioManager.Instance.PlayEffect("Effect/sword");

                    //��������
                    int val = int.Parse(data["Arg0"]);
                    hitEnemy.Hit(val);
                }

                //����δ��ѡ��
                //hitEnemy.OnUnSelect();

                //���õ��˽ű�Ϊnull
                hitEnemy = null;
            }
        }
        else
        {
            //δ�䵽����
            if(hitEnemy != null)
            {
                //hitEnemy.OnUnSelect();
                hitEnemy = null;
            }
        }


    }
}
