using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] Transform platformsManager;
    [SerializeField] GameObject platformPrefab;  // ������ ���������
    [SerializeField] int numberOfPlatforms = 3;  // ʳ������ �������� (������� �����)
    public Vector2 center = Vector2.zero; // ����� ������

    private float platformLength;
    private List<Platform> platforms = new List<Platform>();

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
            platforms.Add(platform.GetComponent<Platform>());
        }
        platformsManager.GetComponent<PlatformsManager>().SetPlatforms(platforms);
    }
}