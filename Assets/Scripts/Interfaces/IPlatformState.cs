using UnityEngine;
public interface IPlatformState 
{
    public int Id { get; }
    public string Name { get; }
    public Sprite Sprite { get; }
    public float movingSpeedMultiply { get; }
    public int muteLevel { get; }
    public int humidity { get; }
    public bool isWater { get; }
}
