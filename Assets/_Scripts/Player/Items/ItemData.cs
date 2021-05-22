using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private int goldCost;
    [SerializeField] private Sprite art;
    [SerializeField] private Vector2 artSize;

    public int GoldCost => goldCost;
    public Sprite Art => art;
    public Vector2 ArtSize => artSize;

    public abstract void OnDrop();

    public abstract void OnPickUp();
}
