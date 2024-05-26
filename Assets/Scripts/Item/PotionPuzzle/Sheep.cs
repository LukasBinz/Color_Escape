using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sheep : InteractiveItem
{
    public Text lockedText;

    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        lockedText.gameObject.SetActive(false);
    }

    public override void onClick()
    {
        // lockedText�� Ȱ��ȭ
        lockedText.gameObject.SetActive(true);

        // 1�� ���
        StartCoroutine(DisableTextAfterDelay(1.0f));
    }

    private IEnumerator DisableTextAfterDelay(float delay)
    {
        // delay �� ���� ���
        yield return new WaitForSeconds(delay);
        // 1�ʰ� ���� �Ŀ� lockedText�� ��Ȱ��ȭ
        lockedText.gameObject.SetActive(false);
        pickUp();
        // pickUp ȣ��

    }
    public override void pickUp()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(this.gameObject);
        Debug.Log("add inventory");

    }

}



    