using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

//����ս����ʼ��
public class FightInit : FightUnit
{
    public override void Init()
    {

        //��ʼ��ս����ֵ
        FightManager.Instance.Init();

        //�л�bgm
        AudioManager.Instance.PlayBGM("battle");


        ///��ٷ��Ǵ�����յ�
        int index = SceneManager.GetActiveScene().buildIndex;

        if(index == 2)
        {
            //��������
            EnemyManager.Instance.LoadRes("10001");//��ȡ�ؿ�1�ĵ�����Ϣ����������ѡ��
        }
        if (index == 4)
        {
            //��������
            EnemyManager.Instance.LoadRes("10002");//��ȡ�ؿ�1�ĵ�����Ϣ����������ѡ��
        }
        if (index == 10)
        {
            //��������
            EnemyManager.Instance.LoadRes("10003");//��ȡ�ؿ�1�ĵ�����Ϣ����������ѡ��
        }
        if (index == 18)
        {
            //��������
            EnemyManager.Instance.LoadRes("10004");//��ȡ�ؿ�1�ĵ�����Ϣ����������ѡ��
        }
        if (index == 20)
        {
            //��������
            EnemyManager.Instance.LoadRes("10005");//��ȡ�ؿ�1�ĵ�����Ϣ����������ѡ��
        }
        if (index == 22)
        {
            //��������
            EnemyManager.Instance.LoadRes("10006");//��ȡ�ؿ�1�ĵ�����Ϣ����������ѡ��
        }
        if (index == 24)
        {
            //��������
            EnemyManager.Instance.LoadRes("10007");//��ȡ�ؿ�1�ĵ�����Ϣ����������ѡ��
        }
        ///�������ɣ�����


        //��ʼ��ս������
        FightCardManager.Instance.Init();

        //��ʾս��ҳ��
        UIManager.Instance.ShowUI<FightUI>("FightUI");

        //�л�����һغ�
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
