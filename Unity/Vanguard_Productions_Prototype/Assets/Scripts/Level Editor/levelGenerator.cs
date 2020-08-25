using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public Texture2D map;

    public colorToPrefab[] colorMappings;

    void Start()
    {
        GenerateLevel();    
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile (int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            // The pixel is transparent, ignore it
            return;
        }

        foreach (colorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(0, y, x);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
