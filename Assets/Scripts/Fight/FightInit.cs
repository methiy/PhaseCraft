using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

//卡牌战斗初始化
public class FightInit : FightUnit
{
    public override void Init()
    {

        //初始化战斗数值
        FightManager.Instance.Init();

        //切换bgm
        AudioManager.Instance.PlayBGM("battle");


        ///穷举法是代码的终点
        int index = SceneManager.GetActiveScene().buildIndex;

        if(index == 2)
        {
            //敌人生成
            EnemyManager.Instance.LoadRes("10001");//读取关卡1的敌人信息，可以自由选择
        }
        if (index == 4)
        {
            //敌人生成
            EnemyManager.Instance.LoadRes("10002");//读取关卡1的敌人信息，可以自由选择
        }
        if (index == 10)
        {
            //敌人生成
            EnemyManager.Instance.LoadRes("10003");//读取关卡1的敌人信息，可以自由选择
        }
        if (index == 18)
        {
            //敌人生成
            EnemyManager.Instance.LoadRes("10004");//读取关卡1的敌人信息，可以自由选择
        }
        if (index == 20)
        {
            //敌人生成
            EnemyManager.Instance.LoadRes("10005");//读取关卡1的敌人信息，可以自由选择
        }
        if (index == 22)
        {
            //敌人生成
            EnemyManager.Instance.LoadRes("10006");//读取关卡1的敌人信息，可以自由选择
        }
        if (index == 24)
        {
            //敌人生成
            EnemyManager.Instance.LoadRes("10007");//读取关卡1的敌人信息，可以自由选择
        }
        ///就这样吧，倦了


        //初始化战斗卡面
        FightCardManager.Instance.Init();

        //显示战斗页面
        UIManager.Instance.ShowUI<FightUI>("FightUI");

        //切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
