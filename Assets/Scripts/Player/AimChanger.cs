using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimChanger: MonoBehaviour
{

    public Image canvasImage; // ĵ���� �̹����� �����ϱ� ���� ����
    private Sprite originalSprite;
    public Text text; // "E"Ű�� ������ ��ȣ�ۿ��� �� �ִٴ� ����
    public Text lightText; // "F"Ű�� ������ ��ȣ�ۿ��� �� �ִٴ� ����
    public Text resetText; // "E"Ű�� ������ ������ �� �ִٴ� ����
    public Text unlockText; // ���� ��ȣ�ۿ��� �� �� ���ٴ� ����
    public WeatherPuzzleManager puzzle;

    void Start()
    {
        // ĵ���� �̹����� ���� ��������Ʈ�� �����մϴ�.
        originalSprite = canvasImage.sprite;
        text.enabled = false;
        lightText.enabled = false;
        resetText.enabled = false;
        unlockText.enabled = false;

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

                    if (hitObject.name == "Blue Potion" || hitObject.name == "Red Potion")
                    {
                        lightText.enabled = true;
                    }
                    else if (hitObject.name == "ResetBtn")
                    {
                        resetText.enabled = true;
                    }
                    else if (hitObject.name == "SpringBtn" || hitObject.name == "SummerBtn" || hitObject.name == "FallBtn" || hitObject.name == "WinterBtn")
                    {
                        if(puzzle.unlocked == 0)
                        {
                            unlockText.enabled = true;
                        }
                        else
                        {
                            lightText.enabled = true;
                        }
                    }
                    else
                    {
                        text.enabled = true;
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
                // ��ȣ�ۿ� ������ ��ü�� �ƴ� ��� ������ �̹����� �����մϴ�.
                canvasImage.sprite = originalSprite;
                text.enabled = false;
                unlockText.enabled = false;
                lightText.enabled = false;
                resetText.enabled = false;

            }
        }
    }   
}
