using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : InteractiveItem
{
    public Text lockedText;
    public int keyItemId;


    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        lockedText.gameObject.SetActive(false); 
    }
    public override void onClick()
    {
        if (InventoryManager.Instance.HasItem(keyItemId)) // Ű�� ������������
        {
            AudioManager.Instance.PlaySFX("Door");
            SceneManager.LoadScene("Stage2");
          
        }
        else
        {
            lockedText.gameObject.SetActive(true);
            Invoke("HideText", 2.0f);
        }
    }

    private void HideText()
    {
        lockedText.gameObject.SetActive(false);
    }

}
