using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestLid : InteractiveItem
{
    public Password check;
    private bool isOpen = false;
    private bool isAnimating = false; // �ִϸ��̼��� ���� ������ ���θ� ��Ÿ���� �÷���
    private float duration = 2.0f; // ������ �ð� (��)


    // ���ڸ� ���� ���� �� ǥ���� �ؽ�Ʈ UI ���
    public Text lockedText;

    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        lockedText.gameObject.SetActive(false);
    }

    public override void onClick()
    {
        // �ٸ� ������������ ���� �ر��� �̷������쿡�� ����
        if (!isAnimating && check.unlocked == 1)
        {
            StartCoroutine(AnimateOpen());
            return;
        }
        else if (check.unlocked == 0)
        {
            // �ؽ�Ʈ�� Ȱ��ȭ�Ͽ� ���ڸ� ���� ���Ѵٴ� �޽����� ǥ��
            lockedText.gameObject.SetActive(true);
            // 2�� �Ŀ� ��Ȱ��ȭ�ǵ��� Invoke() ȣ��
            Invoke("HideText", 2.0f);
        }
    }

    // �ؽ�Ʈ�� ����� �޼���
    private void HideText()
    {
        lockedText.gameObject.SetActive(false);
    }

    private IEnumerator AnimateOpen()
    {
        isAnimating = true; // �ִϸ��̼��� ���� ������ ǥ��
        float timer = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if (!isOpen)
        {
            endRotation = Quaternion.Euler(60, 0, 0) * startRotation;
        }
        else
        {
            endRotation = Quaternion.Euler(-60, 0, 0) * startRotation;
        }

        while (timer < duration)
        {
            float progress = timer / duration;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, progress);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isOpen = !isOpen;
        isAnimating = false; // �ִϸ��̼��� ����Ǿ����� ǥ��
    }
}