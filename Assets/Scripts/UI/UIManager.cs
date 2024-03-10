using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// UI������
/// </summary>

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;//�����ı任���

    private List<UIBase> uiList;//������ع��Ľ���ļ���


    private void Awake()
    {
        Instance = this;
        //��λ����
        canvasTf = GameObject.Find("Canvas").transform;//������ΪUI���ڵĻ�������
        //��ʼ������
        uiList = new List<UIBase>();
    }

    //��ʾ
    public UIBase ShowUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if(ui == null)
        {
            //������û�У���Ҫ��Resources/UI�ļ�����Ѱ��
            GameObject obj = Instantiate(Resources.Load("UI/" + uiName), canvasTf) as GameObject;

            //������
            obj.name = uiName;

            //�����Ҫ�Ľű�
            ui = obj.AddComponent<T>();

            //��ӵ����Ͻ��д���
            uiList.Add(ui);
        }
        else
        {
            //��ʾ
            ui.Show();
        }

        return ui;
    } 

    //����
    public void HideUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if(ui != null)
        {
            ui.Hide();
        }
    }

    //�ر����н���
    public void CloseALLUI()
    {
        for(int i = uiList.Count - 1;i >= 0; i--)
        {
            Destroy(uiList[i].gameObject);
        }

        uiList.Clear();//��ռ���
    }

    //�ر�ҳ��
    public void CloseUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if(ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }


    //�Ӽ������ҵ����ֶ�Ӧ�Ľ���ű�
    public UIBase Find(string uiName)
    {
        for(int i = 0;i < uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
            {
                return uiList[i];
            }
        }
        return null;
    }

    //���ĳ������Ľű�
    public T GetUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            return ui.GetComponent <T>();
        }
        return null;
    }


    //��������ͷ�����ж�ͼ������
    public GameObject CreateActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon"), canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling();//�����ڸ����ĵ�һλ
        return obj;
    }
    //�����ڵ��˵ײ���Ѫ��
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling();//�����ڸ����ĵ�һλ
        return obj;
    }

    //��ʾ����
    public void ShowTip(string msg,Color color,System.Action callback = null)
    {
        GameObject obj = Instantiate(Resources.Load("UI/Tips"), canvasTf) as GameObject;
        Text text = obj.transform.Find("bg/Text").GetComponent<Text>();
        text.color = color;
        text.text = msg;
        Tween scale1 = obj.transform.Find("bg").DOScaleY(1, 0.4f);
        Tween scale2 = obj.transform.Find("bg").DOScaleY(0, 0.4f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate ()
        {
            if (callback != null)
            {
                callback();
            }
        }
        );
        MonoBehaviour.Destroy(obj, 2);
    }
    
}
