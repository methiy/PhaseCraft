using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

/// <summary>
/// 胜利结束页面，继承UIBase,
/// </summary>
public class HappyEndUI : UIBase
{
    private void Awake()
    {
        //返回游戏主页
          Register("ui/continueBtn").onClick = ContinueGameBtn;
    }
    private void ContinueGameBtn(GameObject obj, PointerEventData pData)
    {
        //获取当前场景
        Scene scene = SceneManager.GetActiveScene();

        List<string> scenes = GetAllSceneName().ToList();
        int index = scenes.FindIndex(s => s == scene.name);
        string sceneName = "";
        if (index != -1 && index != 0)
        {
            sceneName = scenes[index + 1];
            SceneManager.LoadScene(sceneName);
        }
    }
    string[] GetAllSceneName()
    {
        int count = SceneManager.sceneCountInBuildSettings;
        string[] scene_names = new string[count];

        for (int i = 0; i < count; i++)
        {
            scene_names[i] = SceneUtility.GetScenePathByBuildIndex(i);

            string[] strs = scene_names[i].Split('/');
            string str = strs[strs.Length - 1];
            strs = str.Split('.');
            str = strs[0];
            scene_names[i] = str;
        }
        return scene_names;
    }
}
