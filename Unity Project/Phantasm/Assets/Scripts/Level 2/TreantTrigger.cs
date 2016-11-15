using UnityEngine;
using System.Collections;

public class TreantTrigger : MonoBehaviour {

    public TreantBehaviour treantBehaviour;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (GameObject.Find("Global State").GetComponent<GlobalState>().getInstance().puzzleData.puzzle2Solved) {
                treantBehaviour.flyAway();
            }
        }
    }

}
