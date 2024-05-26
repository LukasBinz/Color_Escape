using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salmon : InteractiveItem
{
    public Text lockedText;

    void Start()
    {
        lockedText.gameObject.SetActive(false);
    }
    public override void onClick()
    {
        
         lockedText.gameObject.SetActive(true);
         StartCoroutine(DisableTextAfterDelay(1.0f));
     

    }
    private IEnumerator DisableTextAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        
        lockedText.gameObject.SetActive(false);
        pickUp();
        // pickUp ȣ��

    }

    public override void pickUp()
    {
        InventoryManager.Instance.Add(Item);

        // Renderer ������Ʈ�� ��Ȱ��ȭ�Ͽ� ������Ʈ�� ������ �ʰ� ����
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }

        // Collider ������Ʈ�� ��Ȱ��ȭ�Ͽ� �浹�� ����
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        Debug.Log("add inventory");
 

    }
}
