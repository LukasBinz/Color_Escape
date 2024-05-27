using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveAbleItem : InteractiveItem
{
    public float moveSpeed = 1f; // �̵� �ӵ�
    private bool isMoving = false; // �̵� ���θ� Ȯ���ϴ� �÷���
    private Rigidbody rb; // Rigidbody ������Ʈ�� �����ϱ� ���� ����
    private Vector3 startPosition;
    private Quaternion startRotation;

    private bool isRotated = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ����
        startPosition = rb.position; // ���� ��ġ ����
        startRotation = rb.rotation;

  
            int playerLayer = LayerMask.NameToLayer("Default");
            int targetLayer = LayerMask.NameToLayer("penguin");

            // PlayerLayer�� TargetLayer ���� �浹�� �����մϴ�.
            Physics.IgnoreLayerCollision(playerLayer, targetLayer);
        
    }



    // �������� ���� �����ϴ� �Լ�
    public void lightFlashed(int flashLightColor)
    {
        if (flashLightColor == 3) //�ʷϻ� ���̸� �̵�
        {
            isMoving = true;
        }
        else if (flashLightColor == 2) //������ ���̸� ����
        {
            isMoving = false;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        // Rigidbody�� ����Ͽ� �̵�
        Vector3 newPosition = rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    // �浹 ���� �Լ�
    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� "CheckPoint" ���̾ ���� �ִ��� Ȯ��
        if (collision.gameObject.layer == LayerMask.NameToLayer("CheckPoint"))
        {
            // �������� 90�� ȸ��
            transform.Rotate(0, -90, 0);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("impediments"))
        {
            // ���ع��� �浹 �� ���ӿ��� ó��
            GameOver();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Escape"))
        {
            AudioManager.Instance.PlaySFX("Open Lid");
            open();
            SceneManager.LoadScene("Stage3");
        }

    }
    void GameOver()
    {
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

        if (rb != null)
        {
            // ������ ������Ʈ�� ���� ��ġ�� ������ �ǵ�����
            rb.position = startPosition;
            rb.rotation = startRotation;
            rb.velocity = Vector3.zero; // ������Ʈ�� �ӵ��� �ʱ�ȭ
            rb.angularVelocity = Vector3.zero; // ������Ʈ�� ���ӵ��� �ʱ�ȭ
        }

        // �̵� ���� �ʱ�ȭ
        isMoving = false;
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

    public override void open()
    {
        Quaternion currentRotation = transform.rotation;

        Quaternion targetRotation;
        if (isRotated)
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, -90, 0));
        }

        StartCoroutine(RotateObject(currentRotation, targetRotation, 0.5f));

        isRotated = !isRotated;
    }
    private IEnumerator RotateObject(Quaternion startRot, Quaternion endRot, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRot, endRot, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRot;
    }

}

