using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//���˵��ж�ö��
public enum ActionTpye
{
    None,
    Defend,//�ӷ���
    Attack,//����
}


/// <summary>
/// ���˽ű�
/// </summary>
public class Enemy : MonoBehaviour
{
    protected private Dictionary<string, string> data;//�������ݱ�

    public ActionTpye type;

    public GameObject hpItemObj;
    public GameObject actionObj;

    //UI���
    public Transform attackTf;
    public Transform defendTf;
    public Text defendTxt;
    public Text hpTxt;
    public Image hpImg;

    //��ֵ���
    public int Defend;
    public int Attack;
    public int MaxHp;
    public int CurHp;

    //������
    SkinnedMeshRenderer _meshRenderer;
    public Animator ani;

    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }

    void Start()
    {
        _meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
        ani = transform.GetComponent<Animator>();

        type = ActionTpye.None;
        hpItemObj = UIManager.Instance.CreateHpItem();
        actionObj = UIManager.Instance.CreateActionIcon();

        attackTf = actionObj.transform.Find("attack");
        defendTf = actionObj.transform.Find("defend");

        defendTxt = hpItemObj.transform.Find("fangyu/Text").GetComponent<Text>();
        hpTxt = hpItemObj.transform.Find("hpTxt").GetComponent<Text>();
        hpImg = hpItemObj.transform.Find("fill").GetComponent<Image>();

        //�����ж������ж���λ��
        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.down * 0.2f);
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position);

        SetRandomAxction();

        //��ʼ����ֵ
        Attack = int.Parse(data["Attack"]);
        CurHp = int.Parse(data["Hp"]);
        MaxHp = CurHp;
        Defend = int.Parse(data["Defend"]);

        UpdateHp();
        UpdateDefend();
    }

    //���һ���ж�
    public void SetRandomAxction()
    {
        int ran = Random.Range(1, 3);

        type = (ActionTpye)ran;

        switch (type)
        {
            case ActionTpye.None:
                break;
            case ActionTpye.Defend:
                attackTf.gameObject.SetActive(false);
                defendTf.gameObject.SetActive(true);
                break;
            case ActionTpye.Attack:
                attackTf.gameObject.SetActive(true);
                defendTf.gameObject.SetActive(false);
                break;
        }
    }

    //����Ѫ��
    public void UpdateHp()
    {
        hpTxt.text = CurHp + "/" + MaxHp;
        hpImg.fillAmount = (float)CurHp / (float)MaxHp;
    }

    //���·���ֵ
    public void UpdateDefend()
    {
        defendTxt.text = Defend.ToString();
    }

    //��������ѡ�У���ʾ���
    /*public void OnSelect()
    {
        _meshRenderer.material.SetColor("_OtlColor", Color.red);

    }

    //δѡ��

    public void OnUnSelect()
    {
        _meshRenderer.material.SetColor("_OtlColor", Color.black);
    }*/

    //����
    public void Hit(int val)
    {
        //�ȿۻ���
        if (Defend >= val)
        {
            //�ۻ���
            Defend -= val;

            //��������


            //ani.Play("hit", 0, 0);
        }
        else
        {
            val = val - Defend;
            Defend = 0;
            CurHp -= val;
            if (CurHp <= 0)
            {
                CurHp = 0;
                //��������


                //ani.Play("die");


                //���˴��б����Ƴ�
                EnemyManager.Instance.DeleteEnemy(this);

                Destroy(gameObject, 1);
                Destroy(actionObj);
                Destroy(hpItemObj);
            }
            else
            {
                //����
                ///
                //ani.Play("hit", 0, 0);
            }
        }
        //ˢ��Ѫ����ui
        UpdateDefend();
        UpdateHp();
    }

    //���ع���ͷ�ϵ��ж���־
    public void HideAction()
    {
        attackTf.gameObject.SetActive(false);
        defendTf.gameObject.SetActive(false);
    }

    //ִ�е����ж�
    public IEnumerator DoAction()
    {
        HideAction();

        //���Ŷ������������õ�excel��

        // //ani.Play("attack");

        //�ȴ�ĳһʱ������Ӧ����Ϊ��excel
        yield return new WaitForSeconds(0.5f);//����

        switch (type)
        {
            case ActionTpye.None:
                break;

            case ActionTpye.Defend:
                //�ӷ���
                Defend += 1;
                UpdateDefend();
                //���Բ�����Ӧ����Ч
                break;

            case ActionTpye.Attack:
                //��ҿ�Ѫ
                FightManager.Instance.GetPlayerHit(Attack);
                //���������
                Camera.main.DOShakePosition(0.1f, 0.2f, 5, 45);
                break;
        }

        //�ȴ�����������ϡ��Զ���ʱ��
        yield return new WaitForSeconds(1);
        //���Ŵ���

       // //ani.Play("idle");
    }
}
