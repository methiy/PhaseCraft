using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 开始界面(要继承UIBase)
/// </summary>
/// 
public class LoginUI : UIBase
{

    private void Awake()
    {
        //开始游戏
        Register("bg/startBtn").onClick = onStartGameBtn;//引号内为开始游戏键的所在文件夹和名称
    }

    private void onStartGameBtn(GameObject obj,PointerEventData pData)
    {
        //关闭login界面
        Close();

        //战斗初始化
        FightManager.Instance.ChangeType(FightType.Init);
    }
}
