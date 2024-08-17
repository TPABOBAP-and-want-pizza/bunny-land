using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] Transform PlatformsManager;
    [SerializeField] GameObject platformPrefab;  // ������ ���������
    [SerializeField] int numberOfPlatforms = 3;  // ʳ������ �������� (������� �����)
    [SerializeField] int pound_count = 1;
    public Vector2 center = Vector2.zero; // ����� ������

    private float platformLength;
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        // �������� ������� ��������� �� �������
        platformLength = platformPrefab.transform.localScale.x-1;
        GenerateEquilateralShape();
    }

    void GenerateEquilateralShape()
    {
        
        // ������� �������� ���������
        foreach (var platform in platforms)
        {
            Destroy(platform);
        }
        platforms.Clear();

        // ���������� ����� ��������� ����, �� `platformLength` - ����� ������� ���������
        float radius = platformLength / (2 * Mathf.Tan(Mathf.PI / numberOfPlatforms));

        // ��� �� ��������� �������������
        float angleBetweenVertices = 360f / numberOfPlatforms;

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            // ���������� ���� ��� ������� �������
            float currentAngle = i * angleBetweenVertices;
            float radianAngle = currentAngle * Mathf.Deg2Rad;

            // ���������� ������� ������ ���������
            float x = center.x + radius * Mathf.Cos(radianAngle);
            float y = center.y + radius * Mathf.Sin(radianAngle);

            // ��������� ��������� � ����������� ����
            GameObject platform = Instantiate(platformPrefab, new Vector3(x, y, 0f), Quaternion.identity);

            // ���������� ���� �������� ��������� ��� ����������� �� ����� �������
            float rotationAngle = currentAngle + (90f);  // ���������, �� ��� ��������� ����� ���� �� ������ ���� 90 �������
            platform.transform.Rotate(0f, 0f, rotationAngle);

            platform.transform.localScale = new Vector3(platform.transform.localScale.x, -platform.transform.localScale.y, platform.transform.localScale.z);
            
                // ������ ��������� �� ������
                platforms.Add(platform);
        }
        
    }
}
/*if(pound_count > numberOfPlatforms)
        {
            pound_count = numberOfPlatforms - 1;
            Debug.LogWarning("numberOfPlatforms < pound_count\npound_count = numberOfPlatforms - 1;");
        }

        List<int> pound_ids = new List<int>();
        for(int i = 0; i < pound_count; i++)
        {
            int temp = Random.Range(0, numberOfPlatforms);
            foreach(int k in pound_ids)
            {
                if(temp == k)
                { 
                    i--;
                    continue;
                }
                else pound_ids.Add(temp);
            }
            
        }

        foreach (int k in pound_ids)
            {
                if (i == k)
                {
                    SpriteRenderer sp = platform.GetComponentInChildren<SpriteRenderer>();
                    sp.drawMode = SpriteDrawMode.Simple;
                    sp.sprite = Resources.Load("Sprite/Platform/pound_tile.png")
                }
            }
*/