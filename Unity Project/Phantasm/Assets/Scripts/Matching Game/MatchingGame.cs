using System.Collections;
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

    private const float TIMEGIVEN = 60f;
    private const float TIMEREWARD = 2.5f;
    private float timeLeft;
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
        timeLeft = TIMEGIVEN;
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
                timeLeft += TIMEREWARD;
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
            txtCountdown.text = "TIME LEFT\n" + string.Format("{0:0.00}", timeLeft);

            if (timeLeft <= 0)
            {
                resetGame();
            }

            checkMatches();

            if (checkWin())
            {
                playing = false;
                win();
            }

        }

    }

    private void win()
    {
        var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
        globalState.puzzleData.puzzle1Solved = true;
        globalState.playerData.needsPorting = true;
        globalState.playerData.startPosition = new Vector2(11.5f, -40.0f);
        globalState.saveState();
        sfxWin.Play();
        StartCoroutine(changeScene(1.5f));
    }

    private IEnumerator changeScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        sceneTransitioner.changeScene(1);
    }

    public void solve()
    {
        foreach (var tile in tileSpaces)
        {
            tile.GetComponent<Tile>().flip();
            win();
        }
    }

}
