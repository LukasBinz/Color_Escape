using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionResetBtn : InteractiveItem 
{
    public RedFlask redFlask;
    public BlueFlask blueFlask;

    public Material[] newMaterials; // ���ο� Material �迭
    public GameObject[] objectsToUpdate; // Material�� ������ ���� ������Ʈ �迭

    void Start()
    {

        redFlask= FindObjectOfType<RedFlask>();
        blueFlask = FindObjectOfType<BlueFlask>();

        if (objectsToUpdate.Length != newMaterials.Length)
        {
            Debug.LogError("���� ������Ʈ�� ���ο� Material �迭�� ���̰� ��ġ���� �ʽ��ϴ�.");
            return;
        }
    }

    public override void onClick()
    {
        press();

        for (int i = 0; i < objectsToUpdate.Length; i++)
        {
            GameObject obj = objectsToUpdate[i];
            Material newMaterial = newMaterials[i];

            // ���� ������Ʈ�� Material�� ��ȿ�� ��쿡�� Material ����
            if (obj != null && newMaterial != null)
            {
                // ���� ������Ʈ�� Renderer ������Ʈ ��������
                Renderer renderer = obj.GetComponent<Renderer>();

                // Renderer ������Ʈ�� �����ϴ� ��� Material ����
                if (renderer != null)
                {
                    renderer.material = newMaterial;
                }
                else
                {
                    Debug.LogWarning("���� ������Ʈ�� Renderer ������Ʈ�� �����ϴ�: " + obj.name);
                }
            }
        }

        redFlask.potionColor = 0;
        blueFlask.potionColor = 1;
    }

    public override void press()
    {

        // ���� ��ġ�� �����մϴ�.
        Vector3 currentPosition = transform.position;

        // ��ǥ ��ġ�� ����մϴ�.
        Vector3 targetPosition = currentPosition + transform.up * 0.05f;

        // ������Ʈ�� �̵���Ű�� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(MoveObject(currentPosition, targetPosition, 0.05f));
    }

    // ������Ʈ�� �̵���Ű�� �ڷ�ƾ �Լ�
    private IEnumerator MoveObject(Vector3 startPos, Vector3 endPos, float duration)
    {
        // �̵� ������ ���θ� ��Ÿ���� ����
        bool moving = true;

        float elapsedTime = 0;

        while (elapsedTime < duration && moving)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �̵��� �Ϸ�Ǹ� �ٽ� ���� ��ġ�� �ǵ��ư��ϴ�.
        elapsedTime = 0;
        while (elapsedTime < duration && moving)
        {
            transform.position = Vector3.Lerp(endPos, startPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
