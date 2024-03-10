using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏入口脚本
/// </summary>

public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //初始化配置表
        GameConfigManager.Instance.Init();

        //初始化音频
        AudioManager.Instance.Init();

        //初始化用户信息
        RoleManager.Instance.Init();
       
        //显示loginUI,创建的脚本名称与预制体物体名称一致
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        //播放bgm
        AudioManager.Instance.PlayBGM("bgm1");//bgm名称
        
    }
}
