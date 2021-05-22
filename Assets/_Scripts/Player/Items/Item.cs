using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private SpriteRenderer _renderer;


    private void Start()
    {
        PrepareItem();
    }

    private void PrepareItem()
    {
        _renderer.sprite = itemData.Art;
        _renderer.transform.localScale = itemData.ArtSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger enter");
        if (collision.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {
            InventoryManager.Instance.PickedUpItem(itemData);
            Destroy(gameObject);
        }
    }

}
