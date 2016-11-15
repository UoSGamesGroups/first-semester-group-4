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


    public float timeGiven = 45f;
    private const float TIME_REWARD = 2.5f;
    private const float PEEK_TIME = 0.5f;

    private float timeLeft;
    private bool playing;
    private int scene = 0;

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
        timeLeft = timeGiven;
        txtCountdown.text = "TIME LEFT\n" + string.Format("{0:0.00}", timeLeft);
        placeTiles();
        resetGame();
        StartCoroutine(peekTiles());
    }

    private IEnumerator peekTiles()
    {
        foreach (var tile in tileSpaces)
        {
           tile.GetComponent<Tile>().flip();
            yield return new WaitForSeconds(0.1f);
            tile.GetComponent<Tile>().hold();
        }
        yield return new WaitForSeconds(PEEK_TIME);
        startGame();
    }

    private void placeTiles()
    {
        for (var i = 0; i < tileSpaces.Count; i++)
        {
            tileSpaces[i].GetComponent<Tile>().setData(tileData[i]);
        }
    }

    private void startGame()
    {
        StartCoroutine(resetTiles());
    }

    private void resetGame()
    {
        resetTiles();
        shuffleTiles();
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
                timeLeft += TIME_REWARD;
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

    private IEnumerator resetTiles()
    {
        for(var i = tileSpaces.Count - 1; i >= 0; i--)
        {
            tileSpaces[i].GetComponent<Tile>().reset();
            yield return new WaitForSeconds(0.1f);
        }
        playing = true;
        timeLeft = timeGiven;
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
                startGame();
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
        if (!globalState.puzzleData.puzzle1Solved)
        {
            globalState.puzzleData.puzzle1Solved = true;
            globalState.playerData.needsPorting = true;
            globalState.playerData.startPosition = new Vector2(11.5f, -40.0f);
            scene = 1;
        }
        else if (!globalState.puzzleData.puzzle2Solved)
        {
            globalState.puzzleData.puzzle2Solved = true;
            globalState.playerData.needsPorting = true;
            globalState.playerData.startPosition = new Vector2(49.08f, 57.14f);
            scene = 4;
        }
        globalState.saveState();
        sfxWin.Play();
        StartCoroutine(changeScene(1.5f));
    }

    private IEnumerator changeScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        sceneTransitioner.changeScene(scene);
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
