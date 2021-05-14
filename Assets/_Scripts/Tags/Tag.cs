using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tags {
    Obstacle,
    Enemy,
    Friendly,
    Player,
    EnemyBullet,
    FriendlyBullet,
    PlayerBullet,
}

public class Tag : MonoBehaviour
{
    [SerializeField] List<Tags> tags;
    public List<Tags> Tags => tags;
}
