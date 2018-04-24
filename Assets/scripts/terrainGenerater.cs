using UnityEngine;

public class terrainGenerater : MonoBehaviour {

    public int depth = 20;
    public int width = 256;
    public int height = 256;

    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;

    private Terrain terrain;

    // Use this for initialization
    void Start () {
        offsetX = Random.Range(500f, 1000);
        offsetY = Random.Range(500f,1000);
        terrain = GetComponent<Terrain>();

    }
    void Update()
    {
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        float DeltaTimeTime4 = Time.deltaTime * 4f;
        offsetX += DeltaTimeTime4;
        offsetY += DeltaTimeTime4;


    }
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;

    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = Mathf.PerlinNoise((float)x / width * scale + offsetX, (float)y / height * scale + offsetY);
            }
        }
        return heights;
    }

}
