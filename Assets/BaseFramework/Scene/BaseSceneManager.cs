using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// ������������ص��ࡣ
/// </summary>
public class BaseSceneManager : BaseSingletonInCSharp<BaseSceneManager>
{
    /// <summary>
    /// ͬ�����س��������ڼ�����ɺ�ִ�лص���
    /// </summary>
    /// <param name="sceneName">Ҫ���صĳ������ơ�</param>
    /// <param name="callback">������ɺ�ִ�еĻص�������</param>
    public void LoadScene(string sceneName, UnityAction callback)
    {
        // ʹ��SceneManager���س���
        SceneManager.LoadScene(sceneName);

        // ����ص���Ϊnull������ûص�
        callback?.Invoke();
    }

    /// <summary>
    /// �첽���س��������ڼ�����ɺ�ִ�лص���
    /// </summary>
    /// <param name="sceneName">Ҫ���صĳ������ơ�</param>
    /// <param name="callback">������ɺ�ִ�еĻص�������</param>
    public void LoadSceneAsyn(string sceneName, UnityAction callback)
    {
        // ʹ��Э�����첽���س���
        BaseMonoBehaviourManager.Instance.StartBaseCoroutine(ReallyLoadSceneAsyn(sceneName, callback));
    }

    /// <summary>
    /// Э�̺����������첽���س��������ڼ�����ɺ�ִ�лص���
    /// </summary>
    /// <param name="sceneName">Ҫ���صĳ������ơ�</param>
    /// <param name="callback">������ɺ�ִ�еĻص�������</param>
    private IEnumerator ReallyLoadSceneAsyn(string sceneName, UnityAction callback)
    {
        // �첽���س������������ز�������asyncOperation
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // ���첽�������ǰ�ȴ�
        while (!asyncOperation.isDone)
        {
            // ���ؼ��ؽ��ȣ�����������ʾ��������
            yield return asyncOperation;
        }

        // ����ص���Ϊnull������ûص�
        callback?.Invoke();
    }
}
