using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapApp : MonoBehaviour
{
    void Start()
    {
        //��ʼ����Ƶ
        AudioManager.Instance.Init();

        //��ʾstartUI,�����Ľű�������Ԥ������������һ��
        UIManager.Instance.ShowUI<MapUI1>("MapUI");

        //����bgm
        AudioManager.Instance.PlayBGM("bgm1");//bgm����

    }
}
