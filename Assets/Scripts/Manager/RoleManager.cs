using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�û���Ϣ��������ӵ�еĿ��Ƶ���Ϣ����ҵȣ�
public class RoleManager 
{
    public static RoleManager Instance = new RoleManager();

    public List<string> cardList;//����ӵ�еĿ��Ƶ�id



    public void Init()
    {
        cardList = new List<string>();
        //���Ź����������ŷ����� ����Ч����
        // cardList.Add("1000");
        // cardList.Add("1000");
        // cardList.Add("1000");
        // cardList.Add("1000");
        
        cardList.Add("1001");
        cardList.Add("1001");
        cardList.Add("1001");
        cardList.Add("1001");
        cardList.Add("1001");
        cardList.Add("1001");
        cardList.Add("1001");
        cardList.Add("1001");

        cardList.Add("1002");
        
        cardList.Add("1003");

        cardList.Add("1004");

        cardList.Add("1005");
        cardList.Add("1005");
        cardList.Add("1005");
        cardList.Add("1005");
   

    }
}
