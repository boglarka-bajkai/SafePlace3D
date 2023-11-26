using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GenerateNoise : MonoBehaviour
{
    [SerializeField] int mapWidth = 500;
    [SerializeField] int mapHeight = 500;
    [SerializeField] float scale = 0.0001f;
    [SerializeField] int octaves = 3;
    [SerializeField] float persistance = 0.5f;
    [SerializeField] float lacunarity = 2f;
    // Start is called before the first frame update
    void Start()
    {
		float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, scale, octaves, persistance, lacunarity);
		//write this to a file
		Texture2D tex = new Texture2D(mapWidth, mapHeight, TextureFormat.ARGB32, false);
		for (int i = 0; i < mapHeight; i++)
		{
			for (int j = 0; j < mapWidth; j++)
			{
				float value = noiseMap[i, j];
				tex.SetPixel(i, j, Color.Lerp(Color.black, Color.white, value));
			}
		}
		tex.Apply();
		byte[] bytes = ImageConversion.EncodeArrayToPNG(tex.GetRawTextureData(), tex.graphicsFormat, (uint)mapWidth, (uint)mapHeight);
		Object.Destroy(tex);
		File.WriteAllBytes(Application.dataPath + "/StreamingAssets/perlinNoise.png", bytes);
	}

}
