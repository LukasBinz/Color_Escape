using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum state
{
    none, // �ƹ��͵�����
    one_selected, // �ϳ�����
    two_selected, // ���δٸ�_��_����
    one_doubleclicked, // �����ϳ�_�ι�Ŭ��
}


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemSO> Items = new List<ItemSO>();
    public List<Vector3Int> combineTable;
    public List<ItemSO> CombinedResultItems;
    public Transform ItemContent;
    public GameObject InventoryItem; // ������

    public Text lockedText;


    public void Start()
    {
        // ���� �ÿ� �ؽ�Ʈ�� ��Ȱ��ȭ
        lockedText.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void Add(ItemSO item)
    {
        Items.Add(item);
    }
    public void Remove(ItemSO item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            obj.GetComponent<Item>().thisItem = item;

            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var itemDescription = obj.transform.Find("ItemDescription").GetComponent<Text>();

            itemName.text = item.itemName;
            itemDescription.text = item.itemDescription;
            itemIcon.sprite = item.icon;

        }
    }

    state nowState = state.none;

    ItemSO rememberADDItemSO;

    int inhand = -1;  // -1 == �տ� �ƹ��͵� ���� 

    public void SelectItem(ItemSO itemS0)
    {
        Debug.Log(nowState);

        //���� ������ ������ ���� ��
        if (nowState == state.none)
        {
            nowState = state.one_selected;
            rememberADDItemSO = itemS0;
        }

        //������ ������ ���� ��
        else if (nowState == state.one_selected)
        {
            if (itemS0.id == rememberADDItemSO.id)
            {
                nowState = state.one_doubleclicked;
                // TODO �������� �տ� ����ְ� �� �� 
                inhand = itemS0.id;

                nowState = state.none;
                Debug.Log(nowState);

            }
            else
            {
                nowState = state.two_selected;
                Debug.Log(nowState);

                int combine = checkCombine(rememberADDItemSO.id, itemS0.id); // -1 �̶�� ���� �Ұ��� �̶�� ����!
                                                                    // Table �� ���� rememberAdd + itemS0.ID ���ս��� �ֳ�?
                if(combine == -1)
                {
                    Debug.Log("���պҰ���");
                    //������ �� ���� �������Դϴ� �˾�â
                    lockedText.gameObject.SetActive(true);
                    // 2�� �Ŀ� ��Ȱ��ȭ�ǵ��� Invoke() ȣ��
                    Invoke("HideText", 2.0f);
                }
                else if (combine != -1) // ������ ������ ��
                {
                    // �տ� ����ִ� ���� ������ ����� �� ((�տ�����ִ¹��� == rememberAdd || �տ�����ִ¹��� == itemS0.ID) && �̵������հ���(rememberAdd, itemS0.ID))
                    if (inhand != -1)
                    {
                        if (inhand == rememberADDItemSO.id || inhand == itemS0.id)
                        {
                            // �տ��� ���ش�.
                            inhand = -1;
                        }
                    }
                    // ���տ��� ����� ������ ����
                    Items.Remove(rememberADDItemSO);
                    Items.Remove(itemS0);
                    rememberADDItemSO = null;

                    // ���յ� ������ �߰�
                    Items.Add(getItemByIndex(combine));
                    ListItems();

                }

                nowState = state.none;

            }
        }


        int checkCombine(int item1Id, int item2Id)
        {
            for (int i = 0; i < combineTable.Count; i++)
            {
                if (combineTable[i].x == item1Id && combineTable[i].y == item2Id)
                {
                    return combineTable[i].z;
                }
            }
            return -1;

        }

        ItemSO getItemByIndex(int itemIndex)
        {
            foreach(ItemSO itemSO in CombinedResultItems)
            {
                if(itemSO.id == itemIndex)
                {
                    return itemSO;
                }
            }
            return null;
        }

    }
    private void HideText()
    {
        lockedText.gameObject.SetActive(false);
    }
}
