using UnityEngine;
using System.Collections;

public class SetRespawnPoint : TriggerAction
{

    public Vector2 respawnPoint;

    public override void execute()
    {
        var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
        globalState.respawnPoint = respawnPoint;
    }

}
