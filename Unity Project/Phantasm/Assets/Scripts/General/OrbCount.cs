using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrbCount : MonoBehaviour
{
    private GlobalState globalState;

	// Use this for initialization
	void Start ()
    {
        globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
    }

    void Update ()
    {
        GetComponent<Text>().text = "Score: " + globalState.orbsCollected.ToString();
    }
}
