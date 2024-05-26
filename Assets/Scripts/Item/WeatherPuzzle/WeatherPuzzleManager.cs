using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherPuzzleManager : MonoBehaviour
{
    public int unlocked = 0;
    public int neededItemId;

    public Text lockedText;
    private bool isTextShown = false; // �ؽ�Ʈ�� �� �� ��Ÿ������ Ȯ���ϱ� ���� ����

    private void Start()
    {
        lockedText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // �κ��丮�� �ʿ��� �������� �ִ��� Ȯ��
        CheckFor();
    }

    public void CheckFor()
    {
        // InventoryManager�� Instance�� ���� �κ��丮�� ���谡 �ִ��� Ȯ��
        if (InventoryManager.Instance.HasItem(neededItemId) && unlocked == 0)
        {
            unlocked = 1;
            ShowText();
        }
    }

    private void ShowText()
    {
        if (!isTextShown)
        {
            lockedText.gameObject.SetActive(true);
            isTextShown = true;
            Invoke("HideText", 2.0f);
        }
    }

    private void HideText()
    {
        lockedText.gameObject.SetActive(false);
    }
}
