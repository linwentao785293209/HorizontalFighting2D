using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Internal;

/// <summary>
/// BaseMonoBehaviourManager ��һ��MonoBehaviour��Ϊ�������ĵ����ࡣ
/// </summary>
public class BaseMonoBehaviourManager : BaseSingletonInMonoBehaviour<BaseMonoBehaviourManager>
{
    // ���ڴ洢�������������¼����������ֵ䡣
    private Dictionary<Type, BaseLifeCycleManager> baseLifeCycleManagerDictionary = new Dictionary<Type, BaseLifeCycleManager>();

    private BaseCoroutineManager baseCoroutineManager;

    protected override void Awake()
    {
        base.Awake();

        Init();
    }

    private void Init()
    {
        InitBaseLifeCycleUpdateManagers();
        InitBaseCoroutineManager();
    }

    private void InitBaseLifeCycleUpdateManagers()
    {
        AddBaseLifeCycleManager<BaseLifeCycleUpdateManager>();
        AddBaseLifeCycleManager<BaseLifeCycleLateUpdateManager>();
        AddBaseLifeCycleManager<BaseLifeCycleFixedUpdateManager>();
    }

    private void InitBaseCoroutineManager()
    {
        GameObject baseCoroutineManagerGameObject = new GameObject("BaseCoroutineManager");

        baseCoroutineManager = baseCoroutineManagerGameObject.AddComponent<BaseCoroutineManager>();

        baseCoroutineManagerGameObject.transform.parent = transform;
    }

    /// <summary>
    /// ���ֵ���������������¼���������
    /// </summary>
    /// <typeparam name="T">Ҫ��ӵ����������¼������������͡�</typeparam>
    public void AddBaseLifeCycleManager<T>() where T : BaseLifeCycleManager
    {
        Type baseLifeCycleManagerType = typeof(T);

        if (!baseLifeCycleManagerDictionary.ContainsKey(baseLifeCycleManagerType))
        {
            // ����һ���µ� GameObject ��Ϊ���������¼���������������
            GameObject baseLifeCycleManagerGameObject = new GameObject(baseLifeCycleManagerType.Name);

            // �����������ָ�����͵����������¼������������
            BaseLifeCycleManager nowBaseLifeCycleManager = baseLifeCycleManagerGameObject.AddComponent<T>();

            // ��������Ϊ��ǰ������Ӷ����Ա��ڳ�������֯��
            baseLifeCycleManagerGameObject.transform.parent = transform;

            // �����������¼���������ӵ��ֵ��С�
            baseLifeCycleManagerDictionary.Add(baseLifeCycleManagerType, nowBaseLifeCycleManager);

            Debug.Log($"{baseLifeCycleManagerType.Name} ���ֵ��гɹ����");
        }
        else
        {
            Debug.Log($"{baseLifeCycleManagerType.Name} ���ֵ����Ѵ���");
        }
    }

    /// <summary>
    /// ���ֵ����Ƴ����������¼���������
    /// </summary>
    /// <typeparam name="T">Ҫ�Ƴ������������¼������������͡�</typeparam>
    public void RemoveBaseLifeCycleManager<T>() where T : BaseLifeCycleManager
    {
        Type baseLifeCycleManagerType = typeof(T);

        if (baseLifeCycleManagerDictionary.TryGetValue(baseLifeCycleManagerType, out BaseLifeCycleManager nowBaseLifeCycleManager))
        {
            // �������������¼��������� GameObject��
            Destroy(nowBaseLifeCycleManager.gameObject);

            // ���ֵ����Ƴ����������¼���������
            baseLifeCycleManagerDictionary.Remove(baseLifeCycleManagerType);

            Debug.Log($"{baseLifeCycleManagerType.Name} ���ֵ��гɹ��Ƴ�");
        }
        else
        {
            Debug.Log($"{baseLifeCycleManagerType.Name} ���ֵ��в�����");
        }
    }

    /// <summary>
    /// ��Ӽ�������ָ�����͵����������¼���������
    /// </summary>
    /// <typeparam name="T">Ҫ��Ӽ����������������¼������������͡�</typeparam>
    /// <param name="listener">Ҫ��ӵļ�������</param>
    public void AddBaseLifeCycleManagerListener<T>(UnityAction listener) where T : BaseLifeCycleManager
    {
        Type baseLifeCycleManagerType = typeof(T);

        if (baseLifeCycleManagerDictionary.TryGetValue(baseLifeCycleManagerType, out BaseLifeCycleManager manager))
        {
            // �������������¼��������ķ�������Ӽ�������
            manager.AddListener(listener);
        }
        else
        {
            Debug.Log($"{baseLifeCycleManagerType.Name} ���ֵ��в�����");
        }
    }

    /// <summary>
    /// ��ָ�����͵����������¼����������Ƴ���������
    /// </summary>
    /// <typeparam name="T">Ҫ�Ƴ������������������¼������������͡�</typeparam>
    /// <param name="listener">Ҫ�Ƴ��ļ�������</param>
    public void RemoveBaseLifeCycleManagerListener<T>(UnityAction listener) where T : BaseLifeCycleManager
    {
        Type baseLifeCycleManagerType = typeof(T);

        if (baseLifeCycleManagerDictionary.TryGetValue(baseLifeCycleManagerType, out BaseLifeCycleManager manager))
        {
            // �������������¼��������ķ������Ƴ���������
            manager.RemoveListener(listener);
        }
        else
        {
            Debug.Log($"{baseLifeCycleManagerType.Name} ���ֵ��в�����");
        }
    }

    public Coroutine StartBaseCoroutine(IEnumerator routine)
    {
        return baseCoroutineManager.StartCoroutine(routine);
    }

    public void StopBaseCoroutine(IEnumerator routine)
    {
        baseCoroutineManager.StopCoroutine(routine);
    }

    public void StopBaseCoroutine(Coroutine routine)
    {
        baseCoroutineManager.StopCoroutine(routine);
    }
}
