using UnityEngine;

public class GroundState : IPlatformState
{
    public int Id { get; } = 0;
    public string Name { get; } = "Ground";
    public float movingSpeedMultiply { get; } = 100f;
    public int muteLevel { get; } = 0;
    public int humidity { get; } = 100;
    public bool isWater { get; } = false;
    public Sprite Sprite { get; set; } = Resources.Load<Sprite>("Sprite/Platform/grass_tile 1");
}
