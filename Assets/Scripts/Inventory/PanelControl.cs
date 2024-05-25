using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelControl : MonoBehaviour

{
    public GameObject inventoryPanel; // �κ��丮 �г��� GameObject

    void Start()
    {
        // ���� �ÿ��� �κ��丮 �г��� ��Ȱ��ȭ�մϴ�.
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        // I Ű�� ������ �κ��丮 �г��� Ȱ��ȭ/��Ȱ��ȭ ���¸� �����մϴ�.
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(true);
        }
    }

    public void CloseInventory()
    {
        // ���� â�� ����
        inventoryPanel.SetActive(false);
    }



}
