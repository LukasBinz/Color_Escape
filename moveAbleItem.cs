using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAbleItem : MonoBehaviour
{
    public float moveSpeed = 1f; // �̵� �ӵ�
    private bool isMoving = false; // �̵� ���θ� Ȯ���ϴ� �÷���
    private Rigidbody rb; // Rigidbody ������Ʈ�� �����ϱ� ���� ����


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ����
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
    }
}
