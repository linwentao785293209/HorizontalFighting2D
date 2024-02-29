/// <summary>
/// BaseLifeCycleLateUpdateManager �̳��� BaseLifeCycleManager �࣬���ڹ��� LateUpdate ���������¼���
/// </summary>
public class BaseLifeCycleLateUpdateManager : BaseLifeCycleManager
{
    // Unity �� LateUpdate ��������ÿһ֡�������ã�������д������
    private void LateUpdate()
    {
        // ���û���� InvokeEvent ���������� LateUpdate ���������¼���
        // ���֪ͨ���ж������¼��ļ��������Ա�ִ���� LateUpdate ����������صĲ�����
        InvokeEvent();
    }
}
