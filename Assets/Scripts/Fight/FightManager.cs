using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//ս��ö��
public enum FightType
{
    None,
    Init,
    Player,//��һغ�
    Enemy,//���˻غ�
    Win,
    Loss
}

/// <summary>
/// ս��������
/// </summary>

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fighUnit;//ս����Ԫ

    public int MaxHp;//���Ѫ��
    public int CurHp;//��ǰѪ��

    public int MaxPowerCount;//�������
    public int CurPowerCount;//��ǰ����
    public int DefenseCount;//����ֵ

    //��ʼ��
    public void Init()
    {
        MaxHp = 10;
        CurHp = 10;
        MaxPowerCount = 3;
        CurPowerCount = 3;
        DefenseCount = 10;
    }

    private void Awake()
    {
        Instance = this;
    }



    //�л�ս������
    public void ChangeType(FightType type)
    {
        switch (type)
        {
            case FightType.None:
                break;

            case FightType.Init:
                fighUnit = new FightInit();
                break;

            case FightType.Player:
                fighUnit = new Fight_PlayerTurn();
                break;

            case FightType.Enemy:
                fighUnit = new Fight_EnemyTurn();
                break;

            case FightType.Win:
                fighUnit = new Fight_Win();
                break;

            case FightType.Loss:
                fighUnit = new Fight_Loss();
                break;
        }
        fighUnit.Init();//��ʼ��
    }

    //��������߼�
    public void GetPlayerHit(int hit)
    {
        //�ۻ���
        if(DefenseCount >= hit)
        {
            DefenseCount -= hit;
        }
        else
        {
            hit = hit - DefenseCount;
            DefenseCount = 0;
            CurHp -= hit;
            if(CurHp <= 0)
            {
                CurHp = 0;

                //�л�����Ϸʧ��ҳ��
                ChangeType(FightType.Loss);
            }
        }

        //���½���
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdateHp();
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdateDefense();
    }

    private void Update()
    {
        if(fighUnit != null)
        {
            fighUnit.OnUpdate();
        }
    }
}
