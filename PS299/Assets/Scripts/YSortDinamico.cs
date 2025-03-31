using System;
using UnityEngine;

public class YSortDinamico : MonoBehaviour
{
    private int _baseSortingOrder;
    [SerializeField] private SortableSprite[] _sortableSprites;

    void Update() 
    {
        _baseSortingOrder = transform.GetSortingOrder();
        foreach (var sortableSprite in _sortableSprites)
        {
            sortableSprite.spriteRenderer.sortingOrder = _baseSortingOrder + sortableSprite.relativeOrder;
        }
    }

    [Serializable]
    public struct SortableSprite
    {
        public SpriteRenderer spriteRenderer;
        public int relativeOrder;
    }
}

