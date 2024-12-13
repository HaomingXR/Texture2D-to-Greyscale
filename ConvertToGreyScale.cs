using UnityEngine;

public static class ConvertToGreyScale
{
    private static readonly Shader grayscaleShader = Shader.Find("Hidden/GrayscaleConverter");
    private static Material grayscaleMaterial = new Material(grayscaleShader);

    public static void ConvertToGrayscaleNonReadable(ref Texture2D originalTexture, ref Texture2D grayscaleTexture)
    {
        RenderTexture tempRenderTexture = RenderTexture.GetTemporary(
            originalTexture.width,
            originalTexture.height,
            0,
            RenderTextureFormat.ARGB32
        );

        Graphics.Blit(originalTexture, tempRenderTexture, grayscaleMaterial);

        RenderTexture.active = tempRenderTexture;
        grayscaleTexture.ReadPixels(new Rect(0, 0, tempRenderTexture.width, tempRenderTexture.height), 0, 0);
        grayscaleTexture.Apply();

        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(tempRenderTexture);
    }
}
