using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundController : MonoBehaviour {

    public GameObject objectToSpawn;
    public List<Transform> meshTiles = new List<Transform>();
    int spawnRadius = 4;
    GameObject player;
    List<Transform> spawnZoneTiles = new List<Transform>();

    void Start() {
        GeneratePlaygroundMesh();
        player = GameObject.FindGameObjectWithTag("Player");
        GenerateTileSpawnZone();
    }

    void GeneratePlaygroundMesh() {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
            meshTiles.Add(transform.GetChild(i));
    }

    public void SpawnTile() {
        Transform tileTransform = spawnZoneTiles[Random.Range(0, spawnZoneTiles.Count)];
        while (tileTransform.childCount > 0) {
            if (IsSpawnZoneFilled()) 
                return;

            tileTransform = spawnZoneTiles[Random.Range(0, spawnZoneTiles.Count)];
        }
            
        Instantiate(objectToSpawn, tileTransform);
    }

    public void GenerateTileSpawnZone() {
        spawnZoneTiles = new List<Transform>();
        Vector3 currentPlayerPosition = player.transform.position;
        foreach (Transform meshTile in meshTiles) {
            if (meshTile.position.x >= currentPlayerPosition.x - spawnRadius
                && meshTile.position.x <= currentPlayerPosition.x + spawnRadius
                && meshTile.position.z >= currentPlayerPosition.z - spawnRadius
                && meshTile.position.z <= currentPlayerPosition.z + spawnRadius) {
                spawnZoneTiles.Add(meshTile);
            }
        }
    }

    bool IsSpawnZoneFilled() {
        foreach (Transform tile in spawnZoneTiles) {
            if (tile.childCount == 0) 
                return false;
        }

        return true;
    }

    public bool IsInSpawnZone(Transform transform) {
        foreach (Transform spawnZoneTile in spawnZoneTiles) {
            if (spawnZoneTile.position.x == transform.position.x && spawnZoneTile.position.z == transform.position.z) 
                return true;
        }

        return false;
    }
}
