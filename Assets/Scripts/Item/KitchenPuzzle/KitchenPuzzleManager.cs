using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KitchenPuzzleManager : MonoBehaviour
{
    public int requiredObjectCount = 4; // �ʿ��� ������Ʈ ����
    public int currentObjectCount = 0; // ���� ������ ������Ʈ ����
    private int isUnlocked = 0; // �ر� ���θ� Ȯ���ϴ� ����

    public string tagToDestroy = "PlaceableObject";

    public Text failText;
    public Text escapeText;

    public GameObject EndPanel;

    private int[] correctSequence = { 0, 1, 2, 3 };

    // ������� �Էµ� ��ư���� ID�� �����ϴ� �迭
    private int[] inputSequence = new int[4];
    private int currentIndex = 0; // ���� �Էµ� ��ư�� �ε���

    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        failText.gameObject.SetActive(false);
        escapeText.gameObject.SetActive(false);
        EndPanel.SetActive(false);

    }

    private void HideText()
    {
        failText.gameObject.SetActive(false);
        escapeText.gameObject.SetActive(false);
    }


    // place �޼ҵ带 ���� ������ ��� ���� ������Ʈ ����
    public void DestroyObjects()
    {
        // ������ �±׸� ���� ��� ���� ������Ʈ�� ã�Ƽ� �ı�
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToDestroy);
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
        // ���� ������ ������Ʈ �� �ʱ�ȭ
        currentObjectCount = 0;
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
        StartCoroutine(DisableTextAfterDelay(3.0f));

        // �߰����� �ر� ������ ���⿡ �߰��� �� �ֽ��ϴ�.
    }
    private IEnumerator DisableTextAfterDelay(float delay)
    {
        // delay �� ���� ���
        yield return new WaitForSeconds(delay);
        escapeText.gameObject.SetActive(false);
        AudioManager.Instance.PlaySFX("Button");
        EndPanel.SetActive(true);

    }

    public void CloseEndPanel()
    {
        // ���� â�� ����
        AudioManager.Instance.PlaySFX("Close");
        SceneManager.LoadScene("StartScene");
    }


}