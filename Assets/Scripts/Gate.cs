//Script covers calls to individual tiles on a tilemap
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Gate : MonoBehaviour
{

    public Vector3Int tilePos1;
    public Vector3Int tilePos2;

    //Closed Gate Sprites;
    public Tile closedGate1;
    public Tile closedGate2;

    //Open Gate Sprites
    public Tile openGate1;
    public Tile openGate2;

    //player
    public Character character;

    //The tilemap the gate is on
    public Tilemap tilemap;

    public bool opened;

    // Start is called before the first frame update
    void Start()
    {
        opened = false;

        tilemap.SetTile(tilePos1, closedGate1);
        tilemap.SetTile(tilePos2, closedGate2);
    }

    public void OpenGate()
    {
        opened = true;
        
        tilemap.SetTile(tilePos1, openGate1);
        tilemap.SetTile(tilePos2, openGate2);
    }
}
