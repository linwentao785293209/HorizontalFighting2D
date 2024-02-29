using UnityEngine.Events;

// �¼��������ӿ�
public interface IBaseEventListener
{

}

// �����¼�������
public class BaseEventListener<T> : IBaseEventListener
{
    public UnityAction<T> actions; // �洢�¼���ί�к���

    // ���캯������������¼�������
    public BaseEventListener(UnityAction<T> action)
    {
        actions += action; // ����¼�������
    }
}

// �Ƿ����¼�������
public class BaseEventListener : IBaseEventListener
{
    public UnityAction actions; // �洢�¼���ί�к���

    // ���캯������������¼�������
    public BaseEventListener(UnityAction action)
    {
        actions += action; // ����¼�������
    }
}