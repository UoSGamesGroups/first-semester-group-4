using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class MatchingGame : MonoBehaviour
{

    public SceneTransitioner sceneTransitioner;

    public Text txtCountdown;

    public AudioSource sfxSuccess;
    public AudioSource sfxWin;

    public List<TileData> tileData;
    public List<GameObject> tileSpaces;

    private const float timeGiven = 60f;
    private float timeLeft = 10f;
    private bool playing;

    private struct FlippedTile
    {

        public readonly int index;
        public readonly int value;

        public FlippedTile(int index, int value)
        {
            this.index = index;
            this.value = value;
        }

    }

    private void Start()
    {
        placeTiles();
        resetGame();
    }

    private void placeTiles()
    {
        for (var i = 0; i < tileSpaces.Count; i++)
        {
            tileSpaces[i].GetComponent<Tile>().setData(tileData[i]);
        }
    }

    private void resetGame()
    {
        resetTiles();
        shuffleTiles();
        playing = true;
        timeLeft = timeGiven;
    }

    private void shuffleTiles() {
        for (var i = tileSpaces.Count - 1; i > 0; i--)
        {
            var index = Random.Range(0, i);
            var temp = tileSpaces[index].GetComponent<Tile>().getData();
            tileSpaces[index].GetComponent<Tile>().setData(tileSpaces[i].GetComponent<Tile>().getData());
            tileSpaces[i].GetComponent<Tile>().setData(temp);
        }
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
                timeLeft += 5f;
            }
            else {
                for (var i = 0; i < flippedTiles.Count; i++)
                {
                    tileSpaces[flippedTiles[i].index].GetComponent<Tile>().reset();
                }
            }
        }

    }

    private List<FlippedTile> getFlippedTiles() {
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

    private void resetTiles()
    {
        foreach (var t in tileSpaces)
        {
            t.GetComponent<Tile>().reset();
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
            timeLeft -= Time.deltaTime;
            txtCountdown.text = string.Format("{0:0.00}", timeLeft);

            if (timeLeft <= 0)
            {
                resetGame();
            }

            checkMatches();

            if (checkWin())
            {
                sfxWin.Play();
                playing = false;
                sceneTransitioner.changeScene(0);
            }

        }

    }

}
