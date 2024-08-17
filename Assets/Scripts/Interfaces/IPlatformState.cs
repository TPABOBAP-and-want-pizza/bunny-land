public interface IPlatformState 
{
    public string Name { get; }
    public float movingSpeedMultiply { get; }
    public int muteLevel { get; }
    public int humidity { get; }
    public bool isWater { get; }
}
