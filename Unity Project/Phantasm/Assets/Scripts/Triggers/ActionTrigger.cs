using UnityEngine;
using System.Collections;

public class ActionTrigger : MonoBehaviour
{

    public string triggerTag;
    public TriggerAction triggerAction;

    public bool requiresPuzzleSolved;
    public int puzzleID;

    private bool triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == triggerTag && !triggered)
        {
            var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
            if (!requiresPuzzleSolved || (globalState.puzzlesSolved >= puzzleID))
            {
                triggerAction.execute();
                triggered = true;
            }
        }
    }

}
