using UnityEngine;

public class GrassState : IPlatformState
{
    public int Id { get; } = 1;
    public string Name { get; } = "Grass";
    public float movingSpeedMultiply { get; } = 80f;
    public int muteLevel { get; } = 0;
    public int humidity { get; } = 120;
    public bool isWater { get; } = false;

    public Sprite Sprite { get; set; } = (Sprite)Resources.Load<Sprite>("Sprite/Platform/grasss_tile");
}
