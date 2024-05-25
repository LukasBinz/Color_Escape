using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimChanger2and3 : MonoBehaviour
{

    public Image canvasImage; // ĵ���� �̹����� �����ϱ� ���� ����
    private Sprite originalSprite;
    public Text text; // "E"Ű�� ������ ��ȣ�ۿ��� �� �ִٴ� ����
   

    void Start()
    {
        // ĵ���� �̹����� ���� ��������Ʈ�� �����մϴ�.
        originalSprite = canvasImage.sprite;
        text.enabled = false;



    }
    void Update()
    {

        // �÷��̾ �ٶ󺸰� �ִ� �������� ������ ���ϴ�.
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        // ������ � ��ü�� �浹�ϴ��� üũ�մϴ�.
        if (Physics.Raycast(ray, out hitInfo, 10f))
        {

            GameObject hitObject = hitInfo.collider.gameObject;
            InteractiveItem hoveredItem = hitObject.GetComponent<InteractiveItem>();

            if (hoveredItem != null)
            {
                if (canvasImage != null)
                {

                        text.enabled = true;
                 
                    Sprite yourNewSprite = Resources.Load<Sprite>("RedAim");

                    if (yourNewSprite != null)
                    {
                        canvasImage.sprite = yourNewSprite;
                    }
                }


            }
            else
            {
                // ��ȣ�ۿ� ������ ��ü�� �ƴ� ��� ������ �̹�����
                canvasImage.sprite = originalSprite;
                text.enabled = false;
      
            }
        }
    }
}
