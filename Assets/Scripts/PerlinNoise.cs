using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    [SerializeField] private int width = 256;
    [SerializeField] private int height = 256;
    [SerializeField] private int offsetX = 100;
    [SerializeField] private int offsetY = 100;
    [SerializeField] private int scale = 20;

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture() {
        Texture2D texture2D = new Texture2D(width, height);

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Color color = CalculateColor(x, y);
                texture2D.SetPixel(x, y, color);
            }
        }

        texture2D.Apply();
        return texture2D;
    }

    Color CalculateColor(int x, int y) {
        // Perlin Noise repeats at whole numbers, so we convert x and y from int to floats
        // Scale to increase the amount of variation
        // Offsets to make the noise texture more random
        float xCoord = (float) x / width * scale + offsetX;
        float yCoord = (float) y / height * scale + offsetY;
        
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color (sample, sample, sample);
    }

}
