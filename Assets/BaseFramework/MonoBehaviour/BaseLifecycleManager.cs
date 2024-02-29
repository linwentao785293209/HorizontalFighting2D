using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// BaseLifeCycleManager ��һ�����ڹ������������¼��Ļ��ࡣ
/// </summary>
public class BaseLifeCycleManager : MonoBehaviour
{
    private event UnityAction lifeCycleEvent; // ����һ�� UnityAction ���͵��¼���

    /// <summary>
    /// �������������¼���
    /// </summary>
    public void InvokeEvent()
    {
        lifeCycleEvent?.Invoke(); // ������������¼���Ϊ�գ��򴥷�����
    }

    /// <summary>
    /// ��Ӽ����������������¼���
    /// </summary>
    /// <param name="listener">Ҫ��ӵļ�������</param>
    public void AddListener(UnityAction listener)
    {
        if (listener != null) // ���������Ƿ�Ϊ�ǿա�
        {
            lifeCycleEvent += listener; // �����������¼���Ӽ�������
        }
    }

    /// <summary>
    /// �����������¼����Ƴ���������
    /// </summary>
    /// <param name="listener">Ҫ�Ƴ��ļ�������</param>
    public void RemoveListener(UnityAction listener)
    {
        if (listener != null) // ���������Ƿ�Ϊ�ǿա�
        {
            lifeCycleEvent -= listener; // �����������¼����Ƴ���������
        }
    }

    /// <summary>
    /// ����������ʱ���Ƴ����м������Է�ֹ�ڴ�й©��
    /// </summary>
    private void OnDestroy()
    {
        lifeCycleEvent = null; // ������������¼������ͷŶԼ����������á�
    }
}
