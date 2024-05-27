using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummerBtn : InteractiveItem
{
    // btnColor 0 : R, 1 : G, 2: B, 3: C, 4: M, 5: Y, 6: W

    public int btnId = 0;
    public int btnColor = 1;
    public Flashlight flashlight;
    public WeatherPuzzleManager puzzle;
    public Material CyanBtn;
    public Material YellowBtn;
    public Material WhiteBtn;
    private Password password;
    public Text lockedText1;
    public Text lockedText2;

    private bool isMoving = false;

    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        lockedText1.gameObject.SetActive(false);
        lockedText2.gameObject.SetActive(false);
        password = FindObjectOfType<Password>();
    }

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
            btnId = 2;
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
        if (puzzle.unlocked == 1)
        {
            press();
      
            if (password != null)
            {
                password.OnButtonPressed(btnId); 
            }

        }
        else
        {
            // �ؽ�Ʈ�� Ȱ��ȭ�Ͽ� ���ڸ� ���� ���Ѵٴ� �޽����� ǥ��
            lockedText1.gameObject.SetActive(true);
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
        if (!isMoving)
        {
            // ���� ��ġ�� �����մϴ�.
            Vector3 currentPosition = transform.position;

            // ��ǥ ��ġ�� ����մϴ�.
            Vector3 targetPosition = currentPosition + transform.forward * 0.05f;

            // ������Ʈ�� �̵���Ű�� �ڷ�ƾ�� �����մϴ�.
            StartCoroutine(MoveObject(currentPosition, targetPosition, 0.05f));
        }
    }

    // ������Ʈ�� �̵���Ű�� �ڷ�ƾ �Լ�
    private IEnumerator MoveObject(Vector3 startPos, Vector3 endPos, float duration)
    {
        isMoving = true;  // �̵� ����

        float elapsedTime = 0;

        // ��ǥ ��ġ�� �̵�
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // ��ǥ ��ġ�� ��Ȯ�� �����ϵ��� ����
        transform.position = endPos;

        // ���� ��ġ�� ���ư��� ���� ��� ��� (���ϴ� ���)
        yield return new WaitForSeconds(0.1f);

        elapsedTime = 0;

        // ���� ��ġ�� �̵�
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(endPos, startPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // ���� ��ġ�� ��Ȯ�� �����ϵ��� ����
        transform.position = startPos;

        isMoving = false;  // �̵� ����
    }

    public override void lightFlashed(int flashLightColor)
    {
        if (puzzle.unlocked == 1 && password.unlocked == 0)
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
                    btnId = 2;
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

    }

    public void changeColor(Material newMaterial)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material = newMaterial;
        }
    }
}
