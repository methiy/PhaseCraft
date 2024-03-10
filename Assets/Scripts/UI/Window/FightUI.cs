using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

//ս������
public class FightUI : UIBase
{
    private Text cardCountTxt;//��������
    private Text noCardCountTxt;//���ƶ�����
    private Text powerTxt;
    private Text hpTxt;
    private Image hpImg;
    private Text fyTxt;//����ֵ
    private List<CardItem> cardItemList;//���濨������ļ���

    private void Awake()
    {
        cardItemList = new List<CardItem>();
        cardCountTxt = transform.Find("hasCard/icon/Text").GetComponent<Text>();
        noCardCountTxt = transform.Find("noCard/icon/Text").GetComponent<Text>();
        powerTxt = transform.Find("mana/Text").GetComponent<Text>();
        hpTxt = transform.Find("hp/moneyTxt").GetComponent<Text>();
        hpImg = transform.Find("hp/fill").GetComponent<Image>();
        fyTxt = transform.Find("hp/fangyu/Text").GetComponent<Text>();
        transform.Find("turnBtn").GetComponent<Button>().onClick.AddListener(onChangeTurnBtn);
    }

    //��һغϽ������л������˻غ�
    private void onChangeTurnBtn()
    {
        //ֻ����һغϲ����л�
        if(FightManager.Instance.fighUnit is Fight_PlayerTurn)
        {
            FightManager.Instance.ChangeType(FightType.Enemy);
        }
    }

    private void Start()
    {
        UpdateHp();
        UpdatePower();
        UpdateDefense();
        UpdateCardCount();
        UpdateUsedCardCount();

    }

    //����Ѫ��
    public void UpdateHp()
    {
        hpTxt.text = FightManager.Instance.CurHp + "/" + FightManager.Instance.MaxHp;
        hpImg.fillAmount = (float)FightManager.Instance.CurHp / (float)FightManager.Instance.MaxHp;
    }

    //��������
    public void UpdatePower()
    {
        powerTxt.text = FightManager.Instance.CurPowerCount + "/" + FightManager.Instance.MaxPowerCount;
    }

    //��������
    public void UpdateDefense()
    {
        fyTxt.text = FightManager.Instance.DefenseCount.ToString();
    }

    //���¿�������
    public void UpdateCardCount()
    {
        cardCountTxt.text = FightCardManager.Instance.cardList.Count.ToString();
    }

    //�������ƶ�����
    public void UpdateUsedCardCount()
    {
       noCardCountTxt.text = FightCardManager.Instance.usedCardList.Count.ToString();
    }

    //������������
    public void CreateCardItem(int count)
    {
        if(count > FightCardManager.Instance.cardList.Count)
        {
            count = FightCardManager.Instance.cardList.Count;
        }
        for (int i = 0;i < count; i++)
        {
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"), transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1000, -700);
            //var item = obj.AddComponent<CardItem>();

            string cardId = FightCardManager.Instance.DrawCard();
            Dictionary<string, string> data = GameConfigManager.Instance.GetCardById(cardId);
            CardItem  item = obj.AddComponent(System.Type.GetType(data["Script"])) as CardItem;
            item.Init(data);
            cardItemList.Add(item);
        }
    }

    //���¿���λ��
    public void UpdateCardItemPos()
    {
        float offset = 800.0f / cardItemList.Count;
        Vector2 startPos = new Vector2(-cardItemList.Count / 2.0f * offset + offset * 0.5f, -700);
        for(int i = 0;i < cardItemList.Count; i++)
        {
            cardItemList[i].GetComponent<RectTransform>().DOAnchorPos(startPos, 0.5f);
            startPos.x = startPos.x + offset;
        }
    }
    //ɾ����������
    public void RemoveCard(CardItem item)
    {
        AudioManager.Instance.PlayEffect("Cards/cardShove");//�Ƴ���Ч

        item.enabled = false;//���ÿ����߼�

        //��ӵ����Ƽ���
        FightCardManager.Instance.usedCardList.Add(item.data["Id"]);

        //����ʹ�ú�Ŀ�������
        noCardCountTxt.text = FightCardManager.Instance.usedCardList.Count.ToString();

        //�Ӽ�����ɾ��
        cardItemList.Remove(item);

        //ˢ�¿���λ��
        UpdateCardItemPos();

        //�����Ƶ����ƶ�Ч��
        item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -700), 0.25f);

        item.transform.DOScale(0, 0.25f);

        Destroy(item.gameObject, 1);
    }

    //ɾ�����п���
    public void RemoveAllCards()
    {
        for(int i = cardItemList.Count - 1;i >= 0;i--)
        {
            RemoveCard(cardItemList[i]);
        }
    }
}
