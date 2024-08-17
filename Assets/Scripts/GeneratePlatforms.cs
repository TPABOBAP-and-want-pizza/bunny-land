using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] Transform PlatformsManager;
    [SerializeField] GameObject platformPrefab;  // Префаб платформи
    [SerializeField] int numberOfPlatforms = 3;  // Кількість платформ (кількість сторін)
    [SerializeField] int pound_count = 1;
    public Vector2 center = Vector2.zero; // Центр фігури

    private float platformLength;
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        // Одержуємо довжину платформи від префабу
        platformLength = platformPrefab.transform.localScale.x-1;
        GenerateEquilateralShape();
    }

    void GenerateEquilateralShape()
    {
        
        // Очищаємо попередні платформи
        foreach (var platform in platforms)
        {
            Destroy(platform);
        }
        platforms.Clear();

        // Вираховуємо радіус описаного кола, де `platformLength` - довша сторона платформи
        float radius = platformLength / (2 * Mathf.Tan(Mathf.PI / numberOfPlatforms));

        // Кут між вершинами багатокутника
        float angleBetweenVertices = 360f / numberOfPlatforms;

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            // Обчислення кута для поточної вершини
            float currentAngle = i * angleBetweenVertices;
            float radianAngle = currentAngle * Mathf.Deg2Rad;

            // Обчислення позиції центра платформи
            float x = center.x + radius * Mathf.Cos(radianAngle);
            float y = center.y + radius * Mathf.Sin(radianAngle);

            // Створення платформи в правильному місці
            GameObject platform = Instantiate(platformPrefab, new Vector3(x, y, 0f), Quaternion.identity);

            // Обчислення кута повороту платформи для вирівнювання її довгої сторони
            float rotationAngle = currentAngle + (90f);  // Враховуємо, що кут обертання рівний куту до центра плюс 90 градусів
            platform.transform.Rotate(0f, 0f, rotationAngle);

            platform.transform.localScale = new Vector3(platform.transform.localScale.x, -platform.transform.localScale.y, platform.transform.localScale.z);
            
                // Додаємо платформу до списку
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