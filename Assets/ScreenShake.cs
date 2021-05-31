using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float _rotationMultiplier = 15f;
    
    public static ScreenShake instance;

    private float _shakeTimeRemaining;
    private float _shakePower;
    private float _shakeFadeTime;
    private float _shakeRotation;

    
    
    
    void Start()
    {
        instance = this;
    }


    private void LateUpdate()
    {
        if(_shakeTimeRemaining > 0)
        {
            _shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * _shakePower;
            float yAmount = Random.Range(-1f, 1f) * _shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0);

            _shakePower = Mathf.MoveTowards(_shakePower, 0f, _shakeFadeTime * Time.deltaTime);

            _shakeRotation = Mathf.MoveTowards(_shakeRotation, 0f, _shakeFadeTime * _rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, _shakeRotation * Random.Range(-1f, 1f));
    }

    public void StartShake(float length, float power)
    {
        _shakeTimeRemaining = length;
        _shakePower = power;

        _shakeFadeTime = power / length;

        _shakeRotation = power * _rotationMultiplier; 
    }
}
