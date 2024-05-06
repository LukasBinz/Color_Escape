using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flashlight : MonoBehaviour
{

    Light light;
    public int flashLightColor = 0;


    // ������, �ʷϻ�, �Ķ����� ������� ������ �迭
    Color[] colors = { Color.clear, Color.red, Color.green, Color.blue };

    // ������ �� 1 : None, 2 : R, 3 : G, 0 : B

    void Start()
    {
        light = GetComponent<Light>();

        ChangeLightColor();
    }

    // ������ �����ϴ� �Լ�
    void ChangeLightColor()
    {
        // ���� �ε����� �ش��ϴ� �������� ����
        light.color = colors[flashLightColor];
        // ������ ����� ���� �ε��� ������Ʈ
        flashLightColor = (flashLightColor + 1) % colors.Length;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeLightColor();
            Debug.Log("���" + flashLightColor);
            
        }
        
        
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;

            // ������ � ��ü�� �浹�ϴ��� üũ�մϴ�.
            if (Physics.Raycast(ray, out hitInfo, 5f))
            {
                //Debug.Log("Flashlight Hit object: " + hitInfo.collider.gameObject.name);
                GameObject hitObject = hitInfo.collider.gameObject;
                InteractiveItem flahsedObject = hitObject.GetComponent<InteractiveItem>();

                if (flahsedObject != null)
                {
                    flahsedObject.lightFlashed(flashLightColor);
                }

            }
        
    }
}





