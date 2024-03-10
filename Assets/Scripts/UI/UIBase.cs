using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗UI界面基础
/// </summary>

public class UIBase : MonoBehaviour//继承基类
{

 //注册事件
    public UIEventTrigger Register(string name)//定义函数Register(登记)，使用UIEventTrigger（事件监听）的集合
    {
        Transform tf = transform.Find(name);
        return UIEventTrigger.Get(tf.gameObject);
    }


 //显示
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

 //隐藏
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
 //关闭界面(销毁）
    public virtual void Close()
    {
        UIManager.Instance.CloseUI(gameObject.name);

    }
}
