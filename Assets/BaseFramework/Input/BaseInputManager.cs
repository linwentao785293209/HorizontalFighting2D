using UnityEngine;
using UnityEngine.Events;

// ���������
public class BaseInputManager : BaseSingletonInCSharp<BaseInputManager>
{
    //�Ƿ���������
    private bool isCheckInput = false;

    // ���캯������ BaseMonoBehaviourManager �� OnUpdate �����������
    public BaseInputManager()
    {
        BaseMonoBehaviourManager.Instance.AddBaseLifeCycleManagerListener<BaseLifeCycleUpdateManager>(OnUpdateCheckInput);
    }

    // �����Ƿ����������
    public void SetCheckInput(bool isCheckInput)
    {
        this.isCheckInput = isCheckInput;
    }

    // ��ÿһ֡�� OnUpdate �м������
    private void OnUpdateCheckInput()
    {
        if (!isCheckInput)
            return;


        // �������� KeyCode ö��ֵ
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                // ʹ���¼��������������������¼������� KeyCode
                BaseEventManager.Instance.EventTrigger<KeyCode>("OnGetKeyDown", keyCode);
            }
            else if (Input.GetKeyUp(keyCode))
            {
                // ʹ���¼���������������̧���¼������� KeyCode
                BaseEventManager.Instance.EventTrigger<KeyCode>("OnGetKeyUp", keyCode);
            }
        }

    }
}
