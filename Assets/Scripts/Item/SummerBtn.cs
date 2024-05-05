using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerBtn : InteractiveItem
{
    // btnColor 0 : R, 1 : G, 2: B, 3: C, 4: M, 5: Y, 6: W

    public int btnColor = 1;
    public Flashlight flashlight;
    public Material CyanBtn;
    public Material YellowBtn;
    public Material WhiteBtn;


    public void makeCyan()
    {
        if (btnColor == 1)
        {
            changeColor(CyanBtn);
            btnColor = 3;
        }
    }
    public void makeYellow()
    {
        if (btnColor == 1)
        {
            changeColor(YellowBtn);
            btnColor = 5;
        }
    }
    public void makeWhite()
    {
        if (btnColor == 5 || btnColor == 3)
        {
            changeColor(WhiteBtn);
            btnColor = 6;
        }
    }


    public override void onClick()
    {
        press();
    }

    public override void press()
    {
        // ���� ��ġ�� �����մϴ�.
        Vector3 currentPosition = transform.position;

        // ��ǥ ��ġ�� ����մϴ�.
        Vector3 targetPosition = currentPosition + transform.forward * 0.05f;

        // ������Ʈ�� �̵���Ű�� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(MoveObject(currentPosition, targetPosition, 0.05f));
    }

    // ������Ʈ�� �̵���Ű�� �ڷ�ƾ �Լ�
    private IEnumerator MoveObject(Vector3 startPos, Vector3 endPos, float duration)
    {
        // �̵� ������ ���θ� ��Ÿ���� ����
        bool moving = true;

        float elapsedTime = 0;

        while (elapsedTime < duration && moving)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �̵��� �Ϸ�Ǹ� �ٽ� ���� ��ġ�� �ǵ��ư��ϴ�.
        elapsedTime = 0;
        while (elapsedTime < duration && moving)
        {
            transform.position = Vector3.Lerp(endPos, startPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public override void lightFlashed(int flashLightColor)
    {

        if (btnColor == 1)
        {
            //Debug.Log("B�ö�ũ���� �ķ��� ��" + flashlight.flashLightColor);

            if (flashlight.flashLightColor == 0)
            {
                makeCyan();
            }
            else if (flashlight.flashLightColor == 2)
            {
                makeYellow();
            }
        }
        if (btnColor == 5)
        {
            if (flashlight.flashLightColor == 0)
            {
                makeWhite();
            }
        }
        if (btnColor == 3)
        {
            if (flashlight.flashLightColor == 2)
            {
                makeWhite();
            }
        }

    }

    public void changeColor(Material newMaterial)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            // Assign the new material to the renderer
            renderer.material = newMaterial;
        }
    }
}
