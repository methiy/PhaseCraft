using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ϸ��ڽű�
/// </summary>

public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //��ʼ�����ñ�
        GameConfigManager.Instance.Init();

        //��ʼ����Ƶ
        AudioManager.Instance.Init();

        //��ʼ���û���Ϣ
        RoleManager.Instance.Init();
       
        //��ʾloginUI,�����Ľű�������Ԥ������������һ��
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        //����bgm
        AudioManager.Instance.PlayBGM("bgm1");//bgm����
        
    }
}
