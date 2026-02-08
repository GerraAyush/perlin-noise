using UnityEngine;

public class PerlinNoiseSprite : MonoBehaviour
{
    [SerializeField] private int width = 256;
    [SerializeField] private int height = 256;
    [SerializeField] private float scale = 20f;
    [SerializeField] private int offsetX = 100;
    [SerializeField] private int offsetY = 100;
    [SerializeField] private Color baseColor = new Color(121, 235, 59);

    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Texture2D noiseTexture = GenerateTexture();

        // Create sprite from texture
        Sprite sprite = Sprite.Create(noiseTexture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        spriteRenderer.sprite = sprite;
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture2D = new Texture2D(width, height);
        Color[] pixels = new Color[texture2D.width * texture2D.height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                pixels[y * texture2D.width + x] = CalculateColor(x, y);
            }
        }
        texture2D.SetPixels(pixels);
        texture2D.Apply();
        return texture2D;
    }

    Color CalculateColor(int x, int y) {
        float xCoord = (float) x / width * scale;
        float yCoord = (float) y / height * scale;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(
            baseColor.r + baseColor.r * sample, 
            baseColor.g + baseColor.g * sample, 
            baseColor.b + baseColor.b * sample
        );
    }
}
