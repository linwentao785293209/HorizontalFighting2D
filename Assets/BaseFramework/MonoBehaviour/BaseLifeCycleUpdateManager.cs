/// <summary>
/// BaseLifeCycleUpdateManager �̳��� BaseLifeCycleManager �࣬���ڹ��� OnUpdate ���������¼���
/// </summary>
public class BaseLifeCycleUpdateManager : BaseLifeCycleManager
{
    // Unity �� OnUpdate ��������ÿһ֡���ã�������д������
    private void Update()
    {
        // ���û���� InvokeEvent �������������������¼���
        // ���֪ͨ���ж������¼��ļ��������Ա�ִ���� OnUpdate ����������صĲ�����
        InvokeEvent();
    }
}
