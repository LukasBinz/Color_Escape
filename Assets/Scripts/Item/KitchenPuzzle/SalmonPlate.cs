using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalmonPlate : InteractiveItem
{
    public GameObject newObject;
    public GameObject destroyedObject;
    public KitchenPuzzleManager puzzle;
    public Vector3 newPosition;
    public Text wrongText;
    private bool hasInstantiated = false;

    public Flashlight flashlight;
    public Material Red_Plate;

    public int foodOrder = 0;
    public int neededItemId;

    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        wrongText.gameObject.SetActive(false);


    }
    void Update()
    {


    }
    public override void onClick()
    {
        if (InventoryManager.Instance.HasItem(neededItemId)) // ��� �κ��丮�� �ִٸ�
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
        foodOrder = 2;
        Debug.Log("count" + foodOrder);
        hasInstantiated = true;
    }

    public override void lightFlashed(int flashLightColor)
    {
        if (flashlight.flashLightColor == 3) // �ʷϻ�
        {
            changeColor(Red_Plate);
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
