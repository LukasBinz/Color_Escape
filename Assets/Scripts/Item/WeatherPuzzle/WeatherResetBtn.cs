using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherResetBtn : InteractiveItem
{


    private SpringBtn springBtn;
    private SummerBtn summerBtn;
    private FallBtn fallBtn;
    private WinterBtn winterBtn;

    public Material RedBtn;
    public Material GreenBtn;
    public Material BlueBtn;

    private int springOriginalColor;
    private int summerOriginalColor;
    private int fallOriginalColor;
    private int winterOriginalColor;



    public void Start()
    {
        springBtn = GetComponent<SpringBtn>();
        summerBtn = GetComponent<SummerBtn>();
        fallBtn = GetComponent<FallBtn>();
        winterBtn = GetComponent<WinterBtn>();

        if (springBtn != null)
            springOriginalColor = springBtn.btnColor;

        if (summerBtn != null)
            summerOriginalColor = summerBtn.btnColor;

        if (fallBtn != null)
            fallOriginalColor = fallBtn.btnColor;

        if (winterBtn != null)
            winterOriginalColor = winterBtn.btnColor;

    }

    public override void onClick()
    {
        press();

        // �� ��ư�� ���� ����
        if (springBtn != null)
            springBtn.changeColor(BlueBtn);

        if (summerBtn != null)
            summerBtn.changeColor(GreenBtn);

        if (fallBtn != null)
            fallBtn.changeColor(RedBtn);

        if (winterBtn != null)
            winterBtn.changeColor(BlueBtn);

        // �� ��ư�� �ʱ� �������� �ٽ� ����
        if (springBtn != null)
            springBtn.btnColor = springOriginalColor;

        if (summerBtn != null)
            summerBtn.btnColor = summerOriginalColor;

        if (fallBtn != null)
            fallBtn.btnColor = fallOriginalColor;

        if (winterBtn != null)
            winterBtn.btnColor = winterOriginalColor;

    }
    public override void press()
    {

        // ���� ��ġ�� �����մϴ�.
        Vector3 currentPosition = transform.position;

        // ��ǥ ��ġ�� ����մϴ�.
        Vector3 targetPosition = currentPosition + transform.up * 0.05f;

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
