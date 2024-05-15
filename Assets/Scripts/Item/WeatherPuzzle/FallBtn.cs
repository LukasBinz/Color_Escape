using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallBtn : InteractiveItem
{
    // btnColor 0 : R, 1 : G, 2: B, 3: C, 4: M, 5: Y, 6: W

    public int btnId = 3;
    public int btnColor = 0;
    public WeatherPuzzleManager puzzle;
    public Flashlight flashlight;
    public Material YellowBtn;
    public Material MagentaBtn;
    public Material WhiteBtn;
    private Password password;
    public Text lockedText1;
    public Text lockedText2;

    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        lockedText1.gameObject.SetActive(false);
        lockedText2.gameObject.SetActive(false);
        password = FindObjectOfType<Password>();
    }
    public void makeYellow()
    {
        if (btnColor == 0)
        {
            changeColor(YellowBtn);
            btnColor = 5;
     
        }

    }
    public void makeMagenta()
    {
        if (btnColor == 0)
        {
            changeColor(MagentaBtn);
            btnColor = 4;
            
        }
    }
    public void makeWhite()
    {
        if (btnColor == 4 || btnColor == 5)
        {
            changeColor(WhiteBtn);
            btnColor = 6;
            
        }
    }

    public override void onClick()
    {
        if (puzzle.unlocked == 1)
        {
            press();

            if (password != null)
            {
                password.OnButtonPressed(btnId); // btnId�� ��ư�� ID�Դϴ�. �̸� ����Ͽ� ��ư�� ID�� �����մϴ�.
            }

        }
        else
        {
            // �ؽ�Ʈ�� Ȱ��ȭ�Ͽ� ���ڸ� ���� ���Ѵٴ� �޽����� ǥ��
            lockedText1.gameObject.SetActive(true);
            // 2�� �Ŀ� ��Ȱ��ȭ�ǵ��� Invoke() ȣ��
            Invoke("HideText", 2.0f);
        }
    }
    private void HideText()
    {
        lockedText1.gameObject.SetActive(false);
        lockedText2.gameObject.SetActive(false);
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

        if (puzzle.unlocked == 1)
        {
            if (btnColor == 0)
            {
                //Debug.Log("R�ö�ũ���� �ķ��� ��" + flashlight.flashLightColor);

                if (flashlight.flashLightColor == 3)
                {
                    makeYellow();
                    btnId = 0;
                }
                else if (flashlight.flashLightColor == 0)
                {
                    makeMagenta();
                    btnId = 0;
                }
            }
            if (btnColor == 4)
            {
                if (flashlight.flashLightColor == 3)
                {
                    makeWhite();
                    btnId = 0;
                }
            }
            if (btnColor == 5)
            {
                if (flashlight.flashLightColor == 0)
                {
                    makeWhite();
                    btnId = 0;
                }
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
