using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaPlate : InteractiveItem
{
    // Start is called before the first frame update
    public GameObject newObject;
    public GameObject destroyedObject;
    public KitchenPuzzleManager number;
    public Vector3 newPosition;
    public Vector3 newRotation;
    private bool hasInstantiated = false;
    private bool targetDestroyed = false;
    public Text wrongText;

    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        wrongText.gameObject.SetActive(false);

    }
    void Update()
    {
        // Ÿ�� ������Ʈ�� �ı��Ǿ����� üũ
        if (destroyedObject == null)
        {
            targetDestroyed = true;
        }


    }
    public override void onClick()
    {
        if (1 == 1) // �����ϰ� �ִ� �������� ������
        {
            place(); //�������� �ø���
        }
        else
        {
            wrongText.gameObject.SetActive(true);
            Invoke("HideText", 2.0f);
        }

    }
    private void HideText()
    {
        wrongText.gameObject.SetActive(false);
    }

    public override void place()
    {
        if (!hasInstantiated && targetDestroyed)
        {
            Instantiate(newObject, newPosition, Quaternion.Euler(newRotation));
            number.currentObjectCount++;
            Debug.Log("count");
            hasInstantiated = true;
        }
    }
}
