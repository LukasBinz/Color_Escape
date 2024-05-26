using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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
            AudioManager.Instance.PlaySFX("inventory");
            inventoryPanel.SetActive(true);
            InventoryManager.Instance.ListItems();
        }
    }

    public void CloseInventory()
    {
        // ���� â�� ����
        AudioManager.Instance.PlaySFX("Close");
        inventoryPanel.SetActive(false);
    }



}
