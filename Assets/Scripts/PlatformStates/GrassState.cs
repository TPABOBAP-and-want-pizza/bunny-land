using UnityEngine;

public class GrassState : MonoBehaviour, IPlatformState
{
    public string Name { get; } = "Grass";
    public float movingSpeedMultiply { get; } = 80f;
    public int muteLevel { get; } = 0;
    public int humidity { get; } = 40;
    public bool isWater { get; } = false;
}
