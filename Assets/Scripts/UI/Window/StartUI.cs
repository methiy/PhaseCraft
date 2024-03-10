using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartUI : UIBase
{
    // Start is called before the first frame update
    private void Awake()
    {
        //进入游戏
        Register("bg/start").onClick = onStartGame;//引号内为开始游戏键的所在文件夹和名称
    }

    private void onStartGame(GameObject obj, PointerEventData pData)
    {
        //跳转到游戏界面
        SceneManager.LoadScene("S0");
    }
}
