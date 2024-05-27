using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimChanger2 : MonoBehaviour
{

    public Image canvasImage; // ĵ���� �̹����� �����ϱ� ���� ����
    private Sprite originalSprite;
    public Text resetText; // "E"Ű�� ������ ��ȣ�ۿ��� �� �ִٴ� ����
    public Text penguinText;
   

    void Start()
    {
        // ĵ���� �̹����� ���� ��������Ʈ�� �����մϴ�.
        originalSprite = canvasImage.sprite;
        resetText.enabled = false;
        penguinText.enabled = false;

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
                    if (hitObject.name == "PENGUIN" || hitObject.name == "Wolf_Animated" || hitObject.name == "Shark_Animated" || hitObject.name == "Goat_Animated")
                    {
                        penguinText.enabled = true;
                    }
                    else
                    {
                        resetText.enabled = true;
                    }

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
                penguinText.enabled = false;
                resetText.enabled = false;

            }
        }
    }
}
