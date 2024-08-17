using UnityEngine;

public class GroundState : MonoBehaviour, IPlatformState
{
    public string Name { get; } = "Ground";
    public float movingSpeedMultiply { get; } = 100f;
    public int muteLevel { get; } = 0;
    public int humidity { get; } = 10;
    public bool isWater { get; } = false;
}
