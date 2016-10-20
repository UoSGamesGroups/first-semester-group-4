using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public int Scene;

    public void OnTriggerEnter2D(Collider2D _Collision) {
        if (_Collision.gameObject.tag == "Player") {
            SceneManager.LoadScene(Scene);
        }
    }

}
