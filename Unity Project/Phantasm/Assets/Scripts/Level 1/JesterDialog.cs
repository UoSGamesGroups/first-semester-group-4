using UnityEngine;
using System.Collections;

public class JesterDialog : MonoBehaviour {

    public DialogBox dialogBox;
    public string unsolvedText, solvedText;

    private bool solved;
    public bool singleUse, dominant;
    private bool triggered = false;
   

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {
            if ((!triggered || !singleUse) && (!dialogBox.isVisible() || dominant)) {
                if (GameObject.Find("Global State").GetComponent<GlobalState>().getInstance().puzzleData.puzzle1Solved)
                {
                    dialogBox.showDialog(solvedText);
                }
                else
                {
                    dialogBox.showDialog(unsolvedText);

                }
                triggered = true;
            }


        }

    }

}
