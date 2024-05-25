using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : InteractiveItem
{
    public Text lockedText;
    public DoorManager door;
    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        lockedText.gameObject.SetActive(false); 
    }
    public override void onClick()
    {
        if(door.keyobtained == 1) // Ű�� ������������
        {
            SceneManager.LoadScene("Stage2");
            // �κ��丮���� ���� �ı�
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
