using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ս��UI�������
/// </summary>

public class UIBase : MonoBehaviour//�̳л���
{

 //ע���¼�
    public UIEventTrigger Register(string name)//���庯��Register(�Ǽ�)��ʹ��UIEventTrigger���¼��������ļ���
    {
        Transform tf = transform.Find(name);
        return UIEventTrigger.Get(tf.gameObject);
    }


 //��ʾ
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

 //����
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
 //�رս���(���٣�
    public virtual void Close()
    {
        UIManager.Instance.CloseUI(gameObject.name);

    }
}
