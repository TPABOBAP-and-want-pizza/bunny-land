using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoundState : MonoBehaviour
{
    public string Name { get; } = "Pound";
    public float movingSpeedMultiply { get; } = 20f;
    public int muteLevel { get; } = 0;
    public int humidity { get; } = 100;
    public bool isWater { get; } = true;
}
