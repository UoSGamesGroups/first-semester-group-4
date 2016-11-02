using UnityEngine;
using System.Collections;

public class MatchingGameTransition : MonoBehaviour
{

    public SceneTransitioner sceneTransitioner;
    public Sprite sprUnsolved, sprSolved;
    private bool solved;

    private void Start()
    {
        solved = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance().puzzleData.puzzle1Solved;
        GetComponent<SpriteRenderer>().sprite = solved ? sprSolved : sprUnsolved;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !solved)
        {
            StartCoroutine(startGame());
        }
    }

    private IEnumerator startGame()
    {
        yield return new WaitForSeconds(1.0f);
        sceneTransitioner.changeScene(2);
    }


}
