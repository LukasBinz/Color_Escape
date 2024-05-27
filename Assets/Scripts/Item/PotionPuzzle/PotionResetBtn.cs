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

    private bool isMoving = false;
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
        if (!isMoving)
        {
            // ���� ��ġ�� �����մϴ�.
            Vector3 currentPosition = transform.position;

            // ��ǥ ��ġ�� ����մϴ�.
            Vector3 targetPosition = currentPosition + transform.up * 0.05f;

            // ������Ʈ�� �̵���Ű�� �ڷ�ƾ�� �����մϴ�.
            StartCoroutine(MoveObject(currentPosition, targetPosition, 0.05f));
        }
    }

    // ������Ʈ�� �̵���Ű�� �ڷ�ƾ �Լ�
    private IEnumerator MoveObject(Vector3 startPos, Vector3 endPos, float duration)
    {
        isMoving = true;  // �̵� ����

        float elapsedTime = 0;

        // ��ǥ ��ġ�� �̵�
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // ��ǥ ��ġ�� ��Ȯ�� �����ϵ��� ����
        transform.position = endPos;

        // ���� ��ġ�� ���ư��� ���� ��� ��� (���ϴ� ���)
        yield return new WaitForSeconds(0.1f);

        elapsedTime = 0;

        // ���� ��ġ�� �̵�
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(endPos, startPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // ���� ��ġ�� ��Ȯ�� �����ϵ��� ����
        transform.position = startPos;

        isMoving = false;  // �̵� ����
    }
}
