using UnityEngine;

public class YSort : MonoBehaviour
{
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = transform.GetSortingOrder();
    }
}
