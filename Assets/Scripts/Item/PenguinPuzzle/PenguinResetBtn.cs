using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenguinResetBtn : InteractiveItem
{
    private bool isMoving = false;
    private bool PenguinIsMoving = false;

    private Rigidbody targetRb; // �ٸ� ���� ������Ʈ�� Rigidbody�� ������ ����
    private Vector3 startPosition; // ���� ��ġ�� �����ϴ� ����
    private Quaternion startRotation; // ���� ������ �����ϴ� ����

    void Start()
    {
        // ������Ʈ�� �̸��̳� �±׷� ã�Ƽ� ����
        GameObject targetObject = GameObject.Find("PENGUIN"); // �Ǵ� GameObject.FindWithTag("TargetTag");
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        if (targetObject != null)
        {
            targetRb = targetObject.GetComponent<Rigidbody>(); // ������ ������Ʈ�� Rigidbody ������Ʈ
            startPosition = targetRb.position; // ���� ��ġ ����
            startRotation = targetRb.rotation; // ���� ���� ����
        }
    }

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

        List<GameObject> obstacles = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] rootObjects = scene.GetRootGameObjects();

        foreach (GameObject rootObject in rootObjects)
        {
            obstacles.AddRange(FindGameObjectsWithTagInChildren(rootObject, "Obstacle"));
        }

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.SetActive(true);
        }

        if (targetRb != null)
        {
            // ������ ������Ʈ�� ���� ��ġ�� ������ �ǵ�����
            targetRb.position = startPosition;
            targetRb.rotation = startRotation;
            targetRb.velocity = Vector3.zero; // ������Ʈ�� �ӵ��� �ʱ�ȭ
            targetRb.angularVelocity = Vector3.zero; // ������Ʈ�� ���ӵ��� �ʱ�ȭ
        }

        // �̵� ���� �ʱ�ȭ
        PenguinIsMoving = false;
    }

    private IEnumerable<GameObject> FindGameObjectsWithTagInChildren(GameObject parent, string tag)
    {
        List<GameObject> taggedObjects = new List<GameObject>();

        if (parent.CompareTag(tag))
        {
            taggedObjects.Add(parent);
        }

        foreach (Transform child in parent.transform)
        {
            taggedObjects.AddRange(FindGameObjectsWithTagInChildren(child.gameObject, tag));
        }

        return taggedObjects;
    }
}

