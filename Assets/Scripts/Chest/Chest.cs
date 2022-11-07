using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] bool singleDrop = false;
    [SerializeField] Animator animator;
    [SerializeField] LootTable lootTable;

    [SerializeField] bool interacted = false;
    [SerializeField] bool inInteractionRange = false;
    [SerializeField] Canvas interactCanvas;
    [SerializeField] Transform itemDisplay;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform itemsParent;

    public void OpenSingle()
    {
        LootObject item = lootTable.DropItem();
        GameObject itemImage = Instantiate(item.item, null);
        itemImage.transform.parent = itemDisplay.transform;
        itemImage.transform.localPosition = Vector3.zero;
        itemImage.transform.localScale = Vector3.one;
        itemDisplay.gameObject.SetActive(true);

    }

    public void OpenMultiple()
    {
        itemDisplay.gameObject.SetActive(true);
        List<GameObject> itemsDropped = lootTable.DropItems();
        foreach (GameObject item in itemsDropped)
        {
            GameObject newButton = Instantiate(buttonPrefab, null);
            newButton.transform.parent = itemsParent.transform;
            Image buttonImage = newButton.gameObject.GetComponent<Image>();
            buttonImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        }
        
    }


    public void ChestTriggerEnter()
    {
        if (interacted) return;
        interactCanvas.gameObject.SetActive(true);
        inInteractionRange = true;
    }

    public void ChestTriggerExit()
    {
        if (interacted) return;
        interactCanvas.gameObject.SetActive(false);
        itemDisplay.gameObject.SetActive(false);
        inInteractionRange = false;
    }

    private void Update()
    {
        if (!inInteractionRange)
            return;

        if (interacted)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacting", gameObject);
            interactCanvas.gameObject.SetActive(false);
            interacted = true;
            animator.SetTrigger("open");

            if (singleDrop)
                OpenSingle();
            else
                OpenMultiple();
        }
    }
}
