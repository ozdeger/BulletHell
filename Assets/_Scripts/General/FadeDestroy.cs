using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDestroy : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private AnimationCurve opacityCurve;
    [SerializeField] private SpriteRenderer[] rends;

    private float[] alphas;
    private float timePassed = 0;

    private void Start()
    {
        GetAlphas();
        Destroy(gameObject, time);
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        UpdateAlphas();
    }

    private void GetAlphas()
    {
        alphas = new float[rends.Length];
        for (int i = 0; i < rends.Length; i++)
        {
            alphas[i] = rends[i].color.a;
        }
    }

    private void UpdateAlphas()
    {
       

        for (int i = 0; i < rends.Length; i++)
        {
            float curveMultiplier = opacityCurve.Evaluate(timePassed / time);
            Color oldColor = rends[i].color;
            float newAlpha = 1- curveMultiplier;
            rends[i].color = new Color (oldColor.r,oldColor.g,oldColor.b,newAlpha);
        }
    }
}
