using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用户信息管理器（拥有的卡牌等信息，金币等）
public class RoleManager 
{
    public static RoleManager Instance = new RoleManager();

    public List<string> cardList;//储存拥有的卡牌的id



    public void Init()
    {
        cardList = new List<string>();
        //四张攻击卡，八张防御卡 三张效果卡
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
