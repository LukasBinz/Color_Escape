using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ���� �Ŵ����� ���� �ν��Ͻ��� �����ϴ� �Ӽ�
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��� ���� ����
            if (_instance == null)
            {
                // ������ GameManager�� ã��
                _instance = FindObjectOfType<GameManager>();

                // ���� GameManager�� ���� ��� ���ο� ���� ������Ʈ�� �߰�
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

}