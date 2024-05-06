using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    void Update()
    {
        // E Ű�� ������ ���� ����ĳ��Ʈ�� �߻��մϴ�.
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �÷��̾ �ٶ󺸰� �ִ� �������� ������ ���ϴ�.
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;

            // ������ � ��ü�� �浹�ϴ��� üũ�մϴ�.
            if (Physics.Raycast(ray, out hitInfo, 50f))
            {
                // �浹�� ��ü�� �̸��� Debug.Log�� ����մϴ�.
                Debug.Log("Hit object: " + hitInfo.collider.gameObject.name);
                GameObject hitObject = hitInfo.collider.gameObject;

                // ������ ȹ�� ������ ������Ʈ���� Ȯ���մϴ�.
                InteractiveItem clickedItem = hitObject.GetComponent<InteractiveItem>();
                if (clickedItem != null)
                {
                    clickedItem.onClick();
                }

            }
        }
    }
}