using UnityEngine;
using System.Collections;

public class PuzzleDialogTrigger : MonoBehaviour
{

    public DialogBox dialogBox;
    public int puzzleID;

    public string txtUnsolved;
    public string txtSolved;

    public bool singleUse;
    public bool dominant;

    private bool triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if ((!triggered || !singleUse) && (!dialogBox.isVisible() || dominant))
        {
            var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
            dialogBox.showDialog(globalState.puzzlesSolved >= puzzleID ? txtSolved : txtUnsolved);
            triggered = true;
        }
    }
}


