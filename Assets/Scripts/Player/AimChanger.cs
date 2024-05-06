using UnityEngine;
using UnityEngine.UI;

public class AimChanger: MonoBehaviour
{

    public Image canvasImage; // ĵ���� �̹����� �����ϱ� ���� ����
    private Sprite originalSprite;

    void Start()
    {
        // ĵ���� �̹����� ���� ��������Ʈ�� �����մϴ�.
        originalSprite = canvasImage.sprite;
    }
    void Update()
    {

        // �÷��̾ �ٶ󺸰� �ִ� �������� ������ ���ϴ�.
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        // ������ � ��ü�� �浹�ϴ��� üũ�մϴ�.
        if (Physics.Raycast(ray, out hitInfo, 50f))
        {
            // �浹�� ��ü�� �̸��� Debug.Log�� ����մϴ�.
            GameObject hitObject = hitInfo.collider.gameObject;


            InteractiveItem clickedItem = hitObject.GetComponent<InteractiveItem>();
            if (clickedItem != null)
            {
                // ��ȣ�ۿ� ������ ��ü�� ��� canvas �̹����� �����մϴ�.
                if (canvasImage != null)
                {
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
            }
        }
    }   
}
