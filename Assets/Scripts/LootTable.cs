using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LootObject
{
    public GameObject item;
    public int lootWeight;
}

[System.Serializable]
public class LootObjectMultiple
{
    public GameObject item;
    public int min;
    public int max;
}

public class LootTable : MonoBehaviour
{
    [SerializeField] List<LootObject> lootObjects;
    [SerializeField] List<LootObjectMultiple> lootMultipleObjects;

    public int GetTotal()
    {
        int total = 0;
        foreach (LootObject item in lootObjects)
            total += item.lootWeight;
        return total;
    }

    public LootObject DropItem()
    {
        int total = GetTotal();
        int percentIndex = Random.Range(0, total);
        int margin = 0;
        LootObject itemSelected = null;

        foreach (LootObject item in lootObjects)
        {
            margin += item.lootWeight;
            if (percentIndex < margin)
            {
                itemSelected = item;
                break;
            }
        }
        return itemSelected;
    }

    public List<GameObject> DropItems()
    {
        List<GameObject> itemsList = new List<GameObject>();
        int generatedValue = 0;
        foreach (LootObjectMultiple item in lootMultipleObjects)
        {
            generatedValue = Random.Range(0, item.max);
            for (int i = 0; i < generatedValue; i++)
                itemsList.Add(item.item);
        }
        return itemsList;
    }
}
