using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class PlayerManager : AutoCleanupSingleton<PlayerManager>
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _bulletBlueprint;

    public Transform Player => _player;
    public Transform BulletBlueprint => _bulletBlueprint;

}
