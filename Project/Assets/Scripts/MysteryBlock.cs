using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlock : MonoBehaviour {

    public GameObject item;
    public bool isActive = true;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponentInParent<SpriteRenderer>();
    }

    public void SpawnItem()
    {
        var newItem = Instantiate(item);
        newItem.transform.position = new Vector3(transform.position.x, transform.position.y + .5f);
        isActive = false;
        sr.color = new Color(156, 105, 105);
    }
}
