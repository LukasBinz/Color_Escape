using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingObstacle : InteractiveItem
{
    public int requiredFlashlightColor; // ������� ���� �ʿ��� ������ ���� �ε���


    void Start()
    {
      
    }

    public void lightFlashed(int flashLightColor)
    {
        if (flashLightColor == requiredFlashlightColor) // Ư�� ���� ������ ���� ���̵� �ƿ� ����
        {
            gameObject.SetActive(false);
        }
    }

   
}