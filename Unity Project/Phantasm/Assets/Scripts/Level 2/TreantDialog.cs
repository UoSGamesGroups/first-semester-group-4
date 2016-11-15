using UnityEngine;
using System.Collections;

public class TreantDialog : MonoBehaviour {

    public DialogBox dialogBox;
    public string unsolvedText, solvedText;
    public Animator animator;

    private bool solved;
    public bool singleUse, dominant;
    private bool triggered = false;


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {
            if ((!triggered || !singleUse) && (!dialogBox.isVisible() || dominant)) {
                if (GameObject.Find("Global State").GetComponent<GlobalState>().getInstance().puzzleData.puzzle2Solved) {
                    dialogBox.showDialog(solvedText);
                }
                else {
                    dialogBox.showDialog(unsolvedText);
                    animator.SetBool("Rising", true);
                }
                triggered = true;
            }


        }

    }

}
