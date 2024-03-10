using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapApp : MonoBehaviour
{
    void Start()
    {
        //初始化音频
        AudioManager.Instance.Init();

        //显示startUI,创建的脚本名称与预制体物体名称一致
        UIManager.Instance.ShowUI<MapUI1>("MapUI");

        //播放bgm
        AudioManager.Instance.PlayBGM("bgm1");//bgm名称

    }
}
