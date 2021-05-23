using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class PlayerStatsManager : AutoCleanupSingleton<PlayerStatsManager>
{
    public Vector2 BulletSize { get { return _bulletSizeBase * _bulletSizeMultiplier; } }
    public float MoveSpeed { get { return _moveSpeedBase * _moveSpeedMultiplier; } }
    public float Health { get { return _healthBase * _healthMultiplier; } }
    public float BulletSpeed { get { return _bulletSpeedBase * _bulletSpeedMultiplier; } }
    public float BulletDamage { get { return _bulletDamageBase * _bulletDamageMultiplier; } }
    public float FireRate { get { return _fireRateBase * _fireRateMultiplier; } }

    [Header("Base Values")]
    [SerializeField] private Vector2 _bulletSizeBase;
    [SerializeField] private float _moveSpeedBase;
    [SerializeField] private float _healthBase;
    [SerializeField] private float _bulletSpeedBase;
    [SerializeField] private float _bulletDamageBase;
    [SerializeField] private float _fireRateBase;

    public Vector2 BulletSizeBase
    {
        get { return _bulletSizeBase; }
        set { _bulletSizeBase = value; UpdateBulletSize(); }
    }
    public float MoveSpeedBase 
    { 
        get { return _moveSpeedBase; } 
        set { _moveSpeedBase = value; UpdateMoveSpeed(); } 
    }
    public float HealthBase
    {
        get { return _healthBase; }
        set { _healthBase = value; UpdateHealth(); }
    }
    public float BulletSpeedBase
    {
        get { return _bulletSpeedBase; }
        set { _bulletSpeedBase = value; UpdateBulletSpeed(); }
    }
    public float BulletDamageBase
    {
        get { return _bulletDamageBase; }
        set { _bulletDamageBase = value; UpdateBulletDamage(); }
    }
    public float FireRateBase
    {
        get { return _fireRateBase; }
        set { _fireRateBase = value; UpdateFireRate(); }
    }

    [Header("Multipler Values")]
    [ShowOnly] private float _bulletSizeMultiplier = 1;
    [ShowOnly] private float _moveSpeedMultiplier = 1;
    [ShowOnly] private float _healthMultiplier = 1;
    [ShowOnly] private float _bulletSpeedMultiplier = 1;
    [ShowOnly] private float _bulletDamageMultiplier = 1;
    [ShowOnly] private float _fireRateMultiplier = 1;

    public float BulletSizeMultiplier
    {
        get { return _bulletSizeMultiplier; }
        set { _bulletSizeMultiplier = value; UpdateBulletSize(); }
    }
    public float MoveSpeedMultiplier
    {
        get { return _moveSpeedMultiplier; }
        set { _moveSpeedMultiplier = value; UpdateMoveSpeed(); }
    }
    public float HealthMultiplier
    {
        get { return _healthMultiplier; }
        set { _healthMultiplier = value; UpdateHealth(); }
    }
    public float BulletSpeedMultiplier
    {
        get { return _bulletSpeedMultiplier; }
        set { _bulletSpeedMultiplier = value; UpdateBulletSpeed(); }
    }
    public float BulletDamageMultiplier
    {
        get { return _bulletDamageMultiplier; }
        set { _bulletDamageMultiplier = value; UpdateBulletDamage(); }
    }
    public float FireRateMultiplier
    {
        get { return _fireRateMultiplier; }
        set { _fireRateMultiplier = value; UpdateFireRate(); }
    }

    private void UpdateMoveSpeed()
    {
        PlayerManager.Instance.Player.GetComponent<IMovementModule>().UpdateMoveSpeed(MoveSpeed);
    }
    private void UpdateBulletSize()
    {
        //Yazilcak
    }
    private void UpdateHealth()
    {
        PlayerManager.Instance.Player.GetComponent<Health>().UpdateMaxHealth(Health);
    }
    private void UpdateBulletSpeed()
    {
        PlayerManager.Instance.BulletBlueprint.GetComponent<BulletMoveNormal>().UpdateBulletSpeed(BulletSpeed);
    }
    private void UpdateFireRate()
    {
        PlayerManager.Instance.Player.GetComponent<GunController>().UpdateFireRate(FireRate);
    }
    private void UpdateBulletDamage()
    {
        PlayerManager.Instance.BulletBlueprint.GetComponent<BulletDealDamage>().UpdateBulletDamage(BulletDamage);
    }

    private void Awake()
    {
        UpdateMoveSpeed();
        UpdateBulletSize();
        UpdateHealth();
        UpdateBulletSpeed();
        UpdateFireRate();
        UpdateBulletDamage();
    }
}
