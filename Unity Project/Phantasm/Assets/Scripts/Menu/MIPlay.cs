using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MIPlay : MenuItem {

    public override void Execute() {
        SceneManager.LoadScene(1);
    }

}
