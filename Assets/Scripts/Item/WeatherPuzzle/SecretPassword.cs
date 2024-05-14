using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SecretPassword : MonoBehaviour
{
    public Text lockedText1;
    public Text lockedText2;
    public Text lockedText3;
    private WeatherPuzzleManager weatherPuzzleManager;
    public int unlocked = 0;

    // �ùٸ� ���� �迭
    private int[] correctSequence = {1, 2, 3, 4};

    // ������� �Էµ� ��ư���� ID�� �����ϴ� �迭
    private int[] inputSequence = new int[4];
    private int currentIndex = 0; // ���� �Էµ� ��ư�� �ε���


    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        lockedText1.gameObject.SetActive(false);
        lockedText2.gameObject.SetActive(false);
        lockedText3.gameObject.SetActive(false);
        weatherPuzzleManager = FindObjectOfType<WeatherPuzzleManager>();

    }

    private void HideText()
    {
        lockedText1.gameObject.SetActive(false);
        lockedText2.gameObject.SetActive(false);
        lockedText3.gameObject.SetActive(false);
    }

    // ��ư�� ������ �� ȣ��Ǵ� �Լ�
    public void OnButtonPressed(int btnId)
    {
        // ���� �Էµ� ��ư�� ID�� �迭�� ����
        if (unlocked == 0)
        {
            inputSequence[currentIndex] = btnId;
            currentIndex++;


            if (currentIndex == 4)
            {
                if (IsInputSequenceCorrect())
                {
                    Unlock();
                    return;
                }
                // �Է��� �߸��Ǿ��� ���� ������ �ʱ�ȭ
                currentIndex = 0;
                Debug.Log("set 0");
                // �ؽ�Ʈ�� Ȱ��ȭ�Ͽ� ���ڸ� ���� ���Ѵٴ� �޽����� ǥ��
                lockedText1.gameObject.SetActive(true);
                // 2�� �Ŀ� ��Ȱ��ȭ�ǵ��� Invoke() ȣ��
                Invoke("HideText", 2.0f);
            }
        }
        else if (unlocked == 1)
        {
            // �ؽ�Ʈ�� Ȱ��ȭ�Ͽ� ���ڸ� ���� ���Ѵٴ� �޽����� ǥ��
            lockedText3.gameObject.SetActive(true);
            // 2�� �Ŀ� ��Ȱ��ȭ�ǵ��� Invoke() ȣ��
            Invoke("HideText", 2.0f);
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

    // ��й�ȣ�� �ر��ϴ� �Լ�
    private void Unlock()
    {
        Debug.Log("Password unlocked!");
        lockedText2.gameObject.SetActive(true);
        Invoke("HideText", 2.0f);
        unlocked = 1;
    }
}