using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// ��Դ����������
public class BaseResourceManager : BaseSingletonInCSharp<BaseResourceManager>
{
    // ͬ��������Դ
    public T Load<T>(string resourcePath) where T : Object
    {
        T resource = Resources.Load<T>(resourcePath);

        // ���������һ��GameObject���͵ģ�ʵ�����󷵻�
        if (resource is GameObject)
        {
            return GameObject.Instantiate(resource);
        }
        else
        {
            return resource;
        }
    }

    // �첽������Դ
    public void LoadAsync<T>(string resourcePath, UnityAction<T> callback) where T : Object
    {
        BaseMonoBehaviourManager.Instance.StartBaseCoroutine(LoadAsyncCoroutine(resourcePath, callback));
    }

    // Э�̺����������첽������Դ
    private IEnumerator LoadAsyncCoroutine<T>(string resourcePath, UnityAction<T> callback) where T : Object
    {
        ResourceRequest resourceRequest = Resources.LoadAsync<T>(resourcePath);
        yield return resourceRequest;

        T resource;

        if (resourceRequest.asset is GameObject)
        {
            resource = GameObject.Instantiate(resourceRequest.asset) as T;
        }
        else
        {
            resource = resourceRequest.asset as T;
        }

        // ִ�лص�����
        callback?.Invoke(resource);
    }
}
