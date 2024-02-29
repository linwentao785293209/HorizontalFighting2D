// ����Unity����������ռ�
using UnityEngine;

// ����һ�������� BaseSingletonInMonoBehaviour<T>
// �����̳���MonoBehaviour�����Ͳ��� T ������MonoBehaviour��������
public class BaseSingletonInMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    // ��̬�ֶ����ڴ洢����ʵ��
    private static T instance;

    // ������̬���ԣ����ڻ�ȡ����ʵ��
    public static T Instance
    {
        get
        {
            // ���ʵ����δ����
            if (instance == null)
            {
                // �����ڳ����в��Ҿ������� T �Ķ���
                instance = FindObjectOfType<T>();

                // ����ڳ������Ҳ��������͵Ķ���
                if (instance == null)
                {
                    // ����һ���µĿ���Ϸ����
                    GameObject gameObject = new GameObject();

                    // ���´�������Ϸ�������һ������Ϊ T ������������丳ֵ�� instance
                    instance = gameObject.AddComponent<T>();

                    // ������Ϸ���������Ϊ���� T ������
                    gameObject.name = typeof(T).ToString();

                    // ��Ҫ�ڳ����л�ʱ���������Ϸ����
                    DontDestroyOnLoad(gameObject);
                }
            }

            // ���ص���ʵ��
            return instance;
        }
    }

    // Awake �����ڶ���ʵ��������ʱ����
    protected virtual void Awake()
    {
        // �������ʵ����δ����
        if (instance == null)
        {
            // ����ǰ����ʵ����ֵ�� instance
            instance = this as T;

            // ��Ҫ�ڳ����л�ʱ���ٸö���
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // �������ʵ���Ѵ��ڣ������ٵ�ǰ����
            Destroy(this);
        }
    }
}
