using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenguinResetBtn : InteractiveItem
{
    private bool isMoving = false;

    public override void onClick()
    {
        press();
        GameOver();

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

    void GameOver()
    {
        // ���ӿ��� �޽��� ���
        Debug.Log("Game Over!");

        // �� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
