using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenPuzzleManager : MonoBehaviour
{
    public int requiredObjectCount = 4; // �ʿ��� ������Ʈ ����
    public int currentObjectCount = 0; // ���� ������ ������Ʈ ����
    private int isUnlocked = 0; // �ر� ���θ� Ȯ���ϴ� ����

    public GameObject[] objectsToReset;

    public Text failText;
    public Text escapeText;

    private int[] correctSequence = { 0, 1, 2, 3 };

    // ������� �Էµ� ��ư���� ID�� �����ϴ� �迭
    private int[] inputSequence = new int[4];
    private int currentIndex = 0; // ���� �Էµ� ��ư�� �ε���

    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        failText.gameObject.SetActive(false);
        escapeText.gameObject.SetActive(false);

    }

    private void HideText()
    {
        failText.gameObject.SetActive(false);
        escapeText.gameObject.SetActive(false);
    }


    public void OnFoodPlaced(int foodOrder)
    {
        // ���� �Էµ� ��ư�� ID�� �迭�� ����
        if (isUnlocked == 0)
        {
            inputSequence[currentIndex] = foodOrder;
            Debug.Log(foodOrder);
            currentIndex++;


            if (currentIndex == 4)
            {
                if (IsInputSequenceCorrect())
                {
                    isUnlocked = 1;
                    escape();
                    return;
                }
                // �Է��� �߸��Ǿ��� ���� ������ �ʱ�ȭ
                currentIndex = 0;
                Debug.Log("set 0");
                failText.gameObject.SetActive(true);
                // 2�� �Ŀ� ��Ȱ��ȭ�ǵ��� Invoke() ȣ��
                Invoke("HideText", 2.0f);
               
                foreach (GameObject obj in objectsToReset)
                {
                    // ��ü�� �����ϱ�

                }
                // �κ��丮�� ������� ��ü�� �ٽ� �ֱ�


            }
        }
    }

    // �Էµ� �������� �ùٸ� ��й�ȣ�� ��ġ�ϴ��� Ȯ���ϴ� �Լ�
    private bool IsInputSequenceCorrect()
    {
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (inputSequence[i] != correctSequence[i])
            {
                return false;
            }
        }
        return true;
    }

  

    void escape()
    {
        escapeText.gameObject.SetActive(true);
        Invoke("HideText", 4.0f);
        // �߰����� �ر� ������ ���⿡ �߰��� �� �ֽ��ϴ�.
        Debug.Log("All objects are created. Object unlocked!");
    }
}