using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class PlayerManager : AutoCleanupSingleton<PlayerManager>
{
    [SerializeField] private Transform _player;

    public Transform Player => _player;


}
