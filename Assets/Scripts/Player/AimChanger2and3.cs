using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimChanger2and3 : MonoBehaviour
{

    public Image canvasImage; // 캔버스 이미지를 참조하기 위한 변수
    private Sprite originalSprite;
    public Text text; // "E"키를 눌러서 상호작용할 수 있다는 내용
   

    void Start()
    {
        // 캔버스 이미지의 원래 스프라이트를 저장합니다.
        originalSprite = canvasImage.sprite;
        text.enabled = false;



    }
    void Update()
    {

        // 플레이어가 바라보고 있는 방향으로 광선을 쏩니다.
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        // 광선이 어떤 물체와 충돌하는지 체크합니다.
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
                // 상호작용 가능한 물체가 아닐 경우 원래의 이미지로
                canvasImage.sprite = originalSprite;
                text.enabled = false;
      
            }
        }
    }
}
