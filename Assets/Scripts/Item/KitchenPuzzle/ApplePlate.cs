using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ApplePlate : InteractiveItem
{
    public GameObject newObject;
    public GameObject disabledObject;
    public KitchenPuzzleManager puzzle;
    public Vector3 newPosition;
    public Text wrongText;
    private bool hasInstantiated = false;
    public int foodOrder = 3;
    public int neededItemId;


    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        wrongText.gameObject.SetActive(false);
        puzzle = FindObjectOfType<KitchenPuzzleManager>();

    }
    void Update()
    {


    }
    public override void onClick()
    {
        if (InventoryManager.Instance.HasItem(neededItemId)) // �����ϰ� �ִ� �������� ������
        {
            place(); //�������� �ø���
          
            if (puzzle != null)
            {
                puzzle.OnFoodPlaced(foodOrder);
            }

            InventoryManager.Instance.RemoveItem(neededItemId);
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
        GameObject newObjectInstance = Instantiate(newObject, newPosition, Quaternion.identity);

        // ������ ������Ʈ�� "PlaceableObject" �±� �ο�
        newObjectInstance.tag = "PlaceableObject";

        puzzle.currentObjectCount++;
        foodOrder = 0;
        Debug.Log("count" + foodOrder);
        hasInstantiated = true;
    }
}
