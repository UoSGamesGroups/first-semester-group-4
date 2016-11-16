using UnityEngine;
using System.Collections;

public class MatchingGameWall : MonoBehaviour {


    public SceneTransitioner sceneTransitioner;
    public Sprite sprUnsolved, sprSolved;

    public int puzzleID;
    public int sceneIndex;
    public int delay;

    private bool solved;

    private void Start()
    {
        var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
        solved = globalState.puzzlesSolved >= puzzleID;
        GetComponent<SpriteRenderer>().sprite = solved ? sprSolved : sprUnsolved;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
            solved = globalState.puzzlesSolved >= puzzleID;
            if (!solved)
            {
                StartCoroutine(startGame());
            }
        }
    }

    private IEnumerator startGame()
    {
        yield return new WaitForSeconds(delay);
        sceneTransitioner.changeScene(sceneIndex);
    }

}
