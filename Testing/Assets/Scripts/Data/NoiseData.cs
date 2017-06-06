﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class NoiseData : UpdatableData
{
    public Noise.NormalizedMode normalizedMode;

    public float noiseScale;

    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    #if UNITY_EDITOR

    protected override void OnValidate()
    {
        lacunarity = Mathf.Max(1, lacunarity);
        octaves = Mathf.Max(0, octaves);

        base.OnValidate();
    }

    #endif
}