using UnityEngine;
using System;

public class Platform : MonoBehaviour
{
    public event Action<Platform> OnEdit;

    public IPlatformState CurrentState { get; private set; }
    public float CurrentHumidity { get; set; } = 100f;
    public bool IsGrowenUp { get; private set; } = false;
    public float ResourcesMultiply { get; private set; } = 1f;
    public int Id { get; set; }

    private void Start()
    {
        CurrentState = new GroundState();
    }
    public void SetState(IPlatformState platformState)
    {
        Debug.Log("sdfsdf");
        CurrentState = platformState;
        transform.GetComponentInChildren<SpriteRenderer>().sprite = CurrentState.Sprite;
        Debug.Log($"sprite = {CurrentState.Sprite}");
        OnEdit?.Invoke(this);
    }
    public void GrowUp()
    {
        IsGrowenUp = true;
        ResourcesMultiply *= 1.15f;
    }
}
