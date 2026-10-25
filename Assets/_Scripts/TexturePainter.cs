using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TexturePainter : MonoBehaviour
{
    public int textureSize = 512;
    public int brushRadius = 25;
    public Color paintColor = Color.red;

    private Texture2D paintTexture;

    void Start()
    {
        // Create a blue texture.
        paintTexture = new Texture2D(
            textureSize,
            textureSize,
            TextureFormat.RGBA32,
            false
        );

        paintTexture.wrapMode = TextureWrapMode.Clamp;

        // Create a transparent texture.
        Color[] pixels = new Color[textureSize * textureSize];

        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = Color.clear;

        paintTexture.SetPixels(pixels);
        paintTexture.Apply();

// Paint colour should be fully opaque.
        paintColor = new Color(1f, 0f, 0f, 1f);

        // Give the texture to the material.
        GetComponent<Renderer>().material.mainTexture =
            paintTexture;

        // Paint one test circle in the middle.
        PaintAt(textureSize / 2, textureSize / 2);
    }

    public void PaintAt(int centerX, int centerY)
    {
        for (int y = -brushRadius; y <= brushRadius; y++)
        {
            for (int x = -brushRadius; x <= brushRadius; x++)
            {
                if (x * x + y * y >
                    brushRadius * brushRadius)
                    continue;

                int px = centerX + x;
                int py = centerY + y;

                if (px < 0 || px >= textureSize ||
                    py < 0 || py >= textureSize)
                    continue;

                paintTexture.SetPixel(px, py, paintColor);
            }
        }

        paintTexture.Apply();
    }
}