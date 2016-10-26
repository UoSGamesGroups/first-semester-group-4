using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

public class MatchingGame : MonoBehaviour
{

    public List<TileData> tileData;
    public List<GameObject> tileSpaces;

    public AudioSource sfxSuccess;
    public AudioSource sfxWin;

    private bool playing;

    private struct FlippedTile
    {
        public FlippedTile(int index, int value)
        {
            this.index = index;
            this.value = value;
        }

        public readonly int index;
        public readonly int value;

    }


    private void Start()
    {
        initializeTiles();
        playing = true;
    }

    private void initializeTiles()
    {
        var avaliableSpaces = new List<int>();
        for (var i = 0; i < tileSpaces.Count; i++)
        {
            avaliableSpaces.Add(i);
        }
        while (avaliableSpaces.Count > 0)
        {
            var chosenSpace = Random.Range(0, avaliableSpaces.Count);
            var chosenTileData = Random.Range(0, tileData.Count);
            tileSpaces[avaliableSpaces[chosenSpace]].GetComponent<Tile>().setData(tileData[chosenTileData]);
            avaliableSpaces.RemoveAt(chosenSpace);
            tileData.RemoveAt(chosenTileData);
        }
    }

    private List<FlippedTile> getFlippedTiles()
    {
        var t = new List<FlippedTile>();
        for (var i = 0; i < tileSpaces.Count; i++)
        {
            if (tileSpaces[i].GetComponent<Tile>().isFlipped() && !tileSpaces[i].GetComponent<Tile>().isHeld())
            {
                t.Add(new FlippedTile(i, tileSpaces[i].GetComponent<Tile>().getID()));
            }
        }
        return t;
    }

    private void checkMatches()
    {
        var flippedTiles = getFlippedTiles();
        if (flippedTiles.Count == 2)
        {
            if (flippedTiles[0].value == flippedTiles[1].value)
            {
                tileSpaces[flippedTiles[0].index].GetComponent<Tile>().hold();
                tileSpaces[flippedTiles[1].index].GetComponent<Tile>().hold();
                sfxSuccess.Play();
            }
            else {
                for (var i = 0; i < flippedTiles.Count; i++)
                {
                    tileSpaces[flippedTiles[i].index].GetComponent<Tile>().reset();
                }
            }
        }

     }
    

    private bool checkWin()
    {
        return tileSpaces.All(t => t.GetComponent<Tile>().isHeld());
    }

    private void Update()
    {
        if (playing)
        {
            checkMatches();
            if (checkWin())
            {
                sfxWin.Play();
                playing = false;
            }
        }
    }

}
