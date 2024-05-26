using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public GameObject[] panels; // ���� �Ŵ������� Ȱ��ȭ�Ǵ� �г� �迭

    float xRotation;
    float yRotation;

    private void Start()
    {
    }

    private void Update()
    {
        bool panelActive = false;

        // ��� �г��� ��ȸ�ϸ� Ȱ��ȭ ���� Ȯ��
        foreach (GameObject panel in panels)
        {
            if (panel.activeSelf)
            {
                panelActive = true;
                break;
            }
        }

        // �г��� Ȱ��ȭ�Ǿ� �ִ� ��쿡�� ���콺 �Է��� ���� ����
        if (panelActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
     

        // ���콺 �Է� �ޱ�
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // Y �� ȸ�� ���
        yRotation += mouseX;

        // X �� ȸ�� ��� �� ����
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);

        // ī�޶� �� ���� ��ȯ ȸ�� ����
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}