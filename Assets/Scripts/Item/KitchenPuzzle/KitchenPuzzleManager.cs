using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPuzzleManager : MonoBehaviour
{
    public int requiredObjectCount = 4; // �ʿ��� ������Ʈ ����
    public int currentObjectCount = 0; // ���� ������ ������Ʈ ����
    private bool isUnlocked = false; // �ر� ���θ� Ȯ���ϴ� ����

    private void Update()
    {
            if (currentObjectCount >= requiredObjectCount && !isUnlocked)
            {
                escape();
            }     
    }

    void escape()
    {
        isUnlocked = true;
        
        // �߰����� �ر� ������ ���⿡ �߰��� �� �ֽ��ϴ�.
        Debug.Log("All objects are created. Object unlocked!");
    }
}