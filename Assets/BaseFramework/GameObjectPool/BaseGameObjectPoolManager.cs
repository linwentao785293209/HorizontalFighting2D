using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// ��Ϸ����ع������࣬�̳��� C# ����������
public class BaseGameObjectPoolManager : BaseSingletonInCSharp<BaseGameObjectPoolManager>
{
    // �洢��Ϸ����ص��ֵ䣬��Ϊ��Ϸ�������Դ·����ֵΪ��Ϸ�����
    private Dictionary<string, BaseGameObjectPool> baseGameObjectPoolDictionary = new Dictionary<string, BaseGameObjectPool>();

    // ��Ϸ����ع������ĸ��ڵ�
    private GameObject baseGameObjectPoolManagerNode;

    // �Ӷ�����л�ȡ��Ϸ����ķ�����������Դ·���ͻص�����
    public void GetGameObject(string gameObjectPath, UnityAction<GameObject> callBack)
    {
        // �����Ϸ������ֵ����Ƿ����ָ����Դ·���Ķ���أ����Ҷ�������Ƿ��п��õ���Ϸ����
        if (baseGameObjectPoolDictionary.ContainsKey(gameObjectPath) && baseGameObjectPoolDictionary[gameObjectPath].baseGameObjectPoolGameObjectList.Count > 0)
        {
            // ����п��õ���Ϸ���󣬵��ûص�����������Ϸ����
            callBack(baseGameObjectPoolDictionary[gameObjectPath].GetGameObject());
        }
        else
        {
            // ���û�п��õ���Ϸ����ͨ����Դ�������첽������Ϸ����
            BaseResourceManager.Instance.LoadAsync<GameObject>(gameObjectPath, (gameObject) =>
            {
                // ���ü��ص���Ϸ���������Ϊ��Դ·��
                gameObject.name = gameObjectPath;

                // ���ûص��������ؼ��ص���Ϸ����
                callBack(gameObject);
            });
        }
    }

    // �ͷ���Ϸ���󵽶���صķ�����������Դ·������Ϸ����
    public void ReleaseGameObject(string gameObjectPath, GameObject gameObject)
    {
        // �����Ϸ����ع������ĸ��ڵ���δ����������һ���µĸ��ڵ�
        if (baseGameObjectPoolManagerNode == null)
        {
            baseGameObjectPoolManagerNode = new GameObject("BaseGameObjectPoolManagerNode");
        }

        // �����Ϸ������ֵ����Ƿ����ָ����Դ·���Ķ����
        if (baseGameObjectPoolDictionary.ContainsKey(gameObjectPath))
        {
            // �������������Ϸ�����ͷŵ���Ӧ�Ķ������
            baseGameObjectPoolDictionary[gameObjectPath].ReleaseGameObject(gameObject);
        }
        else
        {
            // ���������������һ���µĶ���أ�����ӵ�������ֵ���
            baseGameObjectPoolDictionary.Add(gameObjectPath, new BaseGameObjectPool(baseGameObjectPoolManagerNode, gameObjectPath, gameObject));
        }
    }

    // �����Ϸ����ع������ķ���
    public void Clear()
    {
        baseGameObjectPoolDictionary.Clear(); // ��ն�����ֵ�
        baseGameObjectPoolManagerNode = null; // ���ö���ع������ĸ��ڵ�
    }
}
