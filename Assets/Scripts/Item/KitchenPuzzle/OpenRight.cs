using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRight : InteractiveItem
{

    private bool isRotated = false;
 
    public override void onClick()
    {
        open();
        AudioManager.Instance.PlaySFX("Open Lid");
    }
    public override void open()
    {
        // ���� ȸ���� �����մϴ�.
        Quaternion currentRotation = transform.rotation;

        // ��ǥ ȸ���� ����մϴ�. ȸ�� ���¿� ���� �ٸ��� �����մϴ�.
        Quaternion targetRotation;
        if (isRotated)
        {
            // ���� ȸ���� ���¶�� 0���� �ǵ����ϴ�.
            targetRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            // ���� ȸ������ ���� ���¶�� ȸ����ŵ�ϴ�.
            targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, -145, 0));
        }

        // ������Ʈ�� ȸ����Ű�� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(RotateObject(currentRotation, targetRotation, 0.5f)); // ȸ�� �ð��� 0.5�ʷ� ����

        // ȸ�� ���¸� �ݴ�� ��ȯ�մϴ�.
        isRotated = !isRotated;
    }

    // ������Ʈ�� ȸ����Ű�� �ڷ�ƾ �Լ�
    private IEnumerator RotateObject(Quaternion startRot, Quaternion endRot, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRot, endRot, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ������ ��ġ�� ��Ȯ�� ���߱� ���� ������ ���� �� ���� ��ġ�� ����
        transform.rotation = endRot;
    }
}
