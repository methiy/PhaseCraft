using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class StartAPP : MonoBehaviour 
{ 
    void Start()
    {
        //��ʼ����Ƶ
        AudioManager.Instance.Init();
       
        //��ʾstartUI,�����Ľű�������Ԥ������������һ��
        UIManager.Instance.ShowUI<StartUI>("StartUI");

        //����bgm
        AudioManager.Instance.PlayBGM("bgm1");//bgm����

}
}