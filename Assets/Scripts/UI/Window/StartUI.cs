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
        //������Ϸ
        Register("bg/start").onClick = onStartGame;//������Ϊ��ʼ��Ϸ���������ļ��к�����
    }

    private void onStartGame(GameObject obj, PointerEventData pData)
    {
        //��ת����Ϸ����
        SceneManager.LoadScene("S0");
    }
}
