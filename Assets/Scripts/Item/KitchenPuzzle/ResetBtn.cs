using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBtn : InteractiveItem
{
    public BananaPlate bp;
    public CarrotPlate cp;
    public SalmonPlate sp;

    public GameObject apple;
    public GameObject banana;
    public GameObject carrot;
    public GameObject salmon;

    public KitchenPuzzleManager puzzleManager; // ���� �Ŵ����� ������ ����

    public Material BluePlate;

    public int ItemId1;
    public int ItemId2;
    public int ItemId3;
    public int ItemId4;

    private bool isMoving = false;
    public void Start()
    {
        bp = FindObjectOfType<BananaPlate>();
        cp = FindObjectOfType<CarrotPlate>();
        sp = FindObjectOfType<SalmonPlate>();

    }

    public override void onClick()
    {
        press();

        // BananaPlate�� ���� ����
        if (bp != null)
        {
            bp.GetComponent<Renderer>().material = BluePlate;
        }

        // CarrotPlate�� ���� ����
        if (cp != null)
        {
            cp.GetComponent<Renderer>().material = BluePlate;
        }

        // SalmonPlate�� ���� ����
        if (sp != null)
        {
            sp.GetComponent<Renderer>().material = BluePlate;
        }
        
            // ������ ������Ʈ�� �ٽ� ���̰� �ϱ� ���� EnableObject �Լ� ȣ��
            EnableObject(apple);
            EnableObject(banana);
            EnableObject(carrot);
            EnableObject(salmon);

            // ������ ��ũ��Ʈ�� lockedText�� �ٽ� ����� ���� ȣ��
            Apple appleScript = apple.GetComponent<Apple>();
            if (appleScript != null && appleScript.lockedText != null)
            {
                appleScript.lockedText.gameObject.SetActive(false);
            }
            Banana bananaScript = banana.GetComponent<Banana>();
            if (bananaScript != null && bananaScript.lockedText != null)
            {
                bananaScript.lockedText.gameObject.SetActive(false);
            }

             Carrot carrotScript = carrot.GetComponent<Carrot>();
            if (carrotScript != null && carrotScript.lockedText != null)
            {
                carrotScript.lockedText.gameObject.SetActive(false);
            }

            Salmon salmonScript = salmon.GetComponent<Salmon>();
            if (salmonScript != null && salmonScript.lockedText != null)
            {
                salmonScript.lockedText.gameObject.SetActive(false);
            }


        puzzleManager.DestroyObjects();
        InventoryManager.Instance.RemoveItem(ItemId1);
        InventoryManager.Instance.RemoveItem(ItemId2);
        InventoryManager.Instance.RemoveItem(ItemId3);
        InventoryManager.Instance.RemoveItem(ItemId4);
        Debug.Log("�ı���û");


    }

    private void EnableObject(GameObject obj)
    {
        // Renderer ������Ʈ�� Ȱ��ȭ�Ͽ� ������Ʈ�� �ٽ� ���̰� ����
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = true;
        }

        // Collider ������Ʈ�� Ȱ��ȭ�Ͽ� �浹�� �ٽ� �����ϰ� ����
        Collider collider = obj.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
        }
    }

    public override void press()
    {
        if (!isMoving)
        {
            // ���� ��ġ�� �����մϴ�.
            Vector3 currentPosition = transform.position;

            // ��ǥ ��ġ�� ����մϴ�.
            Vector3 targetPosition = currentPosition + transform.up * 0.05f;

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
}
