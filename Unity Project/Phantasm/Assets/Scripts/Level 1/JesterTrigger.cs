using UnityEngine;
using System.Collections;

public class JesterTrigger : MonoBehaviour
{

    public JesterBehaviour jesterBehaviour;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameObject.Find("Global State").GetComponent<GlobalState>().getInstance().puzzleData.puzzle1Solved)
            {
                jesterBehaviour.flyAway();
            }
        }
    }


}
