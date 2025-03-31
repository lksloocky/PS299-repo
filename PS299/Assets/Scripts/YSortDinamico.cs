using System;
using UnityEngine;

public class YSortDinamico : MonoBehaviour
{
    private int _baseSortingOrder;
    private float _YSortingOffset;
    [SerializeField] private SortableSprite[] _sortableSprites;
    [SerializeField] private Transform _sortOffsetMarker;

    void Start() 
    {
       _YSortingOffset = _sortOffsetMarker.position.y;
    }

    void Update() 
    {
        _baseSortingOrder = transform.GetSortingOrder(_YSortingOffset);
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

