using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    [SerializeField] List<IPlatformState> allStates = new List<IPlatformState>();
    [SerializeField] int pound_count = 1;

    private List<Platform> platforms;
    private void Start()
    {
        allStates.Add(new GroundState());
        allStates.Add(new GrassState());
        allStates.Add(new PoundState());
    }
    public void SetPlatforms(List<Platform> _platforms)
    {
        platforms = _platforms;
        SelectActions();

        for (int i = 0; i < platforms.Count; i++) 
        {
            platforms[i].Id = i;
        }

        if (pound_count > platforms.Count)
        {
            pound_count = platforms.Count - 1;
            Debug.LogWarning("numberOfPlatforms < pound_count\npound_count = numberOfPlatforms - 1;");
        }

        List<int> pound_ids = new List<int>();
        for (int i = 0; i < pound_count; i++)
        {
            int temp = Random.Range(0, platforms.Count-1);
            pound_ids.Add(temp);
        }
        Debug.Log($"pound counts {pound_ids.Count}");

        foreach (int k in pound_ids)
        {
            platforms[k].SetState(allStates[2]); // 2 - pound
        }

    }
    private void SelectActions()
    {
        foreach(Platform platform in platforms)
        {
            platform.OnEdit += CheckPlatform;
        }
    }
    private void DisableActions()
    {
        foreach (Platform platform in platforms)
        {
            platform.OnEdit -= CheckPlatform;
        }
    }
    private void CheckPlatform(Platform platform)
    {
        int id = platform.Id;
        switch (platform.CurrentState.Id)
        {
            case 2: // 2 - pound
                if (id != 0 && id != platforms.Count - 1)
                {
                    float[] factors = { 1.4f, 1.2f };  
                    for (int i = 1; i <= 2; i++)
                    {
                        if (id - i >= 0 && platforms[id-i].CurrentState != new PoundState())  
                        {
                            platforms[id - i].CurrentHumidity *= factors[i - 1];
                            if(CheckHumidity(platforms[id - i].CurrentHumidity))
                            {
                                platforms[id - i].SetState(allStates[1]);
                            }
                        }

                        if (id + i < platforms.Count && platforms[id - i].CurrentState != new PoundState())  
                        {
                            platforms[id + i].CurrentHumidity *= factors[i - 1];
                            if (CheckHumidity(platforms[id - i].CurrentHumidity))
                            {
                                platforms[id - i].SetState(allStates[1]);
                            }
                        }
                    }
                }
                break;
        }
    }
    private bool CheckHumidity(float humidity)
    {
        if((int)humidity > new GrassState().humidity)
        {
            return true;
        }
        return false;
    }
}
