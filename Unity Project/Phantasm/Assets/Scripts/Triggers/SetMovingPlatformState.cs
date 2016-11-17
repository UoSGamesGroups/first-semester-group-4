using UnityEngine;
using System.Collections;

public class SetMovingPlatformState : TriggerAction {

    public MovingPlatform platform;
    public bool state;
    public bool loopState;

    public override void execute()
    {
        platform.active = state;
        platform.looping = loopState;
    }

}
