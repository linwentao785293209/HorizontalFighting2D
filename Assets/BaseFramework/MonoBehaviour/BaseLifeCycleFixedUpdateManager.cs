/// <summary>
/// BaseLifeCycleFixedUpdateManager �̳��� BaseLifeCycleManager �࣬���ڹ��� FixedUpdate ���������¼���
/// </summary>
public class BaseLifeCycleFixedUpdateManager : BaseLifeCycleManager
{
    // Unity �� FixedUpdate �������ڹ̶���ʱ�����ڵ��ã�������д������
    private void FixedUpdate()
    {
        // ���û���� InvokeEvent ���������� FixedUpdate ���������¼���
        // ���֪ͨ���ж������¼��ļ��������Ա�ִ���� FixedUpdate ����������صĲ�����
        InvokeEvent();
    }
}
