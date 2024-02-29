using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ϸ�������
public class BaseGameObjectPool
{
    // ��Ϸ�������Դ·��
    public string gameObjectPath;

    // ��Ϸ����صĸ��ڵ�
    public GameObject baseGameObjectPoolNode;

    // �洢��Ϸ������б�
    public List<GameObject> baseGameObjectPoolGameObjectList;

    // ���캯�������ڳ�ʼ����Ϸ�����
    public BaseGameObjectPool(GameObject baseGameObjectPoolManagerNode, string gameObjectPath, GameObject gameObject)
    {
        // ������Ϸ����صĸ��ڵ㣬������
        baseGameObjectPoolNode = new GameObject($"{gameObjectPath} BaseGameObjectPoolNode");
        this.gameObjectPath = gameObjectPath;

        // ����Ϸ����صĸ��ڵ���Ϊ����Ĺ���ڵ���ӽڵ�
        baseGameObjectPoolNode.transform.parent = baseGameObjectPoolManagerNode.transform;

        // ��ʼ����Ϸ�����б�
        baseGameObjectPoolGameObjectList = new List<GameObject>();

        // ���������Ϸ������ӵ���Ϸ�������
        ReleaseGameObject(gameObject);
    }

    // �ͷ���Ϸ���󵽶������
    public void ReleaseGameObject(GameObject gameObject)
    {
        // ����Ϸ��������Ϊ����Ծ״̬
        gameObject.SetActive(false);

        // ����Ϸ������ӵ�������б���
        baseGameObjectPoolGameObjectList.Add(gameObject);

        // ����Ϸ����ĸ��ڵ���Ϊ����صĸ��ڵ�
        gameObject.transform.parent = baseGameObjectPoolNode.transform;
    }

    // �Ӷ�����л�ȡ��Ϸ����
    public GameObject GetGameObject()
    {
        GameObject gameObject = null;

        // �Ӷ�����б���ȡ����һ����Ϸ����
        gameObject = baseGameObjectPoolGameObjectList[0];

        // �Ӷ�����б����Ƴ�����Ϸ����
        baseGameObjectPoolGameObjectList.RemoveAt(0);

        // ����Ϸ��������Ϊ��Ծ״̬
        gameObject.SetActive(true);

        // ����Ϸ����ĸ��ڵ���Ϊnull��ʹ���������صĿ���
        gameObject.transform.parent = null;

        // ���ػ�ȡ����Ϸ����
        return gameObject;
    }
}
