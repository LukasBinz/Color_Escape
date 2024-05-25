using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ApplePlate : InteractiveItem
{
    public GameObject newObject;
    public GameObject destroyedObject;
    public KitchenPuzzleManager puzzle;
    public Vector3 newPosition;
    private bool hasInstantiated = false;
    private bool targetDestroyed = false;
    public Text wrongText;

    public int foodOrder = 3;


    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        wrongText.gameObject.SetActive(false);
        puzzle = FindObjectOfType<KitchenPuzzleManager>();

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
        if (1==1) // �����ϰ� �ִ� �������� ������
        {
            place(); //�������� �ø���

            if (puzzle != null)
            {
                puzzle.OnFoodPlaced(foodOrder);
            }
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
            Instantiate(newObject, newPosition, Quaternion.identity);
            puzzle.currentObjectCount++;
            foodOrder = 0;
            Debug.Log("count" + foodOrder);
            hasInstantiated = true;
        }
    }
}
