using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBtn : InteractiveItem
{
    // btnColor 0 : R, 1 : G, 2: B, 3: C, 4: M, 5: Y, 6: W

    public int btnColor = 2;
    public Flashlight flashlight;
    public Material CyanBtn;
    public Material MagentaBtn;
    public Material WhiteBtn;


    public void makeCyan()
    {
        if (btnColor == 2)
        {
            changeColor(CyanBtn);
            btnColor = 3;
        }
    }
    public void makeMagenta()
    {
        if (btnColor == 2)
        {
            changeColor(MagentaBtn);
            btnColor = 4;
        }
    }
    public void makeWhite()
    {
        if (btnColor == 4 || btnColor == 3)
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

        if (btnColor == 2)
        {
            //Debug.Log("B�ö�ũ���� �ķ��� ��" + flashlight.flashLightColor);

            if (flashlight.flashLightColor == 3)
            {
                makeCyan();
            }
            else if (flashlight.flashLightColor == 2)
            {
                makeMagenta();
            }
        }
        if (btnColor == 4)
        {
            if (flashlight.flashLightColor == 3)
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
