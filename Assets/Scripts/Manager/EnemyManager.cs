using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ���˹�����
/// </summary>

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = new EnemyManager();

    public List<Enemy> enemyList;//����ս���еĵ���

    //���ص�����Դ

    public void LoadRes(string id)
    {
        enemyList = new List<Enemy>();

        //��ȡ�ؿ���
        Dictionary<string, string> levelData = GameConfigManager.Instance.GetLevelById(id);

        //����id��Ϣ
        string[] enemyIds = levelData["EnemyIds"].Split('=');

        string[] enemyPos = levelData["Pos"].Split('=');//����λ����Ϣ

        for (int i =0; i < enemyIds.Length; i++)
        {
            string enemyId = enemyIds[i];
            string[] posArr = enemyPos[i].Split(',');
            //����λ��
            float x = float.Parse(posArr[0]);
            float y = float.Parse(posArr[1]);
            float z = float.Parse(posArr[2]);


            //���ݵ���id��õ���������Ϣ
            Dictionary<string,string> enemyData = GameConfigManager.Instance.GetEnemyById(enemyId);

            GameObject obj = Object.Instantiate(Resources.Load(enemyData["Model"])) as GameObject;//����Դ·�����ض�Ӧ�ĵ���

            Enemy enemy = obj.AddComponent<Enemy>();//��ӵ��˽ű�

            enemy.Init(enemyData);//���������Ϣ

            //���浽����
            enemyList.Add(enemy);

            obj.transform.position = new Vector3(x, y,z);
        }
    }

    //�Ƴ�����
    public void DeleteEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        //�Ƿ��ɱ���й���
        if(enemyList.Count == 0)
        {
            //! todo ���Ŷ���
            Debug.Log("�ɹ�����...");
            FightManager.Instance.ChangeType(FightType.Win);
        }
    }

    //ִ�л��ŵĹ������Ϊ
    public IEnumerator DoAllEnemyAction()
    {
        for(int i = 0;i < enemyList.Count; i++)
        {
            yield return FightManager.Instance.StartCoroutine(enemyList[i].DoAction());

        }

        //�ж��󣬸������е��˵���Ϊ
        for(int i = 0;i < enemyList.Count; i++)
        {
            enemyList[i].SetRandomAxction();
        }

        //�л�����һغ�
        FightManager.Instance.ChangeType(FightType.Player);
    }
}
