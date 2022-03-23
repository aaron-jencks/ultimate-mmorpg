using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public TileClass tile;
    public int worldSize = 100;
    public int chunkSize = 16;

    private List<GameObject> chunks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        generateChunks();
        generateTerrain();
    }

    public void generateChunks() {
        for(int i = 0; i < (worldSize / chunkSize); i++) {
            for(int j = 0; j < (worldSize / chunkSize); j++) {
                GameObject obj = new GameObject(name=i.ToString() + "x" + j.ToString());
                obj.transform.parent = this.transform;
                chunks.Add(obj);
            }
        }
    }

    public void generateTerrain() {
        for(int  x = 0; x < worldSize; x++) {
            for(int y = 0; y < worldSize; y++) {
                placeTile(tile.tileSprite, x, y);
            }
        }
    }

    public void placeTile(Sprite tileSprite, int x, int y) {
        GameObject newTile = new GameObject(name=tileSprite.name);
        newTile.AddComponent<SpriteRenderer>();
        newTile.GetComponent<SpriteRenderer>().sprite = tileSprite;
        newTile.transform.parent = chunks[(worldSize / chunkSize) * (y / chunkSize) + (x / chunkSize)].transform;
        newTile.transform.position = new Vector2((float)x + 0.5f, (float)y + 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
