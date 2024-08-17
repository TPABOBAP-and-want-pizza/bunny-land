using UnityEngine;

public class PoundState : IPlatformState
{
    public int Id { get; } = 2;
    public string Name { get; } = "Pound";
    public float movingSpeedMultiply { get; } = 20f;
    public int muteLevel { get; } = 0;
    public int humidity { get; } = 200;
    public bool isWater { get; } = true;
    public Sprite Sprite { get; set; } = Resources.Load<Sprite>("Sprite/Platform/pound_tile");
}
